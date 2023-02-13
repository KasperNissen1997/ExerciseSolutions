using System.Windows;
using TheMovies.MVVM.ViewModels;

namespace TheMovies.MVVM.Views
{
    public partial class AddMovieView : Window
    {
        public AddMovieView()
        {
            InitializeComponent();

            DataContext = new AddMovieViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
