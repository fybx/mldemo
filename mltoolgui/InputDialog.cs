namespace mltoolgui
{
    public partial class InputDialog : Form
    {
        public string? FileName;

        public InputDialog(string fileType)
        {
            InitializeComponent();
            Text = $"Name your {fileType} file";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrWhiteSpace(txtName.Text))
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