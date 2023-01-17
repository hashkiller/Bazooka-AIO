using System;
using System.IO;

namespace TPS
{
	public class data
	{
		public static readonly string day = DateTime.Now.ToString("hh - MMM dd, yyyy");

		public static string fileResult = "./Results/" + day + "/";

		public void Results(string text, string file, string module)
		{
			Directory.CreateDirectory(fileResult + module + "/");
			StreamWriter streamWriter = new StreamWriter(fileResult + module + "/" + file + ".txt", append: true);
			streamWriter.WriteLine(text);
		}
	}
}
