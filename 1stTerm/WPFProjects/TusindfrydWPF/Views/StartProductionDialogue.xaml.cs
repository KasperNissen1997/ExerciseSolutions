using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private void CheckEnableOkButton () {
            if (DatePicker.SelectedDate == null
                || string.IsNullOrWhiteSpace(StartAmountTextBox.Text)
                || string.IsNullOrWhiteSpace(ExpectedAmountTextBox.Text)
                || MainVM.SelectedFlowerSort == null
                || MainVM.SelectedProductionTray == null)
                OkButton.IsEnabled = false;
            else
                OkButton.IsEnabled = true;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(StartAmountTextBox.Text, out int startAmount))
                Trace.WriteLine("yaddayadda");

            if (int.TryParse(ExpectedAmountTextBox.Text, out int expectedAmount))
                Trace.WriteLine("Another yaddayadda");

            MainVM.CreateProduction(
                MainVM.SelectedProductionTray,
                MainVM.SelectedFlowerSort,
                DateOnly.FromDateTime(DatePicker.DisplayDate),
                startAmount,
                expectedAmount);

            DialogResult = true;
            Close();
        }

        private void AbortButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DatePicker_SelectedDateChanged (object sender, SelectionChangedEventArgs e) {
            CheckEnableOkButton();
        }

        private void StartAmountTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            CheckEnableOkButton();
        }

        private void ExpectedAmountTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            CheckEnableOkButton();
        }

        private void FlowerSortDropDown_SelectionChanged (object sender, SelectionChangedEventArgs e) {
            CheckEnableOkButton();
        }

        private void ProductionTrayDropDown_SelectionChanged (object sender, SelectionChangedEventArgs e) {
            CheckEnableOkButton();
        }
    }
}
