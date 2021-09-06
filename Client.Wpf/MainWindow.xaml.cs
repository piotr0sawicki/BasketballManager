using Client.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Platforms.Wpf.Views;

namespace Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MvxWindow
    {
        public MainWindow()
        {
            DataContext = new GameDetailsViewModel();
            InitializeComponent();
        }
    }
}
