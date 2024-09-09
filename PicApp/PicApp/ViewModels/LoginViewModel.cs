using PicApp.Validations;
using PicApp.ViewModels.Base;
using PicApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PicApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _passwordUser;
        private readonly LoginValidation _loginValidation;
        public LoginViewModel()
        {
            _passwordUser = Preferences.Get("Password", String.Empty);
            _loginValidation = new LoginValidation();
            LoginCommand = new Command(OnLoginClicked, Validate);
            this.PropertyChanged +=
               (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool Validate(object arg)
        {
            if (VaidateMessage() == null) 
                return true;
            return false;
        }

        private string VaidateMessage()
        {
            var result = _loginValidation.Validate(this);
            if (result.Errors.Count > 0) 
            { 
                return result.Errors[0].ErrorMessage;
            }
            return null;
        }

        private async void OnLoginClicked(object obj)
        {
            if (_passwordUser == string.Empty)
            {
                Preferences.Set("Password", _password);
            }
            else
            {
                if (_passwordUser != Password)
                {
                    LoginError = "Неверный ПИН-код";
                    return;
                }
            }
            await Application.Current.MainPage.Navigation.PushAsync(new GalleryPage());
        }

        /// <summary>Pin-code</summary>
        private string _password = string.Empty;
        /// <summary>Pin-code</summary>
        public string Password
        {
            get { return _password; }
            set 
            {
                LoginError = VaidateMessage();
                SetProperty(ref _password, value);
            }
        }

        /// <summary>Сообщение об ошибке</summary>
        private string _loginError;
        /// <summary>Сообщение об ошибке</summary>
        public string LoginError
        {
            get { return _loginError; }
            set { SetProperty(ref _loginError, value); }
        }

        public Command LoginCommand { get; }


    }
}
