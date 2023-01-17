using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colorful;
using xNet;

namespace TPS
{
	public class Checker
	{
		public static Stopwatch st = new Stopwatch();

		public static Upload upload = new Upload();

		public static Variables var = new Variables();

		public static int CPM;

		public static int Increment_CPM;

		public static void Init()
		{
			System.Console.Title = configuration.nameChecker + " " + configuration.versionChecker + " | Made by " + configuration.Coder;
			System.Console.Clear();
			Print_Logo();
			System.Console.WriteLine("");
			Colorful.Console.WriteLine("Press any key to load combo...", Color.BlueViolet);
			System.Console.ReadKey(intercept: true);
			Variables.ComboList = upload.Combo();
			Variables.ComboLenght = Variables.ComboList.Count();
			if (configuration.Useproxy)
			{
				System.Console.WriteLine("");
				Colorful.Console.WriteLine("Press any key to load proxies...", Color.BlueViolet);
				System.Console.ReadKey(intercept: true);
				var.ProxyList = upload.Proxys();
				switch (upload.proxyType().ToLower())
				{
				case "socks5":
					var.proxyType = ProxyType.Socks5;
					break;
				case "socks4a":
					var.proxyType = ProxyType.Socks4a;
					break;
				case "socks4":
					var.proxyType = ProxyType.Socks4;
					break;
				case "http":
					var.proxyType = ProxyType.Http;
					break;
				case null:
					System.Console.ForegroundColor = ConsoleColor.Red;
					System.Console.WriteLine("You entered the wrong type of proxy!");
					System.Console.ReadLine();
					Environment.Exit(0);
					break;
				}
			}
			System.Console.WriteLine("");
			while (true)
			{
				Colorful.Console.Write("Do you want to show fails in the console? [y/n]: ", Color.BlueViolet);
				string a = System.Console.ReadLine().ToUpper();
				System.Console.WriteLine();
				if (!(a == "Y"))
				{
					if (!(a == "N"))
					{
						System.Console.WriteLine("Please select a valid option...\n");
						continue;
					}
					Program.ShowFails = false;
					break;
				}
				Program.ShowFails = true;
				break;
			}
			Variables.Threads = upload.Threads();
			System.Console.ForegroundColor = ConsoleColor.White;
			System.Console.WriteLine("\nRunning (" + Variables.Threads + "/" + Variables.Threads + ") Threads.\n");
			Task.Factory.StartNew(delegate
			{
				while (true)
				{
					goTitle();
				}
			});
		}

		public static void goTitle()
		{
			CPM = Increment_CPM;
			Increment_CPM = 0;
			System.Console.Title = configuration.nameChecker + " | (" + Variables.Progress + "/" + Variables.ComboLenght + ") | Hits: " + Variables.Hits + " - Bads: " + Variables.Fails + " - CPM: " + CPM * 60 + " - Elapsed: " + GetElapsed() + " | Made by " + configuration.Coder;
			Thread.Sleep(500);
		}

		public static string post(string url, ProxyType proxyType, bool Post = false, string contentType = null, string dataPost = null, string userAgent = null)
		{
			HttpRequest httpRequest = new HttpRequest();
			if (configuration.Useproxy)
			{
				string text = var.ProxyList[new Random().Next(var.ProxyList.Count)];
				Array array = text.Split(':');
				httpRequest.Proxy = ProxyClient.Parse(proxyType, (string)((object[])array)[0] + ":" + (string)((object[])array)[1]);
				if (array.Length == 4)
				{
					httpRequest.Proxy.Username = (string)((object[])array)[2];
					httpRequest.Proxy.Password = (string)((object[])array)[3];
				}
				httpRequest.ConnectTimeout = 3000;
			}
			httpRequest.IgnoreProtocolErrors = true;
			httpRequest.AllowAutoRedirect = true;
			if (userAgent != null)
			{
				httpRequest.UserAgent = userAgent;
			}
			if (Post)
			{
				return httpRequest.Post(new Uri(url, UriKind.Absolute), (dataPost == null) ? new byte[0] : Encoding.UTF8.GetBytes(dataPost), contentType).ToString();
			}
			return httpRequest.Get(url).ToString();
		}

