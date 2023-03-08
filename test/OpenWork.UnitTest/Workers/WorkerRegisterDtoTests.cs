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
	[InlineData("", "Surname", "some34correct@mail.com", "Rea11yValid", "+998230030293")]
	[InlineData("", "Surname", "some@mail.com", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "som e@mail.com", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "some@mail.com", "NotValid", "+998230030293")]
	[InlineData("Name", "Surname", "some@.com", "Rea11yValid", "+998230030293")]
	[InlineData("", "", "some@mail.com", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "some@mail.com\n", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "some@mail.com", "Rea 11yValid", "+998230030293")]
	[InlineData("Name is very very very very very very long. I can continue. Do you really accept to create so long names? it's impossible to have a such long name, i'm sure. It's BUG!", "Surname", "some@mail.com", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "OkayNowIAmGoingToWriteReallyBigThingsInsteadOfEmailYesItIsWithoutSpacesButItIsInvalid@BecauseSitesDoesNotAllowCreatingSuchLongEmails.com", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "OkayNowIAmGoingToWriteReallyBigThingsInsteadOf@EmailYesItIsWithoutSpacesButItIsInvalid@BecauseSitesDoesNotAllowCreatingSuchLongEmails.OkayNowIAmGoingToWriteReallyBigThingsInsteadOfEmailYesItIsWithoutSpacesButItIsInvalidBecauseSitesDoesNotAllowCreatingSuchLongEmails.OkayNowIAmGoingToWriteReallyBigThingsInsteadOfEmailYesItIsWithoutSpacesButItIsInvalidBecauseSitesDoesNotAllowCreatingSuchLongEmails", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "some@mail.com", "Hmm.. what's about texts in password? you fixed it, not you?", "+998230030293")]
	[InlineData("Name", "Surname", "some@mail.com", "ε=ε=ε=(~￣▽￣)~", "+998230030293")]
	[InlineData("Name", "Surname", "ε=ε=ε=(~￣▽￣)~@gmail.com", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "some@mail.ε=ε=ε=(~￣▽￣)~", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "what_about_incorrect_mails@gmail.dot", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "or this@mail.com", "Rea11yValid", "+998230030293")]
	[InlineData("Name", "Surname", "$0l1d@agile.net", "Rea11yValid", "+998230030293")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "998993332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "-998993332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "b998993332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "+9v98993332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "+ 998993332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "+998 993332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "+998 93332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "+998993332222\n")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "\t+998993332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "+99899 3332222")]
	[InlineData("Po'latov", "Temurbek", "temur40@mail.ru", "N0tl0ngP@ssword", "+99s899333222")]
	public void WorkerRegisterDtoValidate_ReturnsFalse(string name, string surname, string username, string password, string phone)
	{
		WorkerRegisterDto dto = new WorkerRegisterDto()
		{
			Surname = surname,
			Email = username,
			Name = name,
			Password = password,
			Phone = phone
		};
		Assert.Throws<ValidationException>(() => Validator.ValidateObject(dto, new ValidationContext(dto), true));
	}
}
