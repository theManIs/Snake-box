using System.Collections.Generic;


namespace ExampleTemplate
{
    public sealed class CaesarCipher : ICipher
    {
        private List<string> _alphabet;
        
        public CaesarCipher()
        { 
            _alphabet.Add("abcdefghijklmnopqrstuvwxyz");
            _alphabet.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            _alphabet.Add("абвгдеёжзийклмнопрстуфхцчшщъыьэюя");
            _alphabet.Add("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");
            _alphabet.Add("0123456789");
            _alphabet.Add("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}");
        }
    }
}
