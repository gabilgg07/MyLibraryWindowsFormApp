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
    public partial class ClientsWindow : Window
    {
        private readonly LibraryContext _context;
        private Client _selectedClient;
        public ClientsWindow()
        {
            InitializeComponent();
            _context = new LibraryContext();

            FillClients();
        }

        private void FillClients()
        {
            DgvClients.ItemsSource = _context.Clients.ToList();
        }

        private void Reset()
        {
            TxtName.Clear();
            TxtSurname.Clear();
            TxtPhone.Clear();

            BtnCreate.Visibility = Visibility.Visible;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;

            FillClients();
        }
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValidation())
            {
                MessageBox.Show("Bütün xanaları doldurmalısınız");
                return;
            }

            Client client = new Client
            {
                Name = TxtName.Text,
                Surname = TxtSurname.Text,
                PhoneNumber = TxtPhone.Text
            };

            _context.Clients.Add(client);

            _context.SaveChanges();

            Reset();

            MessageBox.Show("Müştəri əlavə olundu");
        }

        private void DgvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgvClients.SelectedItem == null) return;

            _selectedClient = (Client)DgvClients.SelectedItem;

            TxtName.Text = _selectedClient.Name;
            TxtSurname.Text = _selectedClient.Surname;
            TxtPhone.Text = _selectedClient.PhoneNumber;

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

            _selectedClient.Name = TxtName.Text;
            _selectedClient.Surname = TxtSurname.Text;
            _selectedClient.PhoneNumber = TxtPhone.Text;

            _context.SaveChanges();

            Reset();

            MessageBox.Show("Müştəri yeniləndi");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Silməyə əminsinizmi?", _selectedClient.ToString(), MessageBoxButton.OKCancel);

            if (r == MessageBoxResult.OK)
            {
                _context.Clients.Remove(_selectedClient);
                _context.SaveChanges();

                Reset();

                MessageBox.Show("Müştəri silindi");
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

            if (string.IsNullOrEmpty(TxtPhone.Text))
            {
                LblPhone.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblPhone.Foreground = new SolidColorBrush(Colors.Black);
            }

            return hasError;
        }


    }
}
