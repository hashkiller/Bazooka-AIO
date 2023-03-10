using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace TPS
{
	internal class OnProgramStart
	{
		public static string AID = null;

		public static string Secret = null;

		public static string Version = null;

		public static string Name = null;

		public static string Salt = null;

		public static void Initialize(string name, string aid, string secret, string version)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(aid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
			{
				MessageBox.Show("Invalid application information!", Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			AID = aid;
			Secret = secret;
			Version = version;
			Name = name;
			Array array = new string[0];
			WebClient webClient = new WebClient();
			webClient.Proxy = null;
			Security.Start();
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(Secret),
				["type"] = Encryption.APIService("start")
			}))).Split("|".ToCharArray());
			if (Security.MaliciousCheck((string)((object[])array)[1]))
			{
				MessageBox.Show("Possible malicious activity detected!", Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Possible malicious activity detected!", Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			if ((string)((object[])array)[0] != Constants.Token)
			{
				MessageBox.Show("Security error has been triggered!", Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			switch ((string)((object[])array)[2])
			{
			case "banned":
				MessageBox.Show("This application has been banned for violating the TOS" + Environment.NewLine + "Contact us at support@auth.gg", Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
				return;
			case "binderror":
				MessageBox.Show(Encryption.Decode("RmFpbGVkIHRvIGJpbmQgdG8gc2VydmVyLCBjaGVjayB5b3VyIEFJRCAmIFNlY3JldCBpbiB5b3VyIGNvZGUh"), Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
				return;
			case "success":
				Constants.Initialized = true;
				if ((string)((object[])array)[3] == "Enabled")
				{
					ApplicationSettings.Status = true;
				}
				if ((string)((object[])array)[4] == "Enabled")
				{
					ApplicationSettings.DeveloperMode = true;
				}
				ApplicationSettings.Hash = (string)((object[])array)[5];
				ApplicationSettings.Version = (string)((object[])array)[6];
				ApplicationSettings.Update_Link = (string)((object[])array)[7];
				if ((string)((object[])array)[8] == "Enabled")
				{
					ApplicationSettings.Freemode = true;
				}
				if ((string)((object[])array)[9] == "Enabled")
				{
					ApplicationSettings.Login = true;
				}
				ApplicationSettings.Name = (string)((object[])array)[10];
				if ((string)((object[])array)[11] == "Enabled")
				{
					ApplicationSettings.Register = true;
				}
				if (ApplicationSettings.DeveloperMode)
				{
					MessageBox.Show("Application is in Developer Mode, bypassing integrity and update check!", Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					File.Create(Environment.CurrentDirectory + "/integrity.log").Close();
					string contents = Security.Integrity(Process.GetCurrentProcess().MainModule.FileName);
					File.WriteAllText(Environment.CurrentDirectory + "/integrity.log", contents);
					MessageBox.Show("Your applications hash has been saved to integrity.txt, please refer to this when your application is ready for release!", Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				else
				{
					if (ApplicationSettings.Version != Version)
					{
						MessageBox.Show("Update " + ApplicationSettings.Version + " available, redirecting to update!", Name, MessageBoxButton.OK, MessageBoxImage.Hand);
						Process.Start(ApplicationSettings.Update_Link);
						Process.GetCurrentProcess().Kill();
					}
					if ((string)((object[])array)[12] == "Enabled" && ApplicationSettings.Hash != Security.Integrity(Process.GetCurrentProcess().MainModule.FileName))
					{
						MessageBox.Show("File has been tampered with, couldn't verify integrity!", Name, MessageBoxButton.OK, MessageBoxImage.Hand);
						Process.GetCurrentProcess().Kill();
					}
				}
				if (!ApplicationSettings.Status)
				{
					MessageBox.Show("Looks like this application is disabled, please try again later!", Name, MessageBoxButton.OK, MessageBoxImage.Hand);
					Process.GetCurrentProcess().Kill();
				}
				break;
			}
			Security.End();
		}
	}
}
