using System.Windows;

namespace ProgPoeGui
{
    public partial class InputDialog : Window
    {
        public string Input { get; private set; }

        public InputDialog(string question, string title)
        {
            InitializeComponent();
            Title = title;
            lblQuestion.Content = question;
            Width = 500; // Set your desired width
            Height = 210; // Set your desired height
            ResizeMode = ResizeMode.NoResize; // Disable resizing
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Center the window on startup
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            Input = txtAnswer.Text;
            DialogResult = true;
        }

        // Method to show dialog and get input
        public static string ShowDialog(string prompt, string title)
        {
            string result = null;
            Application.Current.Dispatcher.Invoke(() =>
            {
                InputDialog inputDialog = new InputDialog(prompt, title);
                inputDialog.ShowDialog();
                result = inputDialog.DialogResult == true ? inputDialog.Input : null;
            });

            return result;
        }
    }
}

