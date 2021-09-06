using Client.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.ViewModels
{
    public class GameDetailsViewModel: MvxViewModel
    {
        private ObservableCollection<GameModel> _games = new ObservableCollection<GameModel>();

        public ObservableCollection<GameModel> Games
        {
            get { return _games; }
            set { SetProperty(ref _games, value); }
        }

     
    }
}
