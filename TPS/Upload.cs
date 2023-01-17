using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Colorful;

namespace TPS
{
	public class Upload
	{
		public static List<string> combolist;

		public List<string> Combo()
		{
			OpenFileDialog openFileDialog;
			do
			{
				openFileDialog = new OpenFileDialog
				{
					Title = "Choose your comboList",
					Filter = "Text File | *.txt"
				};
			}
			while (openFileDialog.ShowDialog() != DialogResult.OK);
			combolist = File.ReadAllLines(openFileDialog.FileName).ToList();
			return combolist;
		}

		public List<string> Proxys()
		{
			OpenFileDialog openFileDialog;
			do
			{
				openFileDialog = new OpenFileDialog
				{
					Title = "Choose your proxyList",
					Filter = "Text File | *.txt"
				};
			}
			while (openFileDialog.ShowDialog() != DialogResult.OK);
			List<string> result = File.ReadAllLines(openFileDialog.FileName).ToList();
			Colorful.Console.WriteLine("\n", Color.BlueViolet);
			return result;
		}

		public int Threads()
		{
			System.Console.ForegroundColor = ConsoleColor.Cyan;
			Colorful.Console.Write("How many threads do you want to use: ", Color.BlueViolet);
			System.Console.ForegroundColor = ConsoleColor.White;
			Variables.Threads = int.Parse(System.Console.ReadLine());
			return Variables.Threads;
		}

		public string proxyType()
		{
			string text;
			do
			{
				Colorful.Console.Write("Please select your proxy type [HTTP, SOCKS4, SOCKS5]: ", Color.BlueViolet);
				System.Console.ForegroundColor = ConsoleColor.White;
				text = System.Console.ReadLine().ToUpper();
			}
			while (!(text == "HTTP") && !(text == "SOCKS4") && !(text == "SOCKS5"));
			return text;
		}
	}
}
