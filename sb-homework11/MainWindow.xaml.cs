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
using SB_Homework11.Storage;

namespace SB_Homework11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientData clientData;
        public MainWindow()
        {
            InitializeComponent();

            clientData = new ClientData();
            clientsGrid.ItemsSource = clientData.Clients;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            clientData.SaveData();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Window addClientWindow = new AddClientWindow();

            addClientWindow.Owner = this;

            addClientWindow.Show();
        }
    }
}
