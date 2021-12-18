#pragma warning disable IDE1006 // Naming Styles
namespace mltoolgui
{
    public partial class InputDialog : Form
    {
        public string? FileName;

        public InputDialog(string fileType)
        {
            InitializeComponent();
            Text = fileType is "bundle" ? $"Name your model and data set files" : $"Name your {fileType} file";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtName.Text))
                DialogResult = DialogResult.Cancel;
            else
            {
                FileName = txtName.Text;
                DialogResult = DialogResult.OK;
            }
            Close();
        }
    }
}
#pragma warning restore IDE1006 // Naming Styles