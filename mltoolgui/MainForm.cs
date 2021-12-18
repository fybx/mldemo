// ReSharper disable once IdentifierTypo
using System.Diagnostics;

namespace mltoolgui;

public partial class MainForm : Form
{
    private string? pathModelFile;
    private string? pathDatasetFile;

    private double[]? model;
    private string? modelname;
    private int[]? dataset;

    public MainForm() => InitializeComponent();

    #region Events
    private void MainForm_Load(object sender, EventArgs e) => Where();
    private void btnTrain_Click(object sender, EventArgs e) => Train();
    private void btnEvaluate_Click(object sender, EventArgs e) => Evaluate();
    private void tsmiNewModel_Click(object sender, EventArgs e) => NewFile("model");
    private void tsmiNewDataset_Click(object sender, EventArgs e) => NewFile("dataset");
    private void tsmiNewBundle_Click(object sender, EventArgs e) => NewFile("bundle");
    private void tsmiLoadModel_Click(object sender, EventArgs e) => LoadFile("model");
    private void tsmiLoadDataset_Click(object sender, EventArgs e) => LoadFile("dataset");
    private void tsmiLoadBundle_Click(object sender, EventArgs e) => LoadFile("bundle");
    private void tsmiTrain_Click(object sender, EventArgs e) => Train();
    private void tsmiEvaluate_Click(object sender, EventArgs e) => Evaluate();
    private void tsmiExit_Click(object sender, EventArgs e) => Close();
    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode is Keys.Enter)
        {
            if (textBox1.Text is "exit")
                Lock(true);
            else if (double.TryParse(textBox1.Text, out double number))
                rtbEvaluate.AppendText($"{modelname}({number}) = {Calculate(number)}");
            else
                rtbEvaluate.AppendText("Please enter a number :(");
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
    }
    #endregion

    /// <summary>
    /// Explores base directory of executable application to find pyscripts folder and mltoolcli executable file. If said folder and executable do not exist, shows an error message and terminates application.
    /// </summary>
    private void Where()
    {
        string run = AppContext.BaseDirectory;
        string pyt = $"{run}pyscripts\\";
        string cli = $"{run}mltoolcli.exe";
        if (Directory.Exists(pyt) is false)
        {
            Message.Show("mltoolgui couldn't locate folder 'pyscripts' in base directory.\nPlease use script 'build_gui.bat' to build mltoolgui.", "Fatal Error!");
            Close();
        }
        if (File.Exists(cli) is false)
        {
            Message.Show("mltoolgui couldn't locate 'mltoolcli.exe' in base directory.\nPlease use script 'build_gui.bat' to build mltoolgui.", "Fatal Error!");
            Close();
        }
    }

    private static void RunMltoolcli(string command, string arguments)
    {
        ProcessStartInfo info = new()
        {
            FileName = "mltoolcli.exe",
            Arguments = $"{command} {arguments}"
        };
        Process prc = Process.Start(info);
        prc.WaitForExit();
        if (prc.ExitCode is not 0 or -1000)
            Message.Show($"An error has occured.\n mltoolcli.exe returned status code: {prc.ExitCode}.", "Important Warning!");
    }

    private void Train()
    {
        if (string.IsNullOrEmpty(pathModelFile) || string.IsNullOrEmpty(pathDatasetFile))
            Message.Show("Add a data set and a model file to start", "Warning!");
        else
            RunMltoolcli("train", $"{pathDatasetFile} {pathModelFile}");
    }

    private void Evaluate()
    {
        if (string.IsNullOrEmpty(pathModelFile))
            Message.Show("Add a model file to start", "Warning!");
        else
        {
            Message.Show("Use the text box below to crunch numbers. Enter 'exit' to exit evaluation shell.", "Information");
            Lock(false);
        }
    }

    private static void NewFile(string what)
    {
        using InputDialog dialog = new(what);
        DialogResult result = dialog.ShowDialog();
        if (result is DialogResult.OK && string.IsNullOrWhiteSpace(dialog.FileName) is false)
            RunMltoolcli("new", what is "bundle" ? $"bundle {dialog.FileName}" : what is "model" ? $"model {dialog.FileName}" : $"dataset {dialog.FileName}");
    }

    private void LoadFile(string what)
    {
        OpenFileDialog ofd;
        switch (what)
        {
            case "model" or "dataset":
                ofd = what is "model"
                    ? new() { Filter = "Model file|*.model", Title = "Load a model file" }
                    : new() { Filter = "Data set file|*.dataset", Title = "Load a data set file" };

                if (ofd.ShowDialog() is DialogResult.OK)
                    ValidateFile(ofd.FileName);
                break;

            case "bundle":
                ofd = new()
                {
                    Filter = "Model file|*.model|Data set file|*.dataset",
                    Title = "Load a model - data set bundle"
                };

                if (ofd.ShowDialog() is DialogResult.OK)
                {
                    if (ofd.FileName.EndsWith(".model") && File.Exists(ofd.FileName.Replace(".model", ".dataset")))
                    {
                        ValidateFile(ofd.FileName);
                        ValidateFile(ofd.FileName.Replace(".model", ".dataset"));
                    }
                    else if (ofd.FileName.EndsWith(".dataset") && File.Exists(ofd.FileName.Replace(".dataset", ".model")))
                    {
                        ValidateFile(ofd.FileName);
                        ValidateFile(ofd.FileName.Replace(".dataset", ".model"));
                    }
                    else
                        Message.Show("Bundled files must exist under same folder!", "Warning!");
                }
                break;

            default:
                Message.Show($"MainForm.Load(): value of argument {nameof(what)} must be 'model' or 'dataset'", "Warning!");
                break;
        }
    }

    private double Calculate(double number)
    {
        if (string.IsNullOrEmpty(pathModelFile))
            Message.Show("Add a model file to start", "Warning!");
        else
        {
            double result = 0;
            for (int i = 0; i < 6; i++)
                result += model[i] * Math.Pow(number, 5 - i);
            return result;
        }
        return double.NaN;
    }

    /// <summary>
    /// Validates if given file is a recognized model or data set file. Mltoolcli is not used here because of repeated calls to start a Process would be costly.
    /// </summary>
    /// <param name="path">Path of file to be validated</param>
    /// <returns>Returns true if file is a valid model or data set file</returns>
    private bool ValidateFile(string path)
    {
        List<string> lines = File.ReadAllLines(path).ToList();
        switch (lines.Count)
        {
            case 8 when lines[0] is @"mltool modeli":
                model = new double[6];
                for (int i = 2; i < 8; i++)
                    model[i - 2] = double.Parse(lines[i]);
                pathModelFile = path;
                modelname = lines[1];
                lblModelPath.Text = pathModelFile;
                return true;

            case 66 when lines[0] is @"mltool veri seti":
                dataset = new int[64];
                for (int j = 2; j < 66; j++)
                    dataset[j - 2] = int.Parse(lines[j]);
                pathDatasetFile = path;
                lblDatasetFile.Text = pathDatasetFile;
                return true;

            default:
                Message.Show($"File {path} is not recognized. Model or data set file must be selected!", "Warning!");
                return false;
        }
    }

    private void Lock(bool state)
    {
        btnTrain.Enabled = state;
        btnEvaluate.Enabled = state;
        menuStrip.Enabled = state;
        rtbEvaluate.Enabled = !state;
        textBox1.Enabled = !state;

        rtbEvaluate.Text = state ? "beep boop? beep boop." : "";
        textBox1.Text = state ? "beep boop?" : "";

        if (state is false)
            textBox1.Focus();
    }
}