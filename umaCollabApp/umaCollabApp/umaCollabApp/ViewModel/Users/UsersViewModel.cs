using System.Windows.Input;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Users;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Users
{
    class UsersViewModel : ViewModelBase<User>
    {
        private ICommand _userListCommand;
        private ICommand _userProfileCommand;

        public ICommand UserProfileCommand
        {
            get
            {
                return _userProfileCommand ?? (_userProfileCommand = new Command(() =>
                {
                    Navigation.PushAsync(new UserProfileViewPage(CurrentEntity));
                }));
            }
        }

        public ICommand UserListCommand
        {
            get
            {
                return _userListCommand ?? (_userListCommand = new Command(() =>
                {
                    Navigation.PushAsync(new UserListViewPage());
                }));
            }
        }
    }
}
