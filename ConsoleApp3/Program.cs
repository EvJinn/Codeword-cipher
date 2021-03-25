using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кодовое слово на киррилице:");
            string codeWord = Console.ReadLine();

            codeWord = codeWord.Replace(" ", "");
            while (!UserInput.inputCheck(codeWord))
            {
                Console.WriteLine("Ошибка ввода. Повторите попытку!");
                codeWord = Console.ReadLine();
                codeWord = codeWord.Replace(" ", "");
            }

            cipher cipher = new cipher(codeWord);

            Console.WriteLine('\n' + string.Join('\0', cipher.firstAlphabet));
            Console.WriteLine(string.Join('\0', cipher.secondAlphabet));

            Console.WriteLine(  "\nЧто делаем?: \n" +
                                "1. Шифруем \n" +
                                "2. Дешифруем \n");
            
            //ужасный костыль, не смотрите сюда
            string a = Console.ReadLine();
            while (!UserInput.inputCheck(a, 0))
            {
                Console.WriteLine("Ошибка ввода. Повторите попытку!");
                a = Console.ReadLine();
            }
            uint n = Convert.ToUInt32(a);

            Console.WriteLine("\nВведите текст:");
            
            switch (n)
            {
                case 1:
                    {
                        string text = Console.ReadLine();

                        while (!UserInput.inputCheck(text))
                        {
                            Console.WriteLine("Ошибка ввода. Повторите попытку!");
                            text = Console.ReadLine();
                        }

                        string cipherText = cipher.encode(text);
                        Console.WriteLine(cipherText);
                    }
                    break;
                case 2:
                    {
                        string cipherText = Console.ReadLine();

                        while (!UserInput.inputCheck(cipherText))
                        {
                            Console.WriteLine("Ошибка ввода. Повторите попытку!");
                            cipherText = Console.ReadLine();
                        }

                        string decodedText = cipher.decode(cipherText);
                        Console.WriteLine(decodedText);
                    }
                    break;
            }
        }
    }
}
