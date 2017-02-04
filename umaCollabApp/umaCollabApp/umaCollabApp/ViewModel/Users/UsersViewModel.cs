using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Users;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Users
{
    class UsersViewModel : ViewModelBase
    {
        private ICommand _userListCommand;


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
