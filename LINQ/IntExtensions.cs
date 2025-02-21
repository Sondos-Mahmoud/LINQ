using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal static class IntExtensions
    {
        public static int Reverse(this int number) // 123
        {
            int reversedNumber = 0 , remainder;
            while(number !=0)
            {
                remainder = number % 10; //  1%10 = 1

                reversedNumber = reversedNumber *10 + remainder; // 32*10 = 320 +1 = 321 
                number = number / 10; //  1/10 = 0 
            }
            return reversedNumber; // 321
        }
        public static long Reverse(this long number) // 123
        {
            long reversedNumber = 0, remainder;
            while (number != 0)
            {
                remainder = number % 10; //  1%10 = 1

                reversedNumber = reversedNumber * 10 + remainder; // 32*10 = 320 +1 = 321 
                number = number / 10; //  1/10 = 0 
            }
            return reversedNumber; // 321
        }
    }
}
