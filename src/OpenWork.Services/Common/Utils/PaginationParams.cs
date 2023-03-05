namespace OpenWork.Services.Common.Utils;

public class PaginationParams
{
	public PaginationParams(int size, int number)
	{
		Size = size;
		Number = number;
	}

	public int Size { get; set; }

	public int Number { get; set; }
}
