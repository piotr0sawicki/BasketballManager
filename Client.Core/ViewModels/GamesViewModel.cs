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
    public class GamesViewModel: MvxViewModel
    {
        private ObservableCollection<GameModel> _games = new ObservableCollection<GameModel>();


        public GamesViewModel()
        {
            // Test data
            _games.Add(new GameModel()
            {
                Id = 1,
                GuestScore =12, 
                HomeScore = 123,
                GuestTeamId = 1,
                HomeTeamId = 2,
                HomeTeam = "Home Team",
                GuestTeam = "Guest Team",
                Localization = "Warszawa",
                LocalizationId = 1
            }) ;
        }

        public ObservableCollection<GameModel> Games
        {
            get { return _games; }
            set { SetProperty(ref _games, value); }
        }

     
    }
}
