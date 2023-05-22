using Library_Final_Project.Data;
using Library_Final_Project.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Library_Final_Project.Windows
{
    public partial class BooksWindow : Window
    {
        private readonly LibraryContext _context;
        private Book _selectedBook;
        public BooksWindow()
        {
            InitializeComponent();
            _context = new LibraryContext();

            FillBookCategories();

            FillStudents();
        }

        private void FillBookCategories()
        {
            CmbBookCategories.ItemsSource = _context.BookCategories.ToList();
        }

        private void FillStudents()
        {
            DgvBooks.ItemsSource = _context.Books.ToList();
        }

        private void Reset()
        {
            TxtName.Clear();
            CmbBookCategories.SelectedItem = null;

            BtnCreate.Visibility = Visibility.Visible;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;

            FillStudents();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValidation())
            {
                MessageBox.Show("Bütün xanaları doldurmalısınız");
                return;
            }

            Book book = new Book
            {
                Name = TxtName.Text,
                BookCategoryId = (int)CmbBookCategories.SelectedValue
            };

            _context.Books.Add(book);

            _context.SaveChanges();

            Reset();

            MessageBox.Show("Kitab əlavə olundu");
        }

        private void DgvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgvBooks.SelectedItem == null) return;

            _selectedBook = (Book)DgvBooks.SelectedItem;

            TxtName.Text = _selectedBook.Name;
            CmbBookCategories.SelectedValue = _selectedBook.BookCategoryId;

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

            _selectedBook.Name = TxtName.Text;
            _selectedBook.BookCategoryId = (int)CmbBookCategories.SelectedValue;

            _context.SaveChanges();

            Reset();

            MessageBox.Show("Kitab yeniləndi");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Silməyə əminsinizmi?", _selectedBook.ToString(), MessageBoxButton.OKCancel);

            if (r == MessageBoxResult.OK)
            {
                _context.Books.Remove(_selectedBook);
                _context.SaveChanges();

                Reset();

                MessageBox.Show("Kitab silindi");
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

            if (CmbBookCategories.SelectedItem == null)
            {
                LblBookCategories.Foreground = new SolidColorBrush(Colors.Red);
                hasError = true;
            }
            else
            {
                LblBookCategories.Foreground = new SolidColorBrush(Colors.Black);
            }

            return hasError;
        }

        private void BtnAddBookCategory_Click(object sender, RoutedEventArgs e)
        {
            AddBookCategoryWindow abcw = new AddBookCategoryWindow();
            abcw.RefreshCmbBookCategories += Abcw_RefreshCmbBookCategories;
            abcw.ShowDialog();
        }

        private void Abcw_RefreshCmbBookCategories()
        {
            FillBookCategories();
        }
    }
}
