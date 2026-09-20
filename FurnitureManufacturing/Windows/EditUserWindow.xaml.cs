using FurnitureManufacturing.Data;
using FurnitureManufacturing.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FurnitureManufacturing.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        FurnitureManufacturingContext db = new FurnitureManufacturingContext();

        public EditUserWindow(User user, FurnitureManufacturingContext db)
        {
            InitializeComponent();

            DataContext = user;
            this.db = db;
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            FeedbackService.GetInformation("Данные успешно изменены.");
            DialogResult = true;
        }
    }
}
