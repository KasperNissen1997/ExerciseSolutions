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

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FlowerSort> FlowerSorts { get; set; }

        public MainWindow () {
            InitializeComponent();

            FlowerSorts = new List<FlowerSort>();
        }

        private void registerFlowerSortButton_Click (object sender, RoutedEventArgs e) {
            CreateFlowerSortDialogue dialogue = new CreateFlowerSortDialogue();

            if (dialogue.ShowDialog() == true) {
                FlowerSort flowerSort = dialogue.FlowerSort;

                FlowerSorts.Add(flowerSort);
                FlowerSortListingTextBox.Text += flowerSort.ToString() + "\n";
            }
        }
    }
}
