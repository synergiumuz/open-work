using System;
using System.IO;

namespace OpenWork.Domain.Common.Helpers;

public class ImageHelper
{
	public static string MakeImageName(string filename)
	{
		string extension = Path.GetExtension(filename);
		string name = "IMG_" + Guid.NewGuid().ToString();
		return name + extension;
	}
}
