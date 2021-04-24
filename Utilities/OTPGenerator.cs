using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Utilities
{
    public static class OTPGenerator
    {
        public static string Generate4DigitOTP(byte digits)
        {
            return GetRandomNumber(digits);
        }

        private static string GetRandomNumber(byte numberOfDigit)
        {
            int minNumber = 1111;
            int maxNumber = 9999999;

            maxNumber = numberOfDigit switch
            {
                4 => 9999,
                _ => 1,
            };
            return new Random().Next(minNumber,maxNumber).ToString();
        }
    }
}
