using System;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;

namespace mltoolcli
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length is not 0)
                KomutIsle(args);
            else
            {
                bool quit = false;
                while (!quit)
                {
                    Console.Title = @"user@mltool";
                    Console.Write("user@mltool: ");
                    quit = KomutIsle(Console.ReadLine()?.Trim().Split(' '));
                }   
            }
        }

        private static bool KomutIsle(string[] tokens)
        {
            switch (tokens[0])
            {
                case "exit":
                    return true;
                
                case "help":
                    Console.WriteLine(TurkishStrings.Version);
                    Console.WriteLine(TurkishStrings.HelpMsg_Usage);
                    Console.WriteLine('\n' + TurkishStrings.HelpMsg_ListName);
                    Console.WriteLine(TurkishStrings.HelpMsg_Exit);
                    Console.WriteLine(TurkishStrings.HelpMsg_Help);
                    Console.WriteLine(TurkishStrings.HelpMsg_New);
                    Console.WriteLine(TurkishStrings.HelpMsg_Test);
                    Console.WriteLine(TurkishStrings.HelpMsg_Train);
                    Console.WriteLine(TurkishStrings.HelpMsg_Load);
                    Console.WriteLine('\n' + TurkishStrings.HelpMsg_Info);
                    return false;
                
                case "new":
                    return false;
                
                case "eval":
                    return false;
                
                case "train":
                    return false;
                
                case "load":
                    return false;

                default:
                    Console.WriteLine(@"mltool: '{0}' geçerli bir komut değil", tokens[0]);
                    return false;
            }
        }

        private static void ScriptCagir(string scriptName)
        {
            if (!File.Exists(AppContext.BaseDirectory + scriptName))
                throw new FileNotFoundException(TurkishStrings.ExcpMsg_ScriptNotFound, AppContext.BaseDirectory + scriptName);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                ProcessStartInfo info = new() { FileName = "python3", Arguments = AppContext.BaseDirectory + $"{scriptName}.py" };
                Process prc = new() { StartInfo = info };
                prc.Start();   
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new NotImplementedException();
            }
            else
            {
                Console.WriteLine(@"mltool: Ewww");
            }
        }
    }
}