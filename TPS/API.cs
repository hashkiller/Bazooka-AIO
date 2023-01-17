using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows;

namespace TPS
{
	internal class API
	{
		public static void Log(string username, string action)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(action))
			{
				MessageBox.Show("Missing log information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			WebClient webClient = new WebClient();
			Security.Start();
			webClient.Proxy = null;
			Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["username"] = Encryption.APIService(username),
				["pcuser"] = Encryption.APIService(Environment.UserName),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["data"] = Encryption.APIService(action),
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("log")
			}))).Split("|".ToCharArray());
			Security.End();
		}

		public static bool AIO(string AIO)
		{
			if (AIOLogin(AIO))
			{
				return true;
			}
			if (AIORegister(AIO))
			{
				return true;
			}
			return false;
		}

		public static bool AIOLogin(string AIO)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(AIO))
			{
				MessageBox.Show("Missing user login information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			Array array = new string[0];
			WebClient webClient = new WebClient();
			Security.Start();
			webClient.Proxy = null;
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["username"] = Encryption.APIService(AIO),
				["password"] = Encryption.APIService(AIO),
				["hwid"] = Encryption.APIService(Constants.HWID()),
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("login")
			}))).Split("|".ToCharArray());
			if ((string)((object[])array)[0] != Constants.Token)
			{
				MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck((string)((object[])array)[1]))
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			switch ((string)((object[])array)[2])
			{
			case "invalid_hwid":
				MessageBox.Show("This user is binded to another computer, please contact support!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "hwid_updated":
				MessageBox.Show("New machine has been binded, re-open the application!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "time_expired":
				MessageBox.Show("Your subscription has expired!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "invalid_details":
				Security.End();
				return false;
			case "success":
			{
				Security.End();
				User.ID = (string)((object[])array)[3];
				User.Username = (string)((object[])array)[4];
				User.Password = (string)((object[])array)[5];
				User.Email = (string)((object[])array)[6];
				User.HWID = (string)((object[])array)[7];
				User.UserVariable = (string)((object[])array)[8];
				User.Rank = (string)((object[])array)[9];
				User.IP = (string)((object[])array)[10];
				User.Expiry = (string)((object[])array)[11];
				User.LastLogin = (string)((object[])array)[12];
				User.RegisterDate = (string)((object[])array)[13];
				string text = (string)((object[])array)[14];
				Array array2 = text.Split('~');
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = (string)((object[])array2)[i];
					Array array3 = text2.Split('^');
					App.Variables.Add((string)((object[])array3)[0], (string)((object[])array3)[1]);
				}
				return true;
			}
			default:
				return false;
			}
		}

		public static bool AIORegister(string AIO)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(AIO))
			{
				MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			Array array = new string[0];
			WebClient webClient = new WebClient();
			Security.Start();
			webClient.Proxy = null;
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("register"),
				["username"] = Encryption.APIService(AIO),
				["password"] = Encryption.APIService(AIO),
				["email"] = Encryption.APIService(AIO),
				["license"] = Encryption.APIService(AIO),
				["hwid"] = Encryption.APIService(Constants.HWID())
			}))).Split("|".ToCharArray());
			if ((string)((object[])array)[0] != Constants.Token)
			{
				MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck((string)((object[])array)[1]))
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			Security.End();
			switch ((string)((object[])array)[2])
			{
			case "error":
				return false;
			case "success":
				return true;
			default:
				return false;
			}
		}

		public static bool Login(string username, string password)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Missing user login information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			Array array = new string[0];
			WebClient webClient = new WebClient();
			Security.Start();
			webClient.Proxy = null;
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["username"] = Encryption.APIService(username),
				["password"] = Encryption.APIService(password),
				["hwid"] = Encryption.APIService(Constants.HWID()),
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("login")
			}))).Split("|".ToCharArray());
			if ((string)((object[])array)[0] != Constants.Token)
			{
				MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck((string)((object[])array)[1]))
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			switch ((string)((object[])array)[2])
			{
			case "invalid_hwid":
				MessageBox.Show("This user is binded to another computer, please contact support!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "hwid_updated":
				MessageBox.Show("New machine has been binded, re-open the application!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "time_expired":
				MessageBox.Show("Your subscription has expired!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "invalid_details":
				Security.End();
				return false;
			case "success":
			{
				User.ID = (string)((object[])array)[3];
				User.Username = (string)((object[])array)[4];
				User.Password = (string)((object[])array)[5];
				User.Email = (string)((object[])array)[6];
				User.HWID = (string)((object[])array)[7];
				User.UserVariable = (string)((object[])array)[8];
				User.Rank = (string)((object[])array)[9];
				User.IP = (string)((object[])array)[10];
				User.Expiry = (string)((object[])array)[11];
				User.LastLogin = (string)((object[])array)[12];
				User.RegisterDate = (string)((object[])array)[13];
				string text = (string)((object[])array)[14];
				Array array2 = text.Split('~');
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = (string)((object[])array2)[i];
					Array array3 = text2.Split('^');
					App.Variables.Add((string)((object[])array3)[0], (string)((object[])array3)[1]);
				}
				Security.End();
				return true;
			}
			default:
				return false;
			}
		}

		public static bool Register(string username, string password, string email, string license)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(license))
			{
				MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			Array array = new string[0];
			WebClient webClient = new WebClient();
			Security.Start();
			webClient.Proxy = null;
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("register"),
				["username"] = Encryption.APIService(username),
				["password"] = Encryption.APIService(password),
				["email"] = Encryption.APIService(email),
				["license"] = Encryption.APIService(license),
				["hwid"] = Encryption.APIService(Constants.HWID())
			}))).Split("|".ToCharArray());
			if ((string)((object[])array)[0] != Constants.Token)
			{
				MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck((string)((object[])array)[1]))
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			switch ((string)((object[])array)[2])
			{
			case "invalid_username":
				MessageBox.Show("You entered an invalid/used username!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "email_used":
				MessageBox.Show("Email has already been used!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "invalid_license":
				MessageBox.Show("License does not exist!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "success":
				Security.End();
				return true;
			default:
				return false;
			}
		}

		public static bool ExtendSubscription(string username, string password, string license)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(license))
			{
				MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			Array array = new string[0];
			WebClient webClient = new WebClient();
			Security.Start();
			webClient.Proxy = null;
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("extend"),
				["username"] = Encryption.APIService(username),
				["password"] = Encryption.APIService(password),
				["license"] = Encryption.APIService(license)
			}))).Split("|".ToCharArray());
			if ((string)((object[])array)[0] != Constants.Token)
			{
				MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck((string)((object[])array)[1]))
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
			}
			switch ((string)((object[])array)[2])
			{
			case "invalid_details":
				MessageBox.Show("Your user details are invalid!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "invalid_token":
				MessageBox.Show("Token does not exist!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Security.End();
				Process.GetCurrentProcess().Kill();
				return false;
			case "success":
				Security.End();
				return true;
			default:
				return false;
			}
		}
	}
}
