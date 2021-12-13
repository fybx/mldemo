// ReSharper disable once IdentifierTypo
namespace mltoolgui;

internal static class Program
{
    [STAThread]
    internal static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}