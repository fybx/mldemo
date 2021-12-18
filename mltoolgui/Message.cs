namespace mltoolgui
{
    public partial class Message : Form
    {
        public Message(string title, string message)
        {
            InitializeComponent();
            Text = title;
            lblMessage.Text = message;
            ButtonCancel.Visible = false;
        }

        public Message(string title, string message, bool cancellable = true)
        {
            Text = title;
            lblMessage.Text = message;
            ButtonCancel.Visible = cancellable;
        }

        public static DialogResult ShowDialog(string title, string message)
        {
            using Message m = new(title, message);
            return m.ShowDialog();
        }

        public static DialogResult ShowDialog(string title, string message, bool cancellable = true)
        {
            using Message m = new(title, message, cancellable);
            return m.ShowDialog();
        }
    }
}
