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
    /// Логика взаимодействия для GivenBooksList.xaml
    /// </summary>
    public partial class GivenBooksList : Page
    {
        private PSQLConnection connection;

        public GivenBooksList(PSQLConnection connection)
        {
            InitializeComponent();

            this.connection = connection;

            FillTableWithBooks();
        }

        private void FillTableWithBooks()
        {
            PSQLDatabaseReader reader = new PSQLDatabaseReader(connection);
            List<GivenBook> books = reader.ReadGivenBooks();

            foreach (GivenBook book in books)
            {
                GivenBookList.Items.Add(book);
            }
        }
    }
}
