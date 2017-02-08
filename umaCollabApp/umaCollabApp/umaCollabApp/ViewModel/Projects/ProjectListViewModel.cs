using System.Collections.ObjectModel;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using umaCollabApp.Views.Projects;
using Xamarin.Forms;

/*
 * Views models da listagem de projectos faz o binding com a vista  respectiva , possuem a logica dos comandos para a navegaçao
 */
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
            _dataService = new ProjectDataService(DependencyService.Get<ISQLite>().GetConnection());
            Entities = new ObservableCollection<Project>(_dataService.Select());
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
