using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FurnitureManufacturing.Data
{
    public class FeedbackService
    {
        public static void GetError(Exception exception)
        {
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void GetError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void GetWarning(string message)
        {
            MessageBox.Show(message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void GetInformation(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult GetQuestion(string message)
        {
            return MessageBox.Show(message, "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
