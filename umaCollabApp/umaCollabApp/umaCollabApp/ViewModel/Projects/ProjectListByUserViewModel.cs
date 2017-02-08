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
 * Views models dos projectos faz o binding com a vista  respectiva , possuem a logica dos comandos para a navegaçao
 */
namespace umaCollabApp.ViewModel.Projects
{
    class ProjectListByUserViewModel : ViewModelList<Project>
    {
        public ObservableCollection<Project> projectUser { get; set; }
        private ProjectDataService _dataService;
        private ICommand _backCommand;
        private Project _currentItem;

        public ProjectListByUserViewModel()
        {
            _dataService = new ProjectDataService(DependencyService.Get<ISQLite>().GetConnection());
            projectUser = new ObservableCollection<Project>(_dataService.SelectByUser(GlobalSettings.currentUserId));
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
    }
}
