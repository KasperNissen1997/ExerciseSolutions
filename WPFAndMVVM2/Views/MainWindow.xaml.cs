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
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel mainVM;

        public MainWindow()
        {
            InitializeComponent();

            mainVM = new MainViewModel();
            DataContext = mainVM;
        }

        private void AddButton_Click (object sender, RoutedEventArgs e) {
            mainVM.AddDefaultPerson();
            PersonsListBox.ScrollIntoView(mainVM.SelectedPerson);
        }

        private void DeleteButton_Click (object sender, RoutedEventArgs e) {
            mainVM.DeleteSelectedPerson();
        }

        private void PersonsListBox_SelectionChanged (object sender, SelectionChangedEventArgs e) {
            if (PersonsListBox.SelectedItem != null) {
                mainVM.SelectedPerson = (PersonViewModel) PersonsListBox.SelectedItem;
                DeleteButton.IsEnabled = true;
            }
            else {
                DeleteButton.IsEnabled = false;
            }
        }
    }
}
