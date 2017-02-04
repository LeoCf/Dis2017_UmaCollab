using System.Collections.ObjectModel;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using umaCollabApp.Views.Projects;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Projects
{
    class ProjectListViewModel : ViewModelList<Project>
    {
        private ProjectDataService _dataService;
        private ICommand _backCommand;
        private ICommand _rateCommand;
        private Project _currentItem;


        public ProjectListViewModel()
        {
            LoadData();
        }

        public Project CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                RaisedPropertyChanged(() => CurrentItem);

                if (_currentItem != null)
                    Navigation.PushAsync(new ProjectRegisterViewPage(_currentItem));            
            }
        }

        private void LoadData()
        {   
            // Dependency traz uma implementação de SQLite trazendo a conexão.
            _dataService = new ProjectDataService(DependencyService.Get<ISQLite>().GetConnection());

            //Entities é do tipo Observable Collection, que recebe uma lista. Aqui passamos a coleção de dados.
            Entities = new ObservableCollection<Project>(_dataService.Select());
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

        public ICommand RateCommand
        {
            get
            {
                return _rateCommand ?? (_rateCommand = new Command(() =>
                {
                    Navigation.PushAsync(new RatePage());
                }));
            }
        }


    }
}
