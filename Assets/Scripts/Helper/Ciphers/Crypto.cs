using System;


namespace ExampleTemplate
{
	public sealed class Crypto : ICipher
	{
		public string CryptoXOR(string text, int key = 42)
		{
			var result = String.Empty;
			foreach (var simbol in text)
			{
				result += (char)(simbol ^ key);
			}
			return result;
		}
	}
}