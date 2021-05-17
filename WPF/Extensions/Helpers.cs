using System;
using System.Windows;

namespace Extensions.Helpers
{
    public class Common
    {
        public static MessageBoxResult MessageBoxShowTopMost(
            string msg, 
            string caption = "Инфрмация",
            MessageBoxButton buttons = MessageBoxButton.OK, 
            MessageBoxImage image = MessageBoxImage.Information)
        {
            MessageBoxResult msgRes = MessageBoxResult.None;
            Application.Current.MainWindow?.Dispatcher.Invoke(new Func<MessageBoxResult>(
                () => msgRes = MessageBox.Show(msg, caption, buttons, image)));
            return msgRes;
        }
    }
}
