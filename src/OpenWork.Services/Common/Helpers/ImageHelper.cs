using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Common.Helpers
{
	public class ImageHelper
	{
		public static string MakeImageName(string filename)
		{
			string extension = Path.GetExtension(filename);
			string name = "IMG_" + Guid.NewGuid().ToString();
			return name + extension;
		}

	}
}
