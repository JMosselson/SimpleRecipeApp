using System.Windows;

namespace ProgPoeGui
{
    public partial class OutputDialog : Window
    {
        public OutputDialog(string message, string title)
        {
            InitializeComponent();
            Title = title;
            lblMessage.Content = message;
            Width = 500; // Set your desired width
            Height = 400; // Set your desired height
            ResizeMode = ResizeMode.NoResize; // Disable resizing
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Center the window on startup
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        // Method to show dialog and display output
        public static void ShowDialog(string message, string title)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                OutputDialog outputDialog = new OutputDialog(message, title);
                outputDialog.ShowDialog();
            });
        }
    }
}
