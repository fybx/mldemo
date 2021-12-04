using System;

namespace mltoolcli
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                Console.Title = @"user@mltool";
                Console.WriteLine("user@mltool: ");
                string[] tokens = Console.ReadLine()?.Trim().Split(' ');
                quit = KomutIsle(tokens);
            }
        }

        static bool KomutIsle(string[] tokens)
        {
            throw new NotImplementedException();
        }
    }
}