using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
    class TeamDetailsViewModel : ViewModelList<User>
    {
        private UserDataService _dataService;
        private ICommand _backCommand;
        private User _currentItem;
        

        


        public TeamDetailsViewModel()
        {
            _dataService = new UserDataService(DependencyService.Get<ISQLite>().GetConnection());

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

                    Navigation.PushAsync(new TeamDetailsViewPage());
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


