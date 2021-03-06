using Client.Wpf.Views;
using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;

namespace Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : MvxApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void RegisterSetup()
        {
            this.RegisterSetupType<Setup>();
        }

    }
}
