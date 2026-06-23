using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.Storage.Pickers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Win32IsolationDemoApp
{
    /// <summary>
    /// The main content page displayed inside the application window.
    /// Add your UI logic, event handlers, and data binding here.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            // TODO: Add your initialization logic here.
        }

        private async void PickFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openPicker = new FileOpenPicker(App.MainWindowId);

                var result = await openPicker.PickSingleFileAsync();
                if (result is not null)
                {
                    PickedFileContentBox.Text = await System.IO.File.ReadAllTextAsync(result.Path);
                    StatusBarText.Text = $"Success: read \"{result.Path}\"";
                }
                else
                {
                    StatusBarText.Text = "No file selected.";
                }
            }
            catch (System.Exception ex)
            {
                PickedFileContentBox.Text = $"Error: \n\n {ex}";
                StatusBarText.Text = $"Failed to read selected file: {ex.Message}";
            }
        }

        private async void ReadPathButton_Click(object sender, RoutedEventArgs e)
        {
            var path = PathInputBox.Text;
            try
            {
                PathFileContentBox.Text = await System.IO.File.ReadAllTextAsync(path);
                StatusBarText.Text = $"Success: read \"{path}\"";
            }
            catch (System.Exception ex)
            {
                PathFileContentBox.Text = $"Error: \n\n {ex}";
                StatusBarText.Text = $"Failed to read \"{path}\": {ex.Message}";
            }
        }
    }
}
