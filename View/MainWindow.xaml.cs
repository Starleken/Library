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
using SchoolLearn.View.Lists;
using SchoolLearn.Resources.Scripts;
using Npgsql;

namespace SchoolLearn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DisplayStartFrame();

            string conn = $"Host=localhost;Username=postgres;Database=library;Port=5432;Password=tqw1467gheK";

            PSQLConnection connection = new PSQLConnection(conn);

            connection.TryOpenConnection();

            try
            {
                GivenBook book = new GivenBook("g", 42.52, 261, new DateTime(2006, 12, 02), 17, new ReadingInterval(),3);
                PSQLDatabaseDeleter deleter = new PSQLDatabaseDeleter(connection);
                deleter.DeleteObject(book);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void DisplayStartFrame() => FrameShower.Navigate(new BooksList());
    }
}
