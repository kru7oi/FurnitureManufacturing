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
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        List<Image> _images = new List<Image>()
        {
            new Image() { Source = new BitmapImage(new Uri("D:\\prog\\desktop\\FurnitureManufacturing\\FurnitureManufacturing\\Data\\Images\\4.png")), Tag = "4", Stretch = Stretch.UniformToFill, Width = 180},
            new Image() { Source = new BitmapImage(new Uri("D:\\prog\\desktop\\FurnitureManufacturing\\FurnitureManufacturing\\Data\\Images\\1.png")), Tag = "1", Stretch = Stretch.UniformToFill, Width = 180},
            new Image() { Source = new BitmapImage(new Uri("D:\\prog\\desktop\\FurnitureManufacturing\\FurnitureManufacturing\\Data\\Images\\3.png")), Tag = "3", Stretch = Stretch.UniformToFill, Width = 180},
            new Image() { Source = new BitmapImage(new Uri("D:\\prog\\desktop\\FurnitureManufacturing\\FurnitureManufacturing\\Data\\Images\\2.png")), Tag = "2", Stretch = Stretch.UniformToFill, Width = 180},
        };

        public CaptchaWindow()
        {
            InitializeComponent();

            foreach (Image image in _images)
            {
                CaptchaSidebarLb.Items.Add(image);
            }
        }

        private void CaptchaLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Image selectedImage = CaptchaLb.SelectedItem as Image;

            if (selectedImage != null)
            {
                CaptchaLb.Items.Remove(selectedImage);
                CaptchaSidebarLb.Items.Add(selectedImage);
                selectedImage = null;
            }
        }

        private void CaptchaSidebarLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Image selectedImage = CaptchaSidebarLb.SelectedItem as Image;

            if (selectedImage != null)
            {
                CaptchaSidebarLb.Items.Remove(selectedImage);
                CaptchaLb.Items.Add(selectedImage);
                selectedImage = null;
            }

            if (CaptchaLb.Items.Count == 4)
            {
                string tags = "";

                foreach (var item in CaptchaLb.Items)
                {
                    tags += (item as Image).Tag;
                }

                if (tags == "1234")
                {
                    DialogResult = true;
                }
                else
                {
                    DialogResult = false;
                }
            }
        }
    }
}
