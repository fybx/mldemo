using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Threading;

namespace mltoolcli
{
    internal static class Program
    {
        private static double[] ModelContent;
        private static string ModelName;
        private static string ModelPath;
        
        private static string DatasetName;
        private static string DatasetPath;
        private static int[] DatasetContent;
        
        private static void Main(string[] args)
        {
            if (args.Length is 0)
            {
                PrintHelp("help");
                return;
            }

            switch (args[0])
            {
                case "help":
                        PrintHelp("help");
                    break;
                
                case "new":
                    if (args.Length is 3)
                    {
                        switch (args[1])
                        {
                            case @"model":
                                string modelPath =  $"{AppContext.BaseDirectory}{(args[2].EndsWith(".model") ? args[2] : $"{args[2]}.model")}";
                                File.Create(modelPath).Close();
                                CallScript(@"newmodel", modelPath);
                                break;
                            
                            case @"dataset":
                                string datasetPath = $"{AppContext.BaseDirectory}{(args[2].EndsWith(".dataset") ? args[2] : $"{args[2]}.dataset")}";
                                File.Create(datasetPath).Close();
                                CallScript(@"newdataset", datasetPath);
                                break;
                            
                            default:
                                PrintHelp("new");
                                break;
                        }
                    }
                    else
                        PrintHelp("new");
                    break;

                case "eval":
                    if (args.Length is 2 && double.TryParse(args[1], out double numberInput))
                        Calculate(numberInput);
                    else
                        PrintHelp("eval");
                    break;
                
                case "train":
                    if (args.Length is 1 && DatasetName is not null && DatasetContent is not null && ModelName is not null && ModelContent is not null)
                        CallScript("trainmodel", $"{DatasetPath} {ModelPath}");
                    break;
                
                case "load":
                    if (args.Length is 2)
                    {
                        if (!File.Exists(args[1]))
                            Console.WriteLine("mltool: [HATA] Dosya bulunamadı veya açılamıyor.");
                        else
                            ValidateFile(args[1]);
                    }
                    break;

                default:
                    Console.WriteLine("mltool: '{0}' geçerli bir komut değil", args[0]);
                    break;
            }
        }

        /// <summary>
        /// Calls python script from "pyscripts" folder in base directory of running program
        /// </summary>
        /// <param name="scriptName">Name of needed script</param>
        /// <param name="additionalArgs">Any additional arguments, these will be concatenated to script path</param>
        /// <exception cref="FileNotFoundException">May throw this exception if script file is not found</exception>
        /// <exception cref="NotImplementedException"></exception>
        private static void CallScript(string scriptName, string additionalArgs)
        {
            Thread.Sleep(500);
            
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
            
            Thread.Sleep(500);
        }

        private static void Calculate(double number)
        {
            if (ModelContent is null || ModelName is null)
                Console.WriteLine("mltool: [HATA] Model ismi veya model içeriği bulunamadı. Modeli 'load' komutu ile yüklediğinize emin misiniz?");
            else
            {
                double result = 0;
                for (int i = 0; i < 6; i++)
                    result += ModelContent[i] * Math.Pow(number, 5 - i);
                Console.WriteLine($@"{ModelName}({number}) = {result}");
            }
        }

        private static void ValidateFile(string path)
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            switch (lines.Count)
            {
                case 8 when lines[0] is @"mltool modeli":
                    ModelPath = path;
                    ModelName = lines[1];
                    ModelContent = new double[6];
                    for (int i = 2; i < 8; i++)
                        ModelContent[i - 2] = double.Parse(lines[i]);
                    break;
                
                case 66 when lines[0] is @"mltool veri seti":
                    DatasetPath = path;
                    DatasetName = lines[1];
                    DatasetContent = new int[64];
                    for (int j = 2; j < 66; j++)
                        DatasetContent[j - 2] = int.Parse(lines[j]);
                    break;
                
                default:
                    Console.WriteLine($"mltool: [HATA] '{path}' dosyası tanınamadı.");
                    break;
            }
        }
        
        private static void PrintHelp(string command)
        {
            switch (command)
            {
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
                    break;
                
                case "new":
                    Console.WriteLine(@"mltool new:");
                    Console.WriteLine(TurkishStrings.Syntax_New0);
                    Console.WriteLine(TurkishStrings.Syntax_New1);
                    Console.WriteLine(TurkishStrings.Syntax_New2);
                    break;
                
                case "eval":
                    Console.WriteLine(@"mltool eval:");
                    Console.WriteLine(TurkishStrings.Syntax_Eval0);
                    Console.WriteLine(TurkishStrings.Syntax_Eval1);
                    break;
                
                case "train":
                    Console.WriteLine(@"mltool train:");
                    Console.WriteLine(TurkishStrings.Syntax_Train0);
                    Console.WriteLine(TurkishStrings.Syntax_Train1);
                    break;
                
                case "load":
                    Console.WriteLine(@"mltool load:");
                    Console.WriteLine(TurkishStrings.Syntax_Load0);
                    Console.WriteLine(TurkishStrings.Syntax_Load1);
                    Console.WriteLine(TurkishStrings.Syntax_Load2);
                    break;
            }
        }
    }
}