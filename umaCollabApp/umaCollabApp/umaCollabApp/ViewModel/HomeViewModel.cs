

using System.Windows.Input;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using umaCollabApp.Views.Projects;
using umaCollabApp.Views.Teams;
using umaCollabApp.Views.Users;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private ICommand _usersCommand;
        private ICommand _projectsCommand;
        private ICommand _statesCommand;
        private ICommand _teamsCommand;
        private ICommand _votingsCommand;


        public ICommand UsersCommand
        {
            get
            {
                return _usersCommand ?? (_usersCommand = new Command(() =>
                {
                    Navigation.PushAsync(new UsersViewPage());
                }));
            }
        }
               

        public ICommand ProjectsCommand
        {
            get
            {
                return _projectsCommand ?? (_projectsCommand = new Command(() =>
                {
                    Navigation.PushAsync(new ProjectsViewPage());
                }));
            }
        }

     

        public ICommand TeamsCommand
        {
            get
            {
                return _teamsCommand ?? (_teamsCommand = new Command(() =>
                {
                    Navigation.PushAsync(new TeamsViewPage());
                }));
            }
        }
    }
}
