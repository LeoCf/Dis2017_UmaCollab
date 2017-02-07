using System.Collections.ObjectModel;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
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
        private User _currentItem;

        public SelectMemberListViewModel()
        {
            LoadData();
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

                    Navigation.PushAsync(new TeamDetailsViewPage(CurrentItem));
                }                  
            }
        }

        private void LoadData()
        {
            // Dependency traz uma implementação de SQLite trazendo a conexão.
            _dataService = new UserDataService(DependencyService.Get<ISQLite>().GetConnection());

            //Entities é do tipo Observable Collection, que recebe uma lista. Aqui passamos a coleção de dados.
            Entities = new ObservableCollection<User>(_dataService.Select());
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
