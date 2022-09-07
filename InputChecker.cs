using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17
{
    static class InputChecker
    {
        //static bool Check(T input)
        //{
        //    return input is T;
        //}

        public static bool IsNumber(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        public static string IsValidInput(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid user input\n string must not be empty");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
