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
		var httpContent = new MultipartFormDataContent
		{
			{ new StringContent(dto.Email), "Email" },
			{ new StringContent(dto.Password), "Password" }
		};
		var response = await _client.PostAsync("/users/login", httpContent);
		Assert.True(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
	}
}
