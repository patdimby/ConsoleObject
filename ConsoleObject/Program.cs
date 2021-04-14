using System;
using System.Security;

namespace ConsoleObject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GrcEntite source = new GrcEntite()
            {
                Id = 1,
                RAISON = "Nom"
            };
            
            GrcEntite dest = new GrcEntite()
            {
               SIREN = "0000000",EMAIL = "mailto@mg.fr"
            };
            ObjectExtensions.BuiltInCast(dest, source);
            Console.WriteLine(dest);
        }
    }
}