using System;
using System.Windows;

namespace Extensions.Helpers
{
    public class Common
    {
        /// <summary>
        /// Вывод сообщение поверх всех окон приложения
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="image"></param>
        /// <returns></returns>
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
