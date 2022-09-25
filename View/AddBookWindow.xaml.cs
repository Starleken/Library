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

namespace SchoolLearn
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();

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
            CheckField();
        }

        private bool CheckField()
        {
            MessageBox.Show("Поля не заполнены");
            return false;
        }
    }
}
