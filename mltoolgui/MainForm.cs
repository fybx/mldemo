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

    private void MainForm_Load(object sender, EventArgs e) => Where();

    private void btnTrain_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(pathModelFile) || string.IsNullOrEmpty(pathDatasetFile))
            MessageBox.Show("Add a data set and a model file to start", "Warning!");
        else
            CallScript("trainmodel", $"{pathDatasetFile} {pathModelFile}");
    }

    private void btnEvaluate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(pathModelFile))
            MessageBox.Show("Add a model file to start", "Warning!");
        else
        {
            MessageBox.Show("Use the text box below to crunch numbers. Enter 'exit' to exit evaluation shell.", "Information");
            ChangeState(false);
        }
    }

    private static void CallScript(string scriptName, string arguments)
    {
        ProcessStartInfo info = new()
        {
            FileName = "python",
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"{AppContext.BaseDirectory}pyscripts\\{scriptName}.py {arguments}"
        };
        Process.Start(info);
    }

    private double Calculate(double number)
    {
        if (string.IsNullOrEmpty(pathModelFile))
            MessageBox.Show("Add a model file to start", "Warning!");
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
                MessageBox.Show($"File {path} is not recognized. Model or data set file must be selected!", "Warning!");
                return false;
        }
    }

    private static void Where()
    {
        string run = AppContext.BaseDirectory;
        string pyt = $"{run}pyscripts\\";
        if (!Directory.Exists(pyt))
            MessageBox.Show("mltoolgui could not locate \'pyscripts\' folder in running directory. Have you used build script to compile this application?", "Fatal Error!");
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode is Keys.Enter)
        {
            if (textBox1.Text is "exit")
                ChangeState(true);
            else if (double.TryParse(textBox1.Text, out double number))
                rtbEvaluate.AppendText($"{modelname}({number}) = {Calculate(number)}");
            else
                rtbEvaluate.AppendText("Please enter a number :(");
            textBox1.Clear();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
    }

    private void ChangeState(bool state)
    {
        btnTrain.Enabled = state;
        btnEvaluate.Enabled = state;
        menuStrip.Enabled = state;
        rtbEvaluate.ReadOnly = !state;
        textBox1.ReadOnly = !state;

        rtbEvaluate.Text = state ? "beep boop? beep boop." : "";
        textBox1.Text = state ? "beep boop?" : "";

        if (state is false)
            textBox1.Focus();
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

    private void tsmiNewModel_Click(object sender, EventArgs e)
    {
        using InputDialog dialog = new("model");
        DialogResult result = dialog.ShowDialog();
        if (result is DialogResult.OK && dialog.FileName is not null)
        {
            string path = $"{AppContext.BaseDirectory}{(dialog.FileName.EndsWith(".model") ? dialog.FileName : $"{dialog.FileName}.model")}";
            File.Create(path).Close();
            CallScript(@"newmodel", path);
        }
    }

    private void tsmiLoadDataset_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new()
        {
            Filter = "Data set file|*.dataset",
            Title = "Load a data set file"
        };

        if (ofd.ShowDialog() is DialogResult.OK)
            ValidateFile(ofd.FileName);
    }

    private void tsmiLoadModel_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new()
        {
            Filter = "Model file|*.model",
            Title = "Load a model file"
        };

        if (ofd.ShowDialog() is DialogResult.OK)
            ValidateFile(ofd.FileName);
    }

    private void tsmiTrain_Click(object sender, EventArgs e) => btnTrain_Click(sender, e); // dirty but it works

    private void tsmiEvaluate_Click(object sender, EventArgs e) => btnEvaluate_Click(sender, e);

    private void tsmiExit_Click(object sender, EventArgs e) => Close();
}