using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Projects;
using umaCollabApp.Views.Teams;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Teams
{
    class TeamViewModel : ViewModelBase
    {
        private ICommand _teamRegisterCommand;
        private ICommand _teamListCommand;


        public ICommand TeamRegisterCommand
        {
            get
            {
                return _teamRegisterCommand ?? (_teamRegisterCommand = new Command(() =>
                {
                    Navigation.PushAsync(new TeamRegisterViewPage());
                }));
            }
        }



        public ICommand TeamListCommand
        {
            get
            {
                return _teamListCommand ?? (_teamListCommand = new Command(() =>
                {
                    Navigation.PushAsync(new TeamListViewPage());
                }));
            }
        }

    }
}
