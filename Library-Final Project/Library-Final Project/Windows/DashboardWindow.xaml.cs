using Library_Final_Project.Models;
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

namespace Library_Final_Project.Windows
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        private void BtnBooks_Click(object sender, RoutedEventArgs e)
        {
            BooksWindow bw = new BooksWindow();
            bw.ShowDialog();

        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            UsersWindow uw = new UsersWindow();
            uw.ShowDialog();

        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow cw = new ClientsWindow();
            cw.ShowDialog();
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow rw = new ReportsWindow();
            rw.ShowDialog();
        }

        private void BtnCreateRental_Click(object sender, RoutedEventArgs e)
        {
            CreatingRentalWindow crw = new CreatingRentalWindow();
            crw.ShowDialog();
        }

        private void BtnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            ReturnBooksWindow rbw = new ReturnBooksWindow();
            rbw.ShowDialog();
        }

        private void BtnFollowReturnTime_Click(object sender, RoutedEventArgs e)
        {
            FollowReturnsWindow frw = new FollowReturnsWindow();
            frw.ShowDialog();
        }
    }
}
