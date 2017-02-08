
using System.Windows.Input;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Teams;
using Xamarin.Forms;

/*
 * Views models das teams com as funcões para navegar para as respectivas funcionalidades das teams ou seja
 * registar team , e listar equipa 
 */
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
