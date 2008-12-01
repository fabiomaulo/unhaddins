using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace uNhAddIns.UserTypes
{
	public class EncryptionHelper
	{
		private readonly SymmetricAlgorithm cryptoProvider;

		public EncryptionHelper()
		{
			this.cryptoProvider = new DESCryptoServiceProvider();
		}
		
		public EncryptionHelper(SymmetricAlgorithm cryptoProvider)
		{
			this.cryptoProvider = cryptoProvider;
		}

		private readonly byte[] bytes = Encoding.ASCII.GetBytes("uNHAddin");

		public string Encrypt(string password)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ICryptoTransform encryptor = cryptoProvider.CreateEncryptor(bytes, bytes);
				using (CryptoStream cryptoStream =
					new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
				{
					using (StreamWriter writer = new StreamWriter(cryptoStream))
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
			using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
			{
				ICryptoTransform decryptor = cryptoProvider.CreateDecryptor(bytes, bytes);
				using (CryptoStream cryptoStream =
					new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
				{
					using (StreamReader reader = new StreamReader(cryptoStream))
					{
						return reader.ReadToEnd();
					}
				}
			}
		}
	}
}
