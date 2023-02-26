namespace OpenWork.Services.Interfaces.Common;

public interface IIdentityService
{
	public long Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Email { get; set; }
}
