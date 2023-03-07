using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Dtos.Workers;

using Xunit;

namespace OpenWork.UnitTest.Workers;

public class WorkerRegisterDtoTests
{
	[Theory]
	[InlineData("Xamidov", "Komiljon", "some@mail.com", "SomeLong357++")]
	[InlineData("Sobirjonov", "O'tkirbek", "different@tiut.uz", "AAaa@@11")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword")]
	public void WorkerRegisterDtoValidate_ReturnsTrue(string name, string surname, string email, string password)
	{
		WorkerRegisterDto dto = new WorkerRegisterDto()
		{
			Surname = surname,
			Email = email,
			Password = password,
			Name = name
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
	[InlineData("", "Surname", "some34correct@mail.com", "Rea11yValid")]
	[InlineData("", "Surname", "some@mail.com", "Rea11yValid")]
	[InlineData("Name", "Surname", "som e@mail.com", "Rea11yValid")]
	[InlineData("Name", "Surname", "some@mail.com", "NotValid")]
	[InlineData("Name", "Surname", "some@.com", "Rea11yValid")]
	[InlineData("", "", "some@mail.com", "Rea11yValid")]
	[InlineData("Name", "Surname", "some@mail.com\n", "Rea11yValid")]
	[InlineData("Name", "Surname", "some@mail.com", "Rea 11yValid")]
	[InlineData("Name is very very very very very very long. I can continue. Do you really accept to create so long names? it's impossible to have a such long name, i'm sure. It's BUG!", "Surname", "some@mail.com", "Rea11yValid")]
	[InlineData("Name", "Surname", "OkayNowIAmGoingToWriteReallyBigThingsInsteadOf@EmailYesItIsWithoutSpacesButItIsInvalidBecauseSitesDoesNotAllowCreatingSuchLongEmails.com", "Rea11yValid")]
	[InlineData("Name", "Surname", "some@mail.com", "Hmm.. what's about texts in password? you fixed it, not you?")]
	[InlineData("Name", "Surname", "some@mail.com", "ε=ε=ε=(~￣▽￣)~")]
	[InlineData("Name", "Surname", "ε=ε=ε=(~￣▽￣)~@gmail.com", "Rea11yValid")]
	[InlineData("Name", "Surname", "some@mail.ε=ε=ε=(~￣▽￣)~", "Rea11yValid")]
	[InlineData("Name", "Surname", "what_about_incorrect_mails@gmail.dot", "Rea11yValid")]
	[InlineData("Name", "Surname", "or this@mail.com", "Rea11yValid")]
	[InlineData("Name", "Surname", "$0l1d@agile.net", "Rea11yValid")]
	public void WorkerRegisterDtoValidate_ReturnsFalse(string name, string surname, string username, string password)
	{
		WorkerRegisterDto dto = new WorkerRegisterDto()
		{
			Surname = surname,
			Email = username,
			Name = name,
			Password = password
		};
		Assert.Throws<ValidationException>(() => Validator.ValidateObject(dto, new ValidationContext(dto), true));
	}
}
