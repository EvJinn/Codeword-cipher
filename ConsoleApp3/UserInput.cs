using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    public class UserInput
    {
        public static bool inputCheck(string input) //Проверка ввода
        {
            bool flag = false; //Флаг проверки

            for (int i = 0; i < input.Length; i++) //Сравниваем символы полученного текста и алфавита шифра
            {
                for (int j = 0; j < cipher.firstAlphabet.Count(); j++)
                {
                    if (input[i] == ' ') continue; //Пробелы просто пропускаем (если они есть)
                    if (input[i] == cipher.firstAlphabet.ElementAt(j)) flag = true; //Символ найден - поднимаем флаг
                }
                if (flag == false) break; //Если символа нет - выходим из цикла
            }

            return flag; //Возвращаем флаг
        }
        public static bool inputCheck(string n, int type) //Проверка ввода для выбора меню. Ужасный костыль
        {
            bool flag;
            uint check;

            flag = UInt32.TryParse(n, out check); //Проверяем полученную строку на возможность приедение к uint
            if (flag == true) //если можно, то сравниваем с нужными нам значениями
                if (check != 1 && check != 2) flag = false;

            return flag; //Возвращаем флаг
        }

    }
}
