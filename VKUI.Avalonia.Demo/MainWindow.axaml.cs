using Avalonia.Controls;
using Avalonia.Interactivity;

namespace VKUI.Avalonia.Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.IsChecked == true)
            {
                Classes.Add("Compact");
            }
            else
            {
                Classes.Remove("Compact");
            }
        }
    }
}