using Client.Core.Api;
using Client.Core.Models;
using MvvmCross;
using MvvmCross.Commands;
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
        private readonly IGameEndpoint _gameEndpoint;
        private ObservableCollection<GameModel> _games = new ObservableCollection<GameModel>();


        public IMvxCommand RefreshCommand { get; set; }


        public void Refresh()
        {
            // For test
            Games.Add(new GameModel()
            {
                Id = 1,
                GuestScore = 12,
                HomeScore = 123,
                GuestTeamId = 1,
                HomeTeamId = 2,
                HomeTeam = "Home Team",
                GuestTeam = "Guest Team",
                Localization = "Warszawa",
                LocalizationId = 1
            });
        }

        public GamesViewModel()
        {
            _gameEndpoint = Mvx.IoCProvider.Resolve<IGameEndpoint>();
            RefreshCommand = new MvxCommand(Refresh);
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            MvxNotifyTask.Create(() => LoadGames());
            return;
        }

        public ObservableCollection<GameModel> Games
        {
            get { return _games; }
            set { SetProperty(ref _games, value); }
        }

        private async Task LoadGames()
        {
            var productList = await _gameEndpoint.GetAll();

            Games = new ObservableCollection<GameModel>(productList);
            return;
        }
     
    }
}
