using System.Windows;
using TheMovies.MVVM.ViewModels;
using TheMovies.MVVM.ViewModels.Persistence;

namespace TheMovies.MVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void OnWindowClosed(object sender, System.EventArgs e)
        {
            if (DataContext is MainViewModel vm)
                foreach (MovieViewModel movieVM in vm.Movies)
                    movieVM.UpdateSource();

            MovieRepository.Instance.Save();
        }
    }
}
