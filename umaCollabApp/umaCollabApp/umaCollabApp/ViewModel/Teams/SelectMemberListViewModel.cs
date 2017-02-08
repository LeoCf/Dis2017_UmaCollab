using System.Collections.ObjectModel;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using umaCollabApp.Views.Teams;
using Xamarin.Forms;

/*
 * Views models da selecçao de utilizador a adicionar a uma equipa
 *  faz o binding com a vista  respectiva , possuem a logica dos comandos para a navegaçao
 */
namespace umaCollabApp.ViewModel.Teams
{
    class SelectMemberListViewModel : ViewModelList<User>
    {
        private UserDataService _dataService;
        private TeamDataService _teamDataService;
        private ICommand _backCommand;
        private User _currentItem;
        private Team _currentTeam;

        public SelectMemberListViewModel(Team _currentTeam)
        {
            // Dependency traz uma implementação de SQLite trazendo a conexão.
            _dataService = new UserDataService(DependencyService.Get<ISQLite>().GetConnection());
            _teamDataService = new TeamDataService(DependencyService.Get<ISQLite>().GetConnection());
            //Entities é do tipo Observable Collection, que recebe uma lista. Aqui passamos a coleção de dados.
            Entities = new ObservableCollection<User>(_dataService.Select());
            this._currentTeam = _currentTeam;
        }

        public User CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                RaisedPropertyChanged(() => CurrentItem);

                if (_currentItem != null)
                {
                    _teamDataService.addUserTeam(_currentTeam, _currentItem);
                    Navigation.PushAsync(new TeamDetailsViewPage(_currentTeam));
                }                  
            }
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
