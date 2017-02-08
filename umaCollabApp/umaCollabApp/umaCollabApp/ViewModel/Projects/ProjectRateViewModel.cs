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
using umaCollabApp.Views.Projects;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Projects
{
    class ProjectRateViewModel: ViewModelList<Project>
    {
        private ProjectDataService _dataService;
        private ICommand _backCommand;
        private Project _currentItem;

        public ProjectRateViewModel()
        {
              // construtor vazio  
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

        private void SaveRateData()
        {
            // Dependency traz uma implementação de SQLite trazendo a conexão.
            _dataService = new ProjectDataService(DependencyService.Get<ISQLite>().GetConnection());
        }

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new Command(() =>
                {
                    //SaveRateData();
                    Navigation.PushAsync(new ProjectListViewPage());
                }));
            }
        }
    }
}
