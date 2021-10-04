using Client.Core.Api;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.ViewModels
{
    public class LoginViewModel: MvxViewModel
    {
        private string _login;
        private string _password;
        private readonly IApiHelper _apiHelper;
        private readonly IMvxNavigationService _mvxNavigationService;


        public IMvxCommand TryLogInCommand { get; set; }
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public string Password
        { 
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        public LoginViewModel(IApiHelper apiHelper, IMvxNavigationService mvxNavigationService)
        {
            _apiHelper = apiHelper;
            _mvxNavigationService = mvxNavigationService;
            TryLogInCommand = new MvxAsyncCommand(TryLogIn);
        }

        public async Task TryLogIn()
        {
            try
            {
                await _apiHelper.Authenticate(Login, Password);
                await _mvxNavigationService.Navigate<GamesViewModel>();
            }
            catch(Exception ex)
            {
                //TODO: show error message
            }
        }

    }
}
