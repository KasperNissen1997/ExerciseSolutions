using System.Windows;
using TheMoviesSQL.MVVM.ViewModels;
using TheMoviesSQL.MVVM.ViewModels.Persistence;

namespace TheMoviesSQL.MVVM.Views
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
        }
    }
}
