using System;

namespace mltoolcli
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                Console.Title = @"user@mltool";
                Console.Write("user@mltool: ");
                quit = KomutIsle(Console.ReadLine()?.Trim().Split(' '));
            }
        }

        private static bool KomutIsle(string[] tokens)
        {
            switch (tokens[0])
            {
                case "help":
                    Console.WriteLine("\nmltool cli v0010");
                    Console.WriteLine("exit                : CLI'ten çıkar");
                    Console.WriteLine("help                : Bu mesajı gösterir");
                    Console.WriteLine("train               : Yüklü olan eğitim veri setini kullanarak yüklü olan modeli eğitir.");
                    Console.WriteLine("test                : Yüklü olan test veri setini kullanarak yüklü olan modeli test eder.");
                    Console.WriteLine("load <model/dataset>: Model veya veri setini train/test aşamasında kullanılmak üzere programa yükler.");
                    Console.WriteLine("new <model/dataset> : Yeni bir model veya veri seti dosyası oluşturur. Dosya programın çalıştırıldığı yolda konumlandırılacaktır.");
                    break;
                
                case "exit":
                    return true;
                
                case "default":
                    Console.WriteLine(@"mltool: ""{0}"" geçerli bir komut değil", tokens[0]);
                    break;
            }

            return false;
        }
    }
}