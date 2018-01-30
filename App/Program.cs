using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = 0;
            for (int i = 10 - 1; i >= 0; i--)
            {
                for (int j = 0; j < 5; j++)
                {
                    count++;
                }
            }
           
            Console.WriteLine(count);
            Console.ReadKey(); 
        }


    }


}
