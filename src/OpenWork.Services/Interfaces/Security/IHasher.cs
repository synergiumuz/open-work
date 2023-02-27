namespace OpenWork.Services.Interfaces.Security;

public interface IHasher
{
	public string Hash(string password, string salt);
	public bool Verify(string hash, string password, string salt);

}
