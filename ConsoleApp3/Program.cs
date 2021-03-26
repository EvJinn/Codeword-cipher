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

            codeWord = codeWord.ToLower().Replace(" ", "");
            while (!UserInput.inputCheck(codeWord)) //Проверка введёного текста на соответствие алфавиту шифра
            {
                Console.WriteLine("Ошибка ввода. Повторите попытку!");
                codeWord = Console.ReadLine();
                codeWord = codeWord.Replace(" ", ""); //Убираем все пробелы из вводимого текста (защита от дурака)
            }

            cipher cipher = new cipher(codeWord); //Объект с которым будем работать. Конструктор сразу создаёт шифруемый алфавит

            Console.WriteLine('\n' + string.Join("", cipher.firstAlphabet));  //Выводим первоначальный алфавит
            Console.WriteLine(string.Join("", cipher.secondAlphabet));        //Выводим шифруемый алфавит

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
            
            switch (n) //Выбор пунктов меню
            {
                case 1:
                    {
                        string text = Console.ReadLine().ToLower(); //При считывании преобразуем всю строку в нижний регистр

                        while (!UserInput.inputCheck(text)) //Проверка введёного текста на соответствие алфавиту шифра
                        {
                            Console.WriteLine("Ошибка ввода. Повторите попытку!");
                            text = Console.ReadLine();
                        }

                        string cipherText = cipher.encode(text); //Кодируем
                        Console.WriteLine(cipherText); //Выводим результат
                    }
                    break;
                case 2:
                    { //Всё то же самое
                        string cipherText = Console.ReadLine().ToLower(); 

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
