using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Dtos.Workers;

using Xunit;

namespace OpenWork.UnitTest.Workers;

public class WorkerLoginDtoTests
{
	[Theory]
	[InlineData("different@tiut.uz", "MyP@ssw0rd")]
	[InlineData("some@mail.com", "SomeLong34+")]
	public void WorkerLoginDtoValidate_ReturnsTrue(string username, string password)
	{
		WorkerLoginDto worker = new()
		{
			Email = username,
			Password = password,
		};
		try
		{
			Validator.ValidateObject(worker, new ValidationContext(worker), true);
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
	public void WorkerLoginDtoValidate_ReturnsFalse(string username, string password)
	{
		WorkerLoginDto dto = new WorkerLoginDto()
		{
			Email = username,
			Password = password,
		};
		Assert.Throws<ValidationException>(() => Validator.ValidateObject(dto, new ValidationContext(dto), true));
	}
}
