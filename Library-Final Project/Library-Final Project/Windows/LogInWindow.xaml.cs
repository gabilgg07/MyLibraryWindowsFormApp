using Library_Final_Project.Data;
using Library_Final_Project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Library_Final_Project.Windows
{
    public partial class LogInWindow : Window
    {
        private readonly LibraryContext _context;
        public LogInWindow()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }
        
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (FormValidation())
            {
                MessageBox.Show("Xanaları doldurun");
                return;
            }

            List<User> users = _context.Users.ToList();

            int count = users.Count;
            if (count == 0)
            {
                MessageBox.Show("Kitabxana proqramına xoş gəlmisiniz");
                DashboardWindow dw = new DashboardWindow();
                dw.Show();
                this.Close();
                return;
            }
            foreach (User user in users)
            {
                
                if (TxtUserName.Text == user.Username && PwbPassword.Password==user.Password)
                {
                    MessageBox.Show(user.Username+" adı ilə daxil oldunuz");
                    DashboardWindow dw = new DashboardWindow();
                    dw.Show();                    
                    this.Close();
                    return;
                }
                else
                {
                    count--;
                    if (count==0)
                    {
                        MessageBox.Show("İstifadəçi adı və ya şifrəsi yanlışdır");
                        return;
                    }
                }
            }
        }

        private bool FormValidation()
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(TxtUserName.Text))
            {
                LblUserName.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblUserName.Foreground = new SolidColorBrush(Colors.Black);
            }

            if (string.IsNullOrEmpty(PwbPassword.Password))
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
