using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp3
{
    public class cipher
    {
        public static readonly IEnumerable<char> firstAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray().AsEnumerable(); //Исходный алфавит
        public readonly IEnumerable<char> secondAlphabet; //Алфавит шифра

        public cipher(string codeWord)
        {
            var x = codeWord.Distinct(); //Убираем из кодового слова все повторяющиеся символы
            secondAlphabet = x.Concat(firstAlphabet).Distinct(); //кодовое слово + исходный алфавит и убираем повторения
        }

        public string encode(string text) //Кодируем
        {
            var cipherText = new List<char>(); //Список для создания зашифрованного текста
            for (int i = 0; i < text.Length; i++)
            { //Находим индекс буквы из текста в исходном алфавите и добавляем в список букву с тем же индексом в шифруемом алфавите
                for (int j = 0; j < firstAlphabet.Count(); j++)
                    if (text[i] == firstAlphabet.ElementAt(j)) cipherText.Add(secondAlphabet.ElementAt(j)); 
                if (text[i] == ' ') cipherText.Add(' '); //Пробелы просто добавляем в список
            }

            return string.Join("", cipherText); //Возвращаем результат в виде строки
        }

        public string decode(string cipherText) //Декодируем. Принцип тот же самый что у кодировки, только проходим алфавиты в обратном порядке
        {
            var decodedText = new List<char>();
            for (int i = 0; i < cipherText.Length; i++)
            {
                for (int j = 0; j < secondAlphabet.Count(); j++)
                    if (cipherText[i] == secondAlphabet.ElementAt(j)) decodedText.Add(firstAlphabet.ElementAt(j));
                if (cipherText[i] == ' ') decodedText.Add(' ');
            }

            return string.Join("", decodedText);
        }
    }
}
