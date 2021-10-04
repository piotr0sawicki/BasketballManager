using Client.Core.Api;
using Client.Core.Models;
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
    public class GameDetailsViewModel : MvxViewModel<GameDetailsParams>
    {
        private readonly IGameEndpoint _gameEndpoint;
        private readonly IMvxNavigationService _mvxNavigationService;
        private GameDetailsParams _params;
        private ObservableCollection<DetailModel> _homeDetails;
        private ObservableCollection<DetailModel> _guestDetails;
        private string _guestTeam;
        private string _homeTeam;


        public IMvxCommand BackCommand { get; set; }

        public string HomeTeam
        {
            get { return _homeTeam; }
            set { SetProperty(ref _homeTeam, value); }
        }
        public string GuestTeam
        {
            get { return _guestTeam; }
            set { SetProperty(ref _guestTeam, value); }
        }

        public ObservableCollection<DetailModel> HomeDetails
        {
            get { return _homeDetails; }
            set { SetProperty(ref _homeDetails, value); }
        }

        public ObservableCollection<DetailModel> GuestDetails
        {
            get { return _guestDetails; }
            set { SetProperty(ref _guestDetails, value); }
        }

        public int GameId => _params.GameId;

        public GameDetailsViewModel(IGameEndpoint gameEndpoint, IMvxNavigationService mvxNavigationService)
        {
            _gameEndpoint = gameEndpoint;
            _mvxNavigationService = mvxNavigationService;
            BackCommand = new MvxAsyncCommand(Back);
        }

        public override void Prepare(GameDetailsParams parameter)
        {
            base.Prepare();
            _params = parameter;
        }
        public override async Task Initialize()
        {
            await base.Initialize();

            MvxNotifyTask.Create(() => LoadDetails());
            return;
        }

        private async Task LoadDetails()
        {
            var detailsList = await _gameEndpoint.GetGameDetailsById(_params.GameId);

            HomeTeam = _params.HomeTeam;
            GuestTeam = _params.GuestTeam;

            HomeDetails = new ObservableCollection<DetailModel>(detailsList.Where(x => x.TeamName == HomeTeam));
            GuestDetails = new ObservableCollection<DetailModel>(detailsList.Where(x => x.TeamName == GuestTeam));

            return;
        }

        public async Task Back()
        {
            await _mvxNavigationService.Navigate<GamesViewModel>();
        }
    }
}
