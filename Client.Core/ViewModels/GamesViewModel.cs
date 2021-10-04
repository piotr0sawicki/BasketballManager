using Client.Core.Api;
using Client.Core.Models;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
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
        public readonly IGameEndpoint _gameEndpoint;
        private readonly IMvxNavigationService _mvxNavigationService;
        private ObservableCollection<GameModel> _games = new ObservableCollection<GameModel>();
        private GameModel _selectedGame;


        public IMvxCommand ViewDetailsCommand { get; set; }

        public ObservableCollection<GameModel> Games
        {
            get { return _games; }
            set { SetProperty(ref _games, value); }
        }

        public GameModel SelectedGame
        {
            get { return _selectedGame; }
            set 
            { 
                SetProperty(ref _selectedGame, value);
                RaisePropertyChanged(() => CanViewDetails);
            }
        }

        public GamesViewModel(IGameEndpoint gameEndpoint, IMvxNavigationService mvxNavigationService)
        {
            _gameEndpoint = gameEndpoint;
            _mvxNavigationService = mvxNavigationService;
            ViewDetailsCommand = new MvxAsyncCommand(ViewDetails);
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            MvxNotifyTask.Create(() => LoadGames());
            return;
        }
      
        private async Task LoadGames()
        {
            var gameList = await _gameEndpoint.GetAll();

            Games = new ObservableCollection<GameModel>(gameList);
            return;
        }

        public async Task ViewDetails()
        {
            await _mvxNavigationService.Navigate<GameDetailsViewModel, GameDetailsParams>(new GameDetailsParams(SelectedGame));
        }

        public bool CanViewDetails => !(SelectedGame == null);
    }
}
