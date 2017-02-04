using System.Collections.ObjectModel;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using umaCollabApp.Views.Teams;
using umaCollabApp.Views.Users;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Teams
{
    class TeamListViewModel : ViewModelList<Team>
    {
        private TeamDataService _dataService;
        private ICommand _selectMember;
        private ICommand _backCommand;


        public TeamListViewModel()
        {
            LoadData();
        }


        private void LoadData()
        {
            // Dependency traz uma implementação de SQLite trazendo a conexão.
            _dataService = new TeamDataService(DependencyService.Get<ISQLite>().GetConnection());

            //Entities é do tipo Observable Collection, que recebe uma lista. Aqui passamos a coleção de dados.
            Entities = new ObservableCollection<Team>(_dataService.Select());
        }



        public ICommand SelectMemberCommand
        {
            get
            {
                return _selectMember ?? (_selectMember = new Command(() =>
                {
                    Navigation.PushAsync(new SelectMemberListPage());
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
