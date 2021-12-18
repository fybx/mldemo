using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
// ReSharper disable HeapView.ObjectAllocation.Evident

// ReSharper disable once IdentifierTypo
namespace mltoolcli
{
    internal static class Program
    {
        private static int[] _datasetContent;
        private static string _modelName;
        private static double[] _modelContent;

        private static int Main(string[] args)
        {
            if (args.Length is 0)
            {
                PrintHelp("help");
                return 0;
            }

            switch (args[0])
            {
                case "help":
                        PrintHelp("help");
                        return 0;
                
                case "new":
                    if (args.Length is 3 && args[1] is "model" or "dataset")
                    {
                        string path = (args[1] is @"model"
                            ? args[2].EndsWith(".model") ? args[2] : $"{args[2]}.model"
                            : args[2].EndsWith(".dataset") ? args[2] : $"{args[2]}.dataset").Insert(0, AppContext.BaseDirectory);
                        string script = args[1] is @"model" ? @"newmodel" : @"newdataset";
                        File.Create(path).Close();
                        int statusCode = CallScript(script, path);
                        return statusCode is 0 ? CheckFile(path) : statusCode;
                    }
                    else
                        PrintHelp("new");
                    break;

                case "eval":
                    if (args.Length is 3 && ValidateFile(args[1]) is 0 && double.TryParse(args[2], out double numberInput))
                        Calculate(numberInput);
                    else
                        PrintHelp("eval");
                    break;
                
                case "train":
                    // ReSharper disable once ConvertIfStatementToSwitchStatement
                    if (args.Length is 3 && ValidateFile(args[1]) is 0 && ValidateFile(args[2]) is 0)
                        return CallScript("trainmodel", $"{args[1]} {args[2]}");
                    else
                        PrintHelp("train");
                    break;

                default:
                    return ErrorMessage("ErrMsg_DefaultStatement");
            }

            return 0;
        }

        /// <summary>
        /// Calls python script from "pyscripts" folder in base directory of running program
        /// </summary>
        /// <param name="scriptName">Name of needed script, do not append *.py extension</param>
        /// <param name="additionalArgs">Any additional arguments, these will be concatenated to script path</param>
        private static int CallScript(string scriptName, string additionalArgs)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "pyscripts", $"{scriptName}.py");
            string arguments = $"{path} {additionalArgs}";
            
            if (File.Exists(path) is false)
                ErrorMessage(TurkishStrings.ExcpMsg_ScriptNotFound, path);


            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Process.Start(new ProcessStartInfo { FileName = "python", Arguments = arguments });
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                Process.Start(new ProcessStartInfo { FileName = "python3", Arguments = arguments });
            else
                ErrorMessage("ErrMsg_UnsupportedPlatform");

            Thread.Sleep(1000);
            return 0;
        }

        private static int CheckFile(string path) => File.ReadAllLines(path)[0] is "mltool modeli" or "mltool veri seti" ? 0 : ErrorMessage("ErrMsg_FileNotValid");

        private static int ErrorMessage(string errorName, string additionalMessage = "")
        {
            // ReSharper disable once LocalizableElement
            Console.WriteLine(TurkishStrings.ResourceManager.GetString(errorName), additionalMessage);
            return errorName switch
            {
                "ErrMsg_Calculate0" => -1001,
                "ErrMsg_DefaultStatement" => -1002,
                "ErrMsg_Load0"  => -1003,
                "ErrMsg_Train0" => -1004,
                "ErrMsg_ValidateFile0" => -1005,
                "ExcpMsg_ScriptNotFound" => -1006,
                "ErrMsg_UnsupportedPlatform" => -1007,
                _ => 0
            };
        }
        
        private static void Calculate(double number)
        {
            if (_modelContent is null || _modelName is null)
                Console.WriteLine(TurkishStrings.ErrMsg_Calculate0);
            else
            {
                double result = 0;
                for (int i = 0; i < 6; i++)
                    result += _modelContent[i] * Math.Pow(number, 5 - i);
                // ReSharper disable once HeapView.BoxingAllocation
                Console.WriteLine($@"{_modelName}({number}) = {result}");
            }
        }

        private static int ValidateFile(string path)
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            switch (lines.Count)
            {
                case 8 when lines[0] is @"mltool modeli":
                    _modelContent = new double[6];
                    _modelName = lines[1];
                    for (int i = 2; i < 8; i++)
                        _modelContent[i - 2] = double.Parse(lines[i]);
                    return 0;
                
                case 66 when lines[0] is @"mltool veri seti":
                    _datasetContent = new int[64];
                    for (int j = 2; j < 66; j++)
                        _datasetContent[j - 2] = int.Parse(lines[j]);
                    return 0;
                
                default:
                    Console.WriteLine(TurkishStrings.ErrMsg_ValidateFile0, path);
                    return 1;
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
                    Console.WriteLine(TurkishStrings.HelpMsg_Help);
                    Console.WriteLine(TurkishStrings.HelpMsg_New);
                    Console.WriteLine(TurkishStrings.HelpMsg_Train);
                    Console.WriteLine(TurkishStrings.HelpMsg_Eval);
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
            }
        }
    }
}