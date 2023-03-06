using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Dtos.Workers;

using Xunit;

namespace OpenWork.UnitTest;

public class DtoTests
{
	[Theory]
	[InlineData("some@mail.com", "SomeLong34+", true)]
	[InlineData("some@mail.com	", "SomeLong34+", false)]
	[InlineData("some@mail.com", "\nSomeLong34+", false)]
	[InlineData("different@tiut.uz", "MyP@ssw0rd", true)]
	[InlineData("diffe rent@tiut.uz", "MyP@ssw0rd", false)]
	[InlineData("	different@tiut.uz", "MyP@ssw0rd", false)]
	[InlineData("diffe\nrent@tiut.uz", "MyP@ssw0rd", false)]
	[InlineData("any@other.uk", "35-Om nom nom", false)]
	[InlineData(" ", "         ", false)]
	[InlineData("itisemailhonestly@com", "SomeLong34+", false)]
	[InlineData("", "somelong<3", false)]
	[InlineData("@mail.ru", "SomeLong34+", false)]
	[InlineData("valid@mail.com", "inv@l1dp@sw", false)]
	[InlineData("maybe@tyri.com", "Inval1d	Password", false)]
	[InlineData("			@			.				", "ReAlL0Ng!!", false)]
	public void UserLoginDtoTest(string username, string password, bool correct)
	{
		UserLoginDto user = new()
		{
			Email = username,
			Password = password,
		};
		try
		{
			Validator.ValidateObject(user, new ValidationContext(user), true);
			Assert.True(correct);
		}
		catch(ValidationException ex)
		{
			Assert.False(correct, ex.Message);
		}
		catch(Exception ex)
		{
			Assert.Fail(ex.Message);
		}
	}
}
