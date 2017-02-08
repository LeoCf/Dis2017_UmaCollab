using System.Collections.Generic;
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

namespace umaCollabApp.ViewModel.Teams
{
    class SelectMemberListViewModel : ViewModelList<User>
    {
        private UserDataService _dataService;
        private ICommand _backCommand;
        private ICommand _insertUser;
        private User _currentUser;
        private Team _currentTeam;
        private IList<User> currentUsers;
       


        public SelectMemberListViewModel()
        {
            // Dependency traz uma implementação de SQLite trazendo a conexão.
            _dataService = new UserDataService(DependencyService.Get<ISQLite>().GetConnection());
            //Entities é do tipo Observable Collection, que recebe uma lista. Aqui passamos a coleção de dados.
            
            
        }

        


        public Team CurrentTeam
        {
            get { return _currentTeam; }
            set
            {
                _currentTeam = value;
                RaisedPropertyChanged(() => CurrentTeam);

                if (_currentTeam != null)
                {

                    Navigation.PushAsync(new TeamDetailsViewPage());
                }
            }
        }


        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                RaisedPropertyChanged(() => CurrentUser);

                if (_currentUser != null)
                {

                    Navigation.PushAsync(new TeamDetailsViewPage());
                }
                    
            }
        }


        public ICommand insertUser
        {
            get
            {
                return _insertUser ?? (_insertUser= new Command(() =>
                {
                    _dataService.AddUserTeam(_currentUser, _currentTeam);
                    Navigation.PushAsync(new HomeViewPage());
                }));
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
