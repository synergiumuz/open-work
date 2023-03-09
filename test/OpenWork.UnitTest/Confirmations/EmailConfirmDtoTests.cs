using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Dtos.Common;

using Xunit;

namespace OpenWork.UnitTest.Confirmations;

public class EmailConfirmDtoTests
{
	[Theory]
	[InlineData("khamidov357@gmail.com", 666666)]
	[InlineData("some@mail.com", 153697)]
	[InlineData("other@tiut.uz", 999999)]
	[InlineData("does@not.mat", 100001)]
	[InlineData("maybe@sample.ru", 132681)]
	public void EmailConfirmDtoValidate_ReturnsTrue(string email, int code)
	{
		EmailConfirmDto dto = new EmailConfirmDto()
		{
			Email = email,
			Code = code
		};
		try
		{
			Validator.ValidateObject(dto, new ValidationContext(dto), true);
			Assert.True(true);
		}
		catch(Exception ex)
		{
			Assert.Fail(ex.Message);
		}
	}

	[Theory]
	[InlineData("some34correct@mail.com", 10000)]
	[InlineData("some@mail.com", 99999)]
	[InlineData("som e@mail.com", 320190)]
	[InlineData("some@mail.com", 090239)]
	[InlineData("some@.com", 850239)]
	[InlineData("Rea11yValid", 390232)]
	[InlineData("some@mail.com\n", 750190)]
	[InlineData("some@mail.com", 4903223)]
	[InlineData("some@mail.com", 000000)]
	[InlineData("Rea11yValid", 390239)]
	[InlineData("ε=ε=ε=(~￣▽￣)~@gmail.com", 492502)]
	[InlineData("some@mail.ε=ε=ε=(~￣▽￣)~", 750238)]
	[InlineData("what$about$incorrect$mails@gmail.dot", 860239)]
	[InlineData("or this@mail.com", 590197)]
	[InlineData("$0l1d@agile.net", 850239)]
	public void EmailConfirmDtoValidate_ReturnsFalse(string email, int code)
	{
		EmailConfirmDto dto = new EmailConfirmDto()
		{
			Email = email,
			Code = code
		};
		Assert.Throws<ValidationException>(() => Validator.ValidateObject(dto, new ValidationContext(dto), true));
	}
}
