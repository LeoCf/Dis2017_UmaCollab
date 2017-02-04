using System.Windows.Input;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using umaCollabApp.Views.Users;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel
{
    class StartViewModel : ViewModelBase
    {
        private ICommand _startCommand;
        private ICommand _userLoginCommand;
        private ICommand _userRegisterCommand;

        public ICommand StartCommand
        {
            get
            {
                return _startCommand ?? (_startCommand = new Command(() =>
                {
                    Navigation.PushAsync(new HomeViewPage());
                }));
            }
        }


        public ICommand UserLoginCommand
        {
            get
            {
                return _userLoginCommand ?? (_userLoginCommand = new Command(() =>
                {
                    Navigation.PushAsync(new UserLoginViewPage());
                }));
            }
        }


        public ICommand UserRegisterCommand
        {
            get
            {
                return _userRegisterCommand ?? (_userRegisterCommand = new Command(() =>
                {
                    Navigation.PushAsync(new UserRegisterViewPage());
                }));
            }
        }     

    }
}
