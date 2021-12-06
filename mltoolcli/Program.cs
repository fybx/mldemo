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
                    if (tokens.Length is 3)
                    {
                        switch (tokens[1])
                        {
                            case @"model":
                                string modelloc = AppContext.BaseDirectory + (tokens[2].EndsWith(".model") ? tokens[2] : tokens[2] + ".model");
                                File.Create(modelloc).Close();
                                ScriptCagir(@"newmodel", modelloc);
                                break;
                            
                            case @"dataset":
                                string datasetloc = AppContext.BaseDirectory + (tokens[2].EndsWith(".dataset") ? tokens[2] : tokens[2] + ".dataset");
                                File.Create(datasetloc).Close();
                                ScriptCagir(@"newdataset", datasetloc);
                                break;
                            
                            default:
                                SyntaxMesaji("new");
                                break;
                        }
                    }
                    else
                        SyntaxMesaji("new");

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

        /// <summary>
        /// Calls python script from "pyscripts" folder in base directory of running program
        /// </summary>
        /// <param name="scriptName">Name of needed script</param>
        /// <param name="additionalArgs">Any additional arguments, these will be concatenated to script path</param>
        /// <exception cref="FileNotFoundException">May throw this exception if script file is not found</exception>
        /// <exception cref="NotImplementedException"></exception>
        private static void ScriptCagir(string scriptName, string additionalArgs)
        {
            if (!File.Exists($"{AppContext.BaseDirectory}pyscripts/{scriptName}.py") && !File.Exists(AppContext.BaseDirectory + $"pyscripts\\{scriptName}.py"))
                throw new FileNotFoundException(TurkishStrings.ExcpMsg_ScriptNotFound, AppContext.BaseDirectory + scriptName);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                ProcessStartInfo info = new() { FileName = "python3", Arguments = $"{AppContext.BaseDirectory}pyscripts/{scriptName}.py {additionalArgs}" };
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

        private static void SyntaxMesaji(string command)
        {
            switch (command)
            {
                case "new":
                    Console.WriteLine(@"mltool new:");
                    Console.WriteLine(TurkishStrings.Syntax_New0);
                    Console.WriteLine(TurkishStrings.Syntax_New1);
                    Console.WriteLine(TurkishStrings.Syntax_New2);
                    break;
                
                case "eval":
                    break;
                
                case "train":
                    break;
                
                case "load":
                    break;
            }
        }
    }
}