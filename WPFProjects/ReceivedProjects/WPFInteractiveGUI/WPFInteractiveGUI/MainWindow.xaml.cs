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

namespace WPFInteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;

        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller();
        }

        private void ShowCurrentPersonInfo () {
            FirstNameTextBox.Text = controller.CurrentPerson.FirstName;
            LastNameTextBox.Text = controller.CurrentPerson.LastName;
            AgeTextBox.Text = controller.CurrentPerson.Age.ToString();
            TelephoneNoTextBox.Text = controller.CurrentPerson.TelephoneNo;
        }

        private void NewPersonButton_Click (object sender, RoutedEventArgs e) {
            if (controller.PersonCount == 0) {
                DeletePersonButton.IsEnabled = true;
                UpButton.IsEnabled = true;
                DownButton.IsEnabled = true;

                FirstNameTextBox.IsEnabled = true;
                LastNameTextBox.IsEnabled = true;
                AgeTextBox.IsEnabled = true;
                TelephoneNoTextBox.IsEnabled = true;
            }

            controller.AddPerson();
            ShowCurrentPersonInfo();

            PersonCountLabel.Content = "Person count " + controller.PersonCount;
            IndexLabel.Content = "Index " + controller.PersonIndex;
        }

        private void FirstNameTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            controller.CurrentPerson.FirstName = FirstNameTextBox.Text;
        }

        private void LastNameTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            controller.CurrentPerson.LastName = LastNameTextBox.Text;
        }

        private void AgeTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            if (int.TryParse(AgeTextBox.Text, out int age))
                controller.CurrentPerson.Age = age;
        }

        private void TelephoneNoTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            controller.CurrentPerson.TelephoneNo = TelephoneNoTextBox.Text;
        }

        private void DeletePersonButton_Click (object sender, RoutedEventArgs e) {
            controller.DeletePerson();

            if (controller.PersonCount == 0) {
                DeletePersonButton.IsEnabled = false;
                UpButton.IsEnabled = false;
                DownButton.IsEnabled = false;

                FirstNameTextBox.IsEnabled = false;
                LastNameTextBox.IsEnabled = false;
                AgeTextBox.IsEnabled = false;
                TelephoneNoTextBox.IsEnabled = false;
            }
            else
                ShowCurrentPersonInfo();

            PersonCountLabel.Content = "Person count: " + controller.PersonCount;
            IndexLabel.Content = "Index " + controller.PersonIndex;
        }

        private void UpButton_Click (object sender, RoutedEventArgs e) {
            controller.NextPerson();

            ShowCurrentPersonInfo();
            IndexLabel.Content = "Index " + controller.PersonIndex;
        }

        private void DownButton_Click (object sender, RoutedEventArgs e) {
            controller.PrevPerson();

            ShowCurrentPersonInfo();
            IndexLabel.Content = "Index " + controller.PersonIndex;
        }
    }
}
