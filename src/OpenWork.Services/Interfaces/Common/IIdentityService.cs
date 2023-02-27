namespace OpenWork.Services.Interfaces.Common;

public interface IIdentityService
{
	public long Id { get;  }
	public string Name { get;  }
	public string Surname { get; }
	public string Email { get; }
}
