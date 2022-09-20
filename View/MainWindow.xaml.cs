﻿using System;
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
using System.Data.SqlClient;

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

            try
            {
                connection.TryOpenConnection();

                Book book = new Book("gdf",42.52,61,12);

                PSQLDatabaseDeleter deleter = new PSQLDatabaseDeleter(connection);
                deleter.DeleteObject("book", book);
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
