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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolLearn.Resources.Scripts;
using Npgsql;
using SchoolLearn.View.Frames;

namespace SchoolLearn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PSQLConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            OpenConnection();

            DisplayStartFrame();
        }

        void OpenConnection()
        {
            string conn = $"Host=localhost;Username=postgres;Database=library;Port=5432;Password=tqw1467gheK";

            connection = new PSQLConnection(conn);
            try
            {
                connection.TryOpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void DisplayStartFrame() => FrameShower.Navigate(new BooksList(connection));

        private void GivenBooksButton_Click(object sender, RoutedEventArgs e) => FrameShower.Navigate(new GivenBooksList(connection));

        private void BooksButton_Click(object sender, RoutedEventArgs e) => FrameShower.Navigate(new BooksList(connection));

        private void ReceivedBooksButton_Click(object sender, RoutedEventArgs e) => FrameShower.Navigate(new ReceivedBooksList(connection));
    }
}
