using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System;

namespace VKUI.Avalonia.Demo
{
    public partial class MainWindow : Window
    {
        WindowNotificationManager _notificationManager;

        public MainWindow()
        {
            InitializeComponent();
            _notificationManager = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.BottomLeft,
                MaxItems = 5
            };
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

        private void ShowDefaultNotification(object sender, RoutedEventArgs e)
        {
            _notificationManager.Show(new Notification(
                "Information",
                "This is Avalonia's notification system. Lorem ipsum dolor sit amet...",
                NotificationType.Information,
                TimeSpan.FromSeconds(5)));
        }

        private void ShowSuccessNotification(object sender, RoutedEventArgs e)
        {
            _notificationManager.Show(new Notification(
                "Success",
                "All done!",
                NotificationType.Success,
                TimeSpan.FromSeconds(5)));
        }

        private void ShowWarningNotification(object sender, RoutedEventArgs e)
        {
            _notificationManager.Show(new Notification(
                "Warning",
                "Check weather for tomorrow.",
                NotificationType.Warning,
                TimeSpan.FromSeconds(5)));
        }

        private void ShowErrorNotification(object sender, RoutedEventArgs e)
        {
            _notificationManager.Show(new Notification(
                "Error",
                "File not found.",
                NotificationType.Error,
                TimeSpan.FromSeconds(5)));
        }
    }
}