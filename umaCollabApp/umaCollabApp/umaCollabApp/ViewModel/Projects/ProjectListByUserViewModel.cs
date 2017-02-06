using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class ProjectListByUserViewModel : ViewModelList<Project>
    {
        public ObservableCollection<Project> projectUser { get; set; }
        private ProjectDataService _dataService;
        private ICommand _backCommand;
        private ICommand _rateCommand;
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
