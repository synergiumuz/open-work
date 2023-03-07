using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Dtos.Users;

using Xunit;

namespace OpenWork.UnitTest.Users;

public class UserLoginDtoTests
{
	[Theory]
	[InlineData("different@tiut.uz", "MyP@ssw0rd")]
	[InlineData("some@mail.com", "SomeLong34+")]
	public void UserLoginDtoValidate_ReturnsTrue(string username, string password)
	{
		UserLoginDto user = new()
		{
			Email = username,
			Password = password,
		};
		try
		{
			Validator.ValidateObject(user, new ValidationContext(user), true);
			Assert.True(true);
		}
		catch(Exception ex)
		{
			Assert.Fail(ex.Message);
		}
	}
	[Theory]
	[InlineData("some@mail.com	", "SomeLong34+")]
	[InlineData("some@mail.com", "\nSomeLong34+")]
	[InlineData("diffe rent@tiut.uz", "MyP@ssw0rd")]
	[InlineData("	different@tiut.uz", "MyP@ssw0rd")]
	[InlineData("diffe\nrent@tiut.uz", "MyP@ssw0rd")]
	[InlineData("any@other.uk", "35-Om nom nom")]
	[InlineData(" ", "         ")]
	[InlineData("itisemailhonestly@com", "SomeLong34+")]
	[InlineData("", "somelong<3")]
	[InlineData("@mail.ru", "SomeLong34+")]
	[InlineData("valid@mail.com", "inv@l1dp@sw")]
	[InlineData("maybe@tyri.com", "Inval1d	Password")]
	[InlineData("			@			.				", "ReAlL0Ng!!")]
	public void UserLoginDtoValidate_ReturnFalse(string username, string password)
	{
		UserLoginDto user = new()
		{
			Email = username,
			Password = password,
		};
		Assert.Throws<ValidationException>(() => Validator.ValidateObject(user, new ValidationContext(user), true));
	}
}
