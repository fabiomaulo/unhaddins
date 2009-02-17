using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace uNhAddIns.UserTypes
{
	public class uNHAddinsEncryptor : IEncryptor
	{
		private readonly SymmetricAlgorithm cryptoProvider;
		private byte[] bytes;
		private string encriptionKey;

		public uNHAddinsEncryptor()
		{
			cryptoProvider = new DESCryptoServiceProvider();
			EncriptionKey = "uNHAddin";
		}

		public string EncriptionKey
		{
			get { return encriptionKey; } 
			set
			{
				bytes = Encoding.ASCII.GetBytes(value);
				encriptionKey = value;
			}
		}

		public string Encrypt(string password)
		{
			using (var memoryStream = new MemoryStream())
			{
				ICryptoTransform encryptor = cryptoProvider.CreateEncryptor(bytes, bytes);
				using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
				{
					using (var writer = new StreamWriter(cryptoStream))
					{
						writer.Write(password);
						writer.Flush();
						cryptoStream.FlushFinalBlock();
						return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
					}
				}
			}
		}

		public string Decrypt(string encryptedPassword)
		{
			using (var memoryStream = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
			{
				ICryptoTransform decryptor = cryptoProvider.CreateDecryptor(bytes, bytes);
				using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
				{
					using (var reader = new StreamReader(cryptoStream))
					{
						return reader.ReadToEnd();
					}
				}
			}
		}

	}
}
