// ReSharper disable once IdentifierTypo
using System.Diagnostics;

namespace mltoolgui;

public partial class MainForm : Form
{
    private string? pathModelFile;
    private string? pathDatasetFile;

    private double[]? model;
    private int[]? dataset;

    public MainForm() => InitializeComponent();

    private void MainForm_Load(object sender, EventArgs e) => Where();

    private void btnTrain_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(pathModelFile) || string.IsNullOrEmpty(pathDatasetFile))
            MessageBox.Show("Add a data set and a model file to start", "Warning!");
        else
            CallScript("trainmodel", $"{pathDatasetFile} {pathModelFile}");
    }

    private static void CallScript(string scriptName, string arguments)
    {
        ProcessStartInfo info = new()
        {
            FileName = "python3",
            Arguments = $"{AppContext.BaseDirectory}pyscripts\\{scriptName}.py {arguments}"
        };
        Process.Start(info);
    }

    private double Calculate(double number)
    {
        if (string.IsNullOrEmpty(pathModelFile) || string.IsNullOrEmpty(pathDatasetFile))
            MessageBox.Show("Add a data set and a model file to start", "Warning!");
        else
        {
            double result = 0;
            for (int i = 0; i < 6; i++)
                result += model[i] * Math.Pow(number, 5 - i);
            return result;
        }
        return double.NaN;
    }

    private bool ValidateFile(string path)
    {
        List<string> lines = File.ReadAllLines(path).ToList();
        switch (lines.Count)
        {
            case 8 when lines[0] is @"mltool modeli":
                model = new double[6];
                for (int i = 2; i < 8; i++)
                    model[i - 2] = double.Parse(lines[i]);
                return true;

            case 66 when lines[0] is @"mltool veri seti":
                dataset = new int[64];
                for (int j = 2; j < 66; j++)
                    dataset[j - 2] = int.Parse(lines[j]);
                return true;

            default:
                MessageBox.Show($"File {path} is not recognized. Model or data set file must be selected!", "Warning!");
                return false;
        }
    }

    private static void Where()
    {
        string run = AppContext.BaseDirectory;
        string pyt = $"{run}pyscripts\\";
        bool avpyt = Directory.Exists(pyt);
        MessageBox.Show("mltoolgui could not locate \'pyscripts\' folder in running directory. Have you used build script to compile this application?", "Fatal Error!");
    }

    private void tsmiNewDataset_Click(object sender, EventArgs e)
    {
        using InputDialog dialog = new("dataset");
        DialogResult result = dialog.ShowDialog();
        if (result is DialogResult.OK && dialog.FileName is not null)
        {
            string path = $"{AppContext.BaseDirectory}{(dialog.FileName.EndsWith(".dataset") ? dialog.FileName : $"{dialog.FileName}.dataset")}";
            File.Create(path).Close();
            CallScript(@"newdataset", path);
        }
    }
}