using Xunit;

namespace OpenWork.UnitTest.Confirmations;

public class PhoneConfirmDtoTests
{
	[Theory]
	[InlineData("+998993332222", 10000)]
	[InlineData("+998993332222", 99999)]
	[InlineData("+998993332222", 9999999)]
	[InlineData("+998993332222", 1000000)]
	[InlineData("+998993332222", 000000)]
	[InlineData("998993332222", 390239)]
	[InlineData("-998993332222", 390239)]
	[InlineData("b998993332222", 390239)]
	[InlineData("+9v98993332222", 390239)]
	[InlineData("+ 998993332222", 390239)]
	[InlineData("+998 993332222", 390239)]
	[InlineData("+998 93332222", 390239)]
	[InlineData("+998993332222\n", 390239)]
	[InlineData("\t+998993332222", 390239)]
	[InlineData("+99899 3332222", 390239)]
	[InlineData("+99s899333222", 390239)]
	public void PhoneConfirmDtoTest_ReturnsFalse(string phone, int code)
	{

	}
}
