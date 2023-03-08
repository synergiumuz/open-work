using System.Net.Http.Json;

using Microsoft.AspNetCore.Mvc.Testing;

using OpenWork.IntegrationTest.Customs;
using OpenWork.Services.Dtos.Users;
using System.Net.Http.Json;
using Xunit;

namespace OpenWork.IntegrationTest;

public class UserTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
	private readonly HttpClient _client;
	private readonly CustomWebApplicationFactory<Program> _factory;

	public UserTests(CustomWebApplicationFactory<Program> factory)
	{
		_factory = factory;
		_client = factory.CreateClient(new WebApplicationFactoryClientOptions
		{
			AllowAutoRedirect = false
		});
	}

	[Fact]
	public async Task UserLoginTest()
	{
		UserLoginDto dto = new()
		{
			Email = "khamidov357@gmail.com",
			Password = "Resist357",
		};
		var response = await _client.PostAsJsonAsync("/users/login", dto);
		Assert.True(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
	}

	[Theory]
	[InlineData("Sobirjonov", "O'tkirbek", "different@tiut.uz", "AAaa@@11")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword")]
	public async Task UserCycle_ReturnsTrue(string name, string surname, string email, string password)
	{
		try
		{
			UserRegisterDto registerDto = new UserRegisterDto()
			{
				Name = name,
				Surname = surname,
				Email = email,
				Password = password
			};
			UserLoginDto loginDto = new UserLoginDto()
			{
				Email = email,
				Password = password
			};
			var registerResponse = await _client.PostAsJsonAsync("/users/register", registerDto);
			if(!registerResponse.IsSuccessStatusCode)
				Assert.Fail(await registerResponse.Content.ReadAsStringAsync());
			var loginResponse = await _client.PostAsJsonAsync("/users/login", loginDto);
			if(!loginResponse.IsSuccessStatusCode)
				Assert.Fail(await loginResponse.Content.ReadAsStringAsync());
			_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {await loginResponse.Content.ReadAsStringAsync()}");
			var deleteResponse = await _client.DeleteAsync("/users");
			if(!deleteResponse.IsSuccessStatusCode)
				Assert.Fail(await deleteResponse.Content.ReadAsStringAsync());
		}
		catch(Exception ex)
		{
			Assert.Fail(ex.Message);
		}
	}
}