		public static string Get(string url, ProxyType proxyType, bool? Headers = null, string header = null, string value = null, string userAgent = null)
		{
			HttpRequest httpRequest = new HttpRequest();
			if (configuration.Useproxy)
			{
				string text = var.ProxyList[new Random().Next(var.ProxyList.Count)];
				Array array = text.Split(':');
				httpRequest.Proxy = ProxyClient.Parse(proxyType, (string)((object[])array)[0] + ":" + (string)((object[])array)[1]);
				if (array.Length == 4)
				{
					httpRequest.Proxy.Username = (string)((object[])array)[2];
					httpRequest.Proxy.Password = (string)((object[])array)[3];
				}
				httpRequest.ConnectTimeout = 3000;
			}
			if (Headers == true)
			{
				httpRequest.AddHeader(header, value);
			}
			httpRequest.IgnoreProtocolErrors = true;
			httpRequest.AllowAutoRedirect = true;
			if (userAgent != null)
			{
				httpRequest.UserAgent = userAgent;
			}
			return httpRequest.Get(url).ToString();
		}

		public static void Start(MethodInvoker method)
		{
			st.Start();
			for (int i = 1; i <= Variables.Threads; i++)
			{
				new Thread(method.Invoke).Start();
			}
		}

		public static string GetElapsed()
		{
			return st.Elapsed.ToString("dd\\:hh\\:mm\\:ss");
		}

		public static void Print_Logo()
		{
			System.Console.WriteLine("");
			Colorful.Console.WriteLine(" ██░ ██  ▄▄▄        ██████  ██░ ██  ██ ▄█▀ ██▓ ██▓     ██▓    ▓█████  ██▀███      ▄▄▄       ██▓ ▒█████  ", Color.BlueViolet);
			Colorful.Console.WriteLine("▓██░ ██▒▒████▄    ▒██    ▒ ▓██░ ██▒ ██▄█▒ ▓██▒▓██▒    ▓██▒    ▓█   ▀ ▓██ ▒ ██▒   ▒████▄    ▓██▒▒██▒  ██▒", Color.BlueViolet);
			Colorful.Console.WriteLine("▒██▀▀██░▒██  ▀█▄  ░ ▓██▄   ▒██▀▀██░▓███▄░ ▒██▒▒██░    ▒██░    ▒███   ▓██ ░▄█ ▒   ▒██  ▀█▄  ▒██▒▒██░  ██▒    hashkiller#5141", Color.BlueViolet);
			Colorful.Console.WriteLine("░▓█ ░██ ░██▄▄▄▄██   ▒   ██▒░▓█ ░██ ▓██ █▄ ░██░▒██░    ▒██░    ▒▓█  ▄ ▒██▀▀█▄     ░██▄▄▄▄██ ░██░▒██   ██░", Color.BlueViolet);
			Colorful.Console.WriteLine("░▓█▒░██▓ ▓█   ▓██▒▒██████▒▒░▓█▒░██▓▒██▒ █▄░██░░██████▒░██████▒░▒████▒░██▓ ▒██▒    ▓█   ▓██▒░██░░ ████▓▒░", Color.BlueViolet);
			Colorful.Console.WriteLine(" ▒ ░░▒░▒ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░ ▒ ░░▒░▒▒ ▒▒ ▓▒░▓  ░ ▒░▓  ░░ ▒░▓  ░░░ ▒░ ░░ ▒▓ ░▒▓░    ▒▒   ▓▒█░░▓  ░ ▒░▒░▒░ ", Color.BlueViolet);
			Colorful.Console.WriteLine(" ▒ ░▒░ ░  ▒   ▒▒ ░░ ░▒  ░ ░ ▒ ░▒░ ░░ ░▒ ▒░ ▒ ░░ ░ ▒  ░░ ░ ▒  ░ ░ ░  ░  ░▒ ░ ▒░     ▒   ▒▒ ░ ▒ ░  ░ ▒ ▒░ ", Color.BlueViolet);
			Colorful.Console.WriteLine(" ░  ░░ ░  ░   ▒   ░  ░  ░   ░  ░░ ░░ ░░ ░  ▒ ░  ░ ░     ░ ░      ░     ░░   ░      ░   ▒    ▒ ░░ ░ ░ ▒  ", Color.BlueViolet);
			Colorful.Console.WriteLine(" ░  ░  ░      ░  ░      ░   ░  ░  ░░  ░    ░      ░  ░    ░  ░   ░  ░   ░              ░  ░ ░      ░ ░  ", Color.BlueViolet);
			System.Console.WriteLine("");
		}
	}
}
 