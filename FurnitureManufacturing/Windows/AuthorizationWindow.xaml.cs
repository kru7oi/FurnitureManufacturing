using FurnitureManufacturing.Data;
using FurnitureManufacturing.Models;
using System;
using System.Linq;
using System.Windows;

namespace FurnitureManufacturing.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        // Счётчик неудачных попыток входа (локальный, для сессии)
        private int _failedAttempts = 0;

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LoginTb.Text) || string.IsNullOrWhiteSpace(PasswordPb.Password))
                {
                    FeedbackService.GetWarning("Заполните поля \"Логин\" и \"Пароль\".");
                    return;
                }

                string loginInput = LoginTb.Text.Trim();

                FurnitureManufacturingContext db = new FurnitureManufacturingContext();

                User? currentUser = db.Users.FirstOrDefault(u => u.Login == loginInput);

                if (currentUser != null && currentUser.IsBlocked)
                {
                    FeedbackService.GetError("Вы заблокированы. Обратитесь к администратору.");
                    return;
                }

                bool isPasswordCorrect = currentUser != null && currentUser.Password == PasswordPb.Password;

                if (!isPasswordCorrect)
                {
                    HandleFailedAttempt(currentUser, db, "Неправильно введён логин или пароль.");
                    return;
                }

                var captchaWindow = new CaptchaWindow();

                if (captchaWindow.ShowDialog() == true)
                {
                    FeedbackService.GetInformation("Вы успешно авторизовались.");

                    if (currentUser != null)
                    {
                        _failedAttempts = 0;
                        db.SaveChanges();
                    }

                    Window nextWindow = currentUser!.Role.RoleName == "Администратор"
                        ? new AdministratorWindow()
                        : new UserWindow();

                    nextWindow.Show();
                    Close();
                }
                else
                {
                    HandleFailedAttempt(currentUser, db, "Неправильно собрана капча.");
                }
            }
            catch (Exception ex)
            {
                FeedbackService.GetError(ex);
            }
        }

        private void HandleFailedAttempt(User? user, FurnitureManufacturingContext db, string reason)
        {
            _failedAttempts++;

            if (user != null)
            {
                if (_failedAttempts >= 3)
                {
                    user.IsBlocked = true;
                    db.SaveChanges();
                    FeedbackService.GetError("Вы заблокированы. Обратитесь к администратору.");
                    return;
                }

                db.SaveChanges();
            }

            FeedbackService.GetError($"{reason} Использовано попыток: {_failedAttempts} из 3.");
        }
    }
}