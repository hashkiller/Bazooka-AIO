using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TPS
{
	internal class Encryption
	{
		public static string APIService(string value)
		{
			string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			SHA256 sHA = SHA256.Create();
			Array key = sHA.ComputeHash(Encoding.ASCII.GetBytes(@string));
			Array bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			return EncryptString(value, (byte[])key, (byte[])bytes);
		}

		public static string EncryptService(string value)
		{
			string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			SHA256 sHA = SHA256.Create();
			Array key = sHA.ComputeHash(Encoding.ASCII.GetBytes(@string));
			Array bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			string str = EncryptString(value, (byte[])key, (byte[])bytes);
			int length = int.Parse(OnProgramStart.AID.Substring(0, 2));
			return str + Security.Obfuscate(length);
		}

		public static string DecryptService(string value)
		{
			string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			SHA256 sHA = SHA256.Create();
			Array key = sHA.ComputeHash(Encoding.ASCII.GetBytes(@string));
			Array bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			return DecryptString(value, (byte[])key, (byte[])bytes);
		}

		public static string EncryptString(string plainText, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform transform = aes.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			Array bytes = Encoding.ASCII.GetBytes(plainText);
			cryptoStream.Write((byte[])bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			Array array = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String((byte[])array, 0, array.Length);
		}

		public static string DecryptString(string cipherText, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform transform = aes.CreateDecryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			string empty = string.Empty;
			Array array = Convert.FromBase64String(cipherText);
			cryptoStream.Write((byte[])array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			Array array2 = memoryStream.ToArray();
			return Encoding.ASCII.GetString((byte[])array2, 0, array2.Length);
		}

		public static string Decode(string text)
		{
			text = text.Replace('_', '/').Replace('-', '+');
			switch (text.Length % 4)
			{
			case 3:
				text += "=";
				break;
			case 2:
				text += "==";
				break;
			}
			return Encoding.UTF8.GetString(Convert.FromBase64String(text));
		}
	}
}
