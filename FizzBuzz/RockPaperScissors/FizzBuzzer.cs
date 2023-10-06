using System;
using System.Collections.Generic;

namespace FizzBuzz
{

    //this is the production code
    public class FizzBuzzer
    {

        public int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        public object Go(int v)
        {
            string str = "";

            if(v%3 == 0)
            {
                str = str + "Fizz";
            }

            if(v%5 == 0)
            {
                str = str + "Buzz";
            }

            if (primes.Contains(v))
            {
                str = str + "Whizz";
            }

            if (str == "")
            {
                return v;
            }

            return str;
        }
    }

}
