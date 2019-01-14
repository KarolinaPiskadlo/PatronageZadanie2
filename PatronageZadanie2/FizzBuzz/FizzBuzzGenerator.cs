﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PatronageZadanie2.FizzBuzz
{
    public class FizzBuzzGenerator
    {
        private const int MinRange = 0;
        private const int MaxRange = 1000;

        /// <summary>
        /// Take a numerical parameter and then return "Fizz" if divided by 2,
        /// "Buzz" if divided by 3, "FizzBuzz" if divided by both.
        /// </summary>
        public string FizzBuzz(string number)
        {
            bool isDivisible = false;
            string returnString = "";
            int result = int.Parse(number);
            
            if (!IsInRange(result))
            {
                return "Podana wartość nie mieści się w przedziale od 0 do 1000.";
            }

            if (result % 2 == 0)
            {
                returnString = "Fizz";
                isDivisible = true;
            }

            if (result % 3 == 0)
            {
                returnString += "Buzz";
                isDivisible = true;
            }

            if (isDivisible == false)
            {
                returnString = "Podana liczba nie jest podzielna ani przez 2, ani przez 3.";
            }

            return returnString;
        }

        private bool IsInRange(int number)
        {
            if (number >= MinRange && number <= MaxRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
