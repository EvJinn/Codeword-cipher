using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    public class UserInput
    {
        public static bool inputCheck(string input)
        {
            bool flag = false;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < cipher.firstAlphabet.Count(); j++)
                {
                    if (input[i] == ' ') continue;
                    if (input[i] == cipher.firstAlphabet.ElementAt(j)) flag = true;
                }
                if (flag == false) break;
            }

            return flag;
        }
        public static bool inputCheck(string n, int type)
        {
            bool flag;
            uint check;

            flag = UInt32.TryParse(n, out check);
            if (flag == true) 
                if (check != 1 && check != 2) flag = false;

            return flag;
        }

    }
}
