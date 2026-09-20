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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FurnitureManufacturingContext db = new();

                if (db.Users.Any(u => u.Login == LoginTb.Text))
                {
                    FeedbackService.GetWarning("Пользователь с указанным логином уже существует. Укажите другой.");
                    return;
                }

                User newUser = new User()
                {
                    Login = LoginTb.Text,
                    Password = PasswordPb.Password,
                    RoleId = Convert.ToInt32(RoleTb.Text),
                    IsBlocked = false,
                    CreatedDate = DateTime.Now,
                };

                if (newUser.RoleId == 1 || newUser.RoleId == 2)
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    FeedbackService.GetInformation("Пользователь успешно добавлен.");

                    DialogResult = true;
                }
                else
                {
                    FeedbackService.GetWarning("Укажите корректный номер роли.");
                    return;
                }

            }
            catch (Exception ex)
            {
                FeedbackService.GetError(ex);
            }
        }
    }
}
