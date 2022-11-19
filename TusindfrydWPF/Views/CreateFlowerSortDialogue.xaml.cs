using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for CreateFlowerSortDialogue.xaml
    /// </summary>
    public partial class CreateFlowerSortDialogue : Window
    {
        public MainViewModel MainVM { get; set; }

        public CreateFlowerSortDialogue (MainViewModel mainVM) {
            InitializeComponent();

            MainVM = mainVM;
        }

        private void CheckEnableOkButton () {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)
                || string.IsNullOrWhiteSpace(PicturePathTextBox.Text)
                || string.IsNullOrWhiteSpace(ProductionTimeTextBox.Text)
                || string.IsNullOrWhiteSpace(HalfLifeTimeTextBox.Text)
                || string.IsNullOrWhiteSpace(SizeTextBox.Text))
                OkButton.IsEnabled = false;
            else 
                OkButton.IsEnabled = true;
        }

        private void OkButton_Click (object sender, RoutedEventArgs e) {
            if (!int.TryParse(ProductionTimeTextBox.Text, out int productionTime))
                Trace.WriteLine("ProductionTime assigned value 0, as it couldn't be parsed properly.");

            if (!int.TryParse(HalfLifeTimeTextBox.Text, out int halfLifeTime))
                Trace.WriteLine("HalfLifeTime time assigned value 0, as it couldn't be parsed properly.");

            if (!double.TryParse(SizeTextBox.Text, out double size))
                Trace.WriteLine("Size assigned value 0, as it couldn't be parsed properly.");

            MainVM.CreateFlowerSort(
                NameTextBox.Text,
                PicturePathTextBox.Text,
                productionTime,
                halfLifeTime,
                size);

            DialogResult = true;
            Close();
        }

        private void AbortButton_Click (object sender, RoutedEventArgs e) {
            Close();
        }

        private void PicturePathTextBox_LostFocus (object sender, RoutedEventArgs e) {
            try {
                // first, find the path to the referenced file
                Uri pictureURI = new Uri(System.IO.Path.GetFullPath(@"..\..\..\Images\") + PicturePathTextBox.Text);
                FlowerSortImage.Source = new BitmapImage(pictureURI);
            } catch (FileNotFoundException ex) {
                Trace.WriteLine(ex.Message);
            }
        }

        private void NameTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            CheckEnableOkButton();
        }

        private void PicturePathTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            CheckEnableOkButton();
        }

        private void ProductionTimeTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            CheckEnableOkButton();
        }

        private void HalfLifeTimeTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            CheckEnableOkButton();
        }

        private void SizeTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            CheckEnableOkButton();
        }
    }
}
