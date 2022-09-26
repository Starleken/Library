using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SchoolLearn.Resources.Scripts;

namespace SchoolLearn
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private PSQLConnection connection;

        public AddBookWindow(PSQLConnection connection)
        {
            InitializeComponent();

            this.connection = connection;

            ReceivedDateTextBox.Visibility = Visibility.Collapsed;
            ReceivedDateTextBlock.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ReceivedDateTextBox.Visibility = Visibility.Visible;
            ReceivedDateTextBlock.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ReceivedDateTextBox.Visibility = Visibility.Collapsed;
            ReceivedDateTextBlock.Visibility = Visibility.Collapsed;
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckField();
                AddBook();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void CheckField()
        {
            if (TitleTextBox.Text == "" || PriceTextBox.Text == "" || ListCountTextBox.Text == "")
            {
                throw new Exception("Заполните поля");
            }
            else if (BookCheckBox.IsChecked == true && ReceivedDateTextBox.Text == "")
            {
                throw new Exception("Заполните поля");
            }
        }

        private void AddBook()
        {
            double price = Convert.ToDouble(PriceTextBox.Text);
            int listcount = Convert.ToInt32(ListCountTextBox.Text);
            DateTime? beginreading = CheckDateTextBoxAtNull(DateBeginTextBox);
            DateTime? endReading = CheckDateTextBoxAtNull(DateEndTextBox);

            Book book = new BookFactory().Get(BookType.book, TitleTextBox.Text, price, listcount,
                beginreading, endReading);

            PSQLDatabaseAdder adder = new PSQLDatabaseAdder(connection);
            adder.TryAdd(book);
        }

        private DateTime? CheckDateTextBoxAtNull(TextBox textBox)
        {
            DateTime? date;

            if (textBox.Text == "")
            {
                date = null;
            }
            else date = Convert.ToDateTime(textBox.Text);

            return date;
        }
    }
}
