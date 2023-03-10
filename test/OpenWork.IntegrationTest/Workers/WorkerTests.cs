using System.Net.Http.Json;

using OpenWork.IntegrationTest.Customs;
using OpenWork.Services.Dtos.Workers;

using Xunit;

namespace OpenWork.IntegrationTest.Workers;

public class WorkerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
	private readonly HttpClient _client;
	private readonly CustomWebApplicationFactory<Program> _factory;

	public WorkerTests(CustomWebApplicationFactory<Program> factory)
	{
		_factory = factory;
		_client = _factory.CreateClient();
	}

	[Fact]
	public async Task WorkerLoginTest()
	{
		WorkerLoginDto dto = new WorkerLoginDto()
		{
			Email = "khamidov357@gmail.com",
			Password = "Resist357"
		};
		var response = await _client.PostAsJsonAsync("/workers/login", dto);
		Assert.True(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
	}

	[Theory]
	[InlineData("O'tkirbek", "Sobirjonov", "otkirbeksobirjonov@tiut.uz", "AAaa@@11", "+998930238512")]
	[InlineData("Sanjar", "Mavlonov", "sanjarmavlonov9@gmail.com", "SomeLong357++", "+998903230193")]
	public async Task WorkerCycle_ReturnsTrue(string name, string surname, string email, string password, string phone)
	{
		try
		{
			var registerContent = new MultipartFormDataContent()
			{
				{new StringContent(name), "Name" },
				{new StringContent(surname), "Surname" },
				{new StringContent(email), "Email" },
				{new StringContent(password), "Password"},
				{new StringContent(phone), "Phone"}
			};
			WorkerLoginDto loginDto = new WorkerLoginDto()
			{
				Email = email,
				Password = password,
			};
			var registerResponse = await _client.PostAsync("/workers/register", registerContent);
			if(!registerResponse.IsSuccessStatusCode)
				Assert.Fail(await registerResponse.Content.ReadAsStringAsync());
			var loginResponse = await _client.PostAsJsonAsync("/workers/login", loginDto);
			if(!loginResponse.IsSuccessStatusCode)
				Assert.Fail(await loginResponse.Content.ReadAsStringAsync());
			_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {await loginResponse.Content.ReadAsStringAsync()}");
			var deleteResponse = await _client.DeleteAsync("/workers");
			if(!deleteResponse.IsSuccessStatusCode)
				Assert.Fail(await deleteResponse.Content.ReadAsStringAsync());
		}
		catch(Exception ex)
		{
			Assert.Fail(ex.Message);
		}
	}
}
