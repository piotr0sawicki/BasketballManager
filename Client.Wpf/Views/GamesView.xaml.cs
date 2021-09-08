using Client.Core;
using Client.Core.ViewModels;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
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

namespace Client.Wpf.Views
{
    /// <summary>
    /// Interaction logic for GameDetailsView.xaml
    /// </summary>
    /// 
    [MvxContentPresentation]
    public partial class GamesView : MvxWpfView
    {

        public GamesView()
        {
            InitializeComponent();
        }
    }
}
