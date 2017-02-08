using System.Collections.Generic;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using Xamarin.Forms;

/*
 * Views models dos detalhes da equipa formada faz o binding com a vista  respectiva , possuem a logica dos comandos para a navegaçao
 */
namespace umaCollabApp.ViewModel.Teams
{
    class TeamDetailsViewModel : ViewModelList<User>
    {
        private ICommand _backCommand;
        private TeamDataService _teamDataService;
        private IList<User> _currentTeamUser;

        public TeamDetailsViewModel(Team CurrentTeam)
        {
            _teamDataService = new TeamDataService(DependencyService.Get<ISQLite>().GetConnection());
            _currentTeamUser = _teamDataService.ShowUserTeam(CurrentTeam);
        }

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new Command(() =>
                {
                    Navigation.PushAsync(new HomeViewPage());
                }));
            }
        }
    }
}
