// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

string data = "xjE+QmpfkfGGyqVfdq9Dhw==";
byte[] IV = new byte[] { 0x17, 0x11, 0x15, 0x12, 0x13, 0x14, 0x16, 0x10 };
StringBuilder EncryptKey = new StringBuilder("38212877", 8);

byte[] Key = Encoding.UTF8.GetBytes(EncryptKey.ToString());
byte[] InputByteArray = new byte[data.Length + 1];
DESCryptoServiceProvider Des = new DESCryptoServiceProvider();
System.IO.MemoryStream ms = new System.IO.MemoryStream();
CryptoStream cs = new CryptoStream(ms, Des.CreateDecryptor(Key, IV), CryptoStreamMode.Write);
Encoding Decoding = Encoding.UTF8;
InputByteArray = Convert.FromBase64String(data);
cs.Write(InputByteArray, 0, InputByteArray.Length);
cs.FlushFinalBlock();
 

Console.WriteLine(Decoding.GetString(ms.ToArray()));
