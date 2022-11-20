﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
using TusindfrydWPF.ViewModels;

namespace TusindfrydWPF.Views
{
    /// <summary>
    /// Interaction logic for StartProductionDialogue.xaml
    /// </summary>
    public partial class StartProductionDialogue : Window
    {
        public MainViewModel MainVM { get; set; }

        public StartProductionDialogue (MainViewModel mainVM) {
            InitializeComponent();

            MainVM = mainVM;
            DataContext = MainVM;

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today);
            DatePicker.BlackoutDates.Add(cdr);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AbortButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}