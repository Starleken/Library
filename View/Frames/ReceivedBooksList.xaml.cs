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

namespace SchoolLearn.View.Frames
{
    /// <summary>
    /// Логика взаимодействия для ReceivedBooksList.xaml
    /// </summary>
    public partial class ReceivedBooksList : Page
    {
        private PSQLConnection connection;

        public ReceivedBooksList(PSQLConnection connection)
        {
            InitializeComponent();

            this.connection = connection;

            FillTableWithBooks();
        }

        private void FillTableWithBooks()
        {
            PSQLDatabaseReader reader = new PSQLDatabaseReader(connection);
            List<ReceivedBook> books = reader.ReadReceivedBooks();

            foreach (ReceivedBook book in books)
            {
                ReceivedBookList.Items.Add(book);
            }
        }
    }
}
