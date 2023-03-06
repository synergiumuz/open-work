using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Dtos.Workers;

using Xunit;

namespace OpenWork.UnitTest;

public class DtoTests
{
	[Theory]
	[InlineData("some@mail.com", "SomeLong34+", true)]
	[InlineData("different@tiut.uz", "MyP@ssw0rd", true)]
	[InlineData("any@other.uk", "35Biscuits-om-nom-nom", true)]
	[InlineData(" ", "         ", false)]
	[InlineData("itisemailhonestly@com", "SomeLong34+", false)]
	[InlineData("", "somelong<3", false)]
	[InlineData("@mail.ru", "SomeLong34+", false)]
	[InlineData("valid@mail.com", "inv@l1dp@sw", false)]
	[InlineData("maybe@tyri.com", "Inval1d	Password", false)]
	[InlineData("	@	.	", "ReAlLy LoNg 850!!", false)]
	public void UserLoginDtoTest(string username, string password, bool correct)
	{
		UserLoginDto user = new()
		{
			Email = username,
			Password = password,
		};
		try
		{
			Validator.ValidateObject(user, new ValidationContext(user));
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
