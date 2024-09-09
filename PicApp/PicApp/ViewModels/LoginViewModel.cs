using PicApp.ViewModels.Base;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PicApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _passwordUser;
        public LoginViewModel()
        {
            _passwordUser = Preferences.Get("Password", String.Empty);
            LoginCommand = new Command(OnLoginClicked);
        }

        private void OnLoginClicked(object obj)
        {
            
        }

        /// <summary>Pin-code</summary>
        private string _password = string.Empty;
        /// <summary>Pin-code</summary>
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        /// <summary>Сообщение об ошибке</summary>
        private string _loginError;
        /// <summary>Сообщение об ошибке</summary>
        public string LoginError
        {
            get { return _loginError; }
            set { SetProperty(ref _password, value); }
        }

        public Command LoginCommand { get; }


    }
}
