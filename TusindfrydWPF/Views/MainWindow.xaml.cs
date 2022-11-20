﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TusindfrydWPF.ViewModels;

namespace TusindfrydWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainVM { get; set; }

        public MainWindow () {
            InitializeComponent();

            MainVM = new MainViewModel();
            DataContext = MainVM;
        }

        private void RegisterFlowerSortButton_Click (object sender, RoutedEventArgs e) {
            CreateFlowerSortDialogue dialogue = new CreateFlowerSortDialogue(MainVM);
            dialogue.ShowDialog();
        }

        private void StartProductionButton_Click (object sender, RoutedEventArgs e) {
            StartProductionDialogue dialogue = new StartProductionDialogue(MainVM);
            dialogue.ShowDialog();
        }

        private void SaveChanges_Click (object sender, RoutedEventArgs e) {
            MainVM.SaveAllRepositories();
        }
    }
}
