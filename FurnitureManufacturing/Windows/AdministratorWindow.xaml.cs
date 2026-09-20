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
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        FurnitureManufacturingContext db = new FurnitureManufacturingContext();
        public AdministratorWindow()
        {
            InitializeComponent();

            UsersLv.ItemsSource = db.Users.ToList();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            if (addUserWindow.ShowDialog() == true)
            {
                UsersLv.ItemsSource = db.Users.ToList();
            }
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersLv.SelectedItem != null)
            {
                EditUserWindow editUserWindow = new EditUserWindow(UsersLv.SelectedItem as User, db);
                if (editUserWindow.ShowDialog() == true)
                {
                    UsersLv.ItemsSource = db.Users.ToList();
                }
            }
            else
            {
                FeedbackService.GetWarning("Для изменения данных - выберите пользователя");
            }
        }
    }
}
