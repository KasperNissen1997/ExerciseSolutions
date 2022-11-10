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

namespace WPFSimpleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow () {
            InitializeComponent();
        }

        private void scrollUpButton_Click (object sender, RoutedEventArgs e) {
            string tempText = line1TextBox.Text;
            
            line1TextBox.Text = line2TextBox.Text;
            line2TextBox.Text = line3TextBox.Text;
            line3TextBox.Text = line4TextBox.Text;
            line4TextBox.Text = tempText;
        }

        private void clearButton_Click (object sender, RoutedEventArgs e) {
            line1TextBox.Text = string.Empty;
            line2TextBox.Text = string.Empty;
            line3TextBox.Text = string.Empty;
            line4TextBox.Text = string.Empty;
        }

        private void scrollDownButton_Click (object sender, RoutedEventArgs e) {
            string tempText = line4TextBox.Text;
            
            line4TextBox.Text = line3TextBox.Text;
            line3TextBox.Text = line2TextBox.Text;
            line2TextBox.Text = line1TextBox.Text;
            line1TextBox.Text = tempText;
        }
    }
}
