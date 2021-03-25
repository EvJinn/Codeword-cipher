using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кодовое слово:");
            string codeWord = Console.ReadLine();

            cipher cipher = new cipher(codeWord);

            Console.WriteLine(string.Join('\0', cipher.firstAlphabet));
            Console.WriteLine(string.Join('\0', cipher.secondAlphabet));

            Console.WriteLine("Что делаем?: \n" +
                                "1. Шифруем \n" +
                                "2. Дешифруем \n");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите текст:");
            
            switch (n)
            {
                case 1:
                    {
                        string text = Console.ReadLine();

                        string cipherText = cipher.encode(text);
                        Console.WriteLine(cipherText);
                    }
                    break;
                case 2:
                    {
                        string cipherText = Console.ReadLine();

                        string decodedText = cipher.decode(cipherText);
                        Console.WriteLine(decodedText);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
