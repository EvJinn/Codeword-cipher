using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp3
{
    public class cipher
    {
        public static readonly IEnumerable<char> firstAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray().AsEnumerable();
        public readonly IEnumerable<char> secondAlphabet;

        public cipher(string codeWord)
        {
            var x = codeWord.Distinct();
            secondAlphabet = x.Concat(firstAlphabet).Distinct();
        }

        public string encode(string text)
        {
            var cipherText = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                char symb = text[i];
                for (int j = 0; j < firstAlphabet.Count(); j++)
                    if (symb == firstAlphabet.ElementAt(j)) cipherText.Add(secondAlphabet.ElementAt(j));
                if (symb == ' ') cipherText.Add(' ');
            }

            return string.Join('\0', cipherText);
        }

        public string decode(string cipherText)
        {
            var decodedText = new List<char>();
            for (int i = 0; i < cipherText.Length; i++)
            {
                char symb = cipherText[i];
                for (int j = 0; j < secondAlphabet.Count(); j++)
                    if (symb == secondAlphabet.ElementAt(j)) decodedText.Add(firstAlphabet.ElementAt(j));
                if (symb == ' ') decodedText.Add(' ');
            }

            return string.Join('\0', decodedText);
        }
    }
}
