using Library_Final_Project.Data;
using Library_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library_Final_Project.Windows
{
    public partial class UsersWindow : Window
    {
        private readonly LibraryContext _context;
        private User _selectedUser;
        public UsersWindow()
        {
            InitializeComponent();
            _context = new LibraryContext();
            FillUsers();
        }

        private void FillUsers()
        {
            DgvUsers.ItemsSource = _context.Users.ToList();
        }

        private void Reset()
        {
            TxtName.Clear();
            TxtSurname.Clear();
            TxtLogin.Clear();
            TxtPassword.Clear();

            BtnCreate.Visibility = Visibility.Visible;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;

            FillUsers();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValidation())
            {
                MessageBox.Show("Bütün xanaları doldurmalısınız");
                return;
            }

            User user = new User
            {
                Name = TxtName.Text,
                Surname = TxtSurname.Text,
                Username = TxtLogin.Text,
                Password = TxtPassword.Text
            };

            _context.Users.Add(user);

            _context.SaveChanges();

            Reset();

            MessageBox.Show("İdarəçi əlavə olundu");
        }

        private void DgvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgvUsers.SelectedItem == null) return;

            _selectedUser = (User)DgvUsers.SelectedItem;

            TxtName.Text = _selectedUser.Name;
            TxtSurname.Text = _selectedUser.Surname;
            TxtLogin.Text = _selectedUser.Username;
            TxtPassword.Text = _selectedUser.Password;

            BtnCreate.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Visible;
            BtnDelete.Visibility = Visibility.Visible;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValidation())
            {
                MessageBox.Show("Bütün xanaları doldurmalısınız");
                return;
            }

            _selectedUser.Name = TxtName.Text;
            _selectedUser.Surname = TxtSurname.Text;
            _selectedUser.Username = TxtLogin.Text;
            _selectedUser.Password = TxtPassword.Text;

            _context.SaveChanges();

            Reset();

            MessageBox.Show("İdarəçi yeniləndi");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Silməyə əminsinizmi?", _selectedUser.ToString(), MessageBoxButton.OKCancel);

            if (r == MessageBoxResult.OK)
            {
                _context.Users.Remove(_selectedUser);
                _context.SaveChanges();

                Reset();

                MessageBox.Show("İdarəçi silindi");
            }
        }

        private bool FormValidation()
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(TxtName.Text))
            {
                LblName.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblName.Foreground = new SolidColorBrush(Colors.Black);
            }

            if (string.IsNullOrEmpty(TxtSurname.Text))
            {
                LblSurname.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblSurname.Foreground = new SolidColorBrush(Colors.Black);
            }

            if (string.IsNullOrEmpty(TxtLogin.Text))
            {
                LblLogin.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblLogin.Foreground = new SolidColorBrush(Colors.Black);
            }

            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                LblPassword.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblPassword.Foreground = new SolidColorBrush(Colors.Black);
            }


            return hasError;
        }


    }
}
