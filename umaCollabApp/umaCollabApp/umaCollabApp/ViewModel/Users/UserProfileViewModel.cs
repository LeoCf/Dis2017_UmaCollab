
using System.Collections.ObjectModel;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Users;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Users
{
    class UserProfileViewModel : ViewModelList<User>
    {
        private User _currentItem;
        private UserDataService _dataService;
        public ObservableCollection<User> CurrentUser { get; set; }

        public UserProfileViewModel()
        {
            _dataService = new UserDataService(DependencyService.Get<ISQLite>().GetConnection());
            CurrentUser = new ObservableCollection<User>(_dataService.Select(GlobalSettings.currentUserId));
        }

        public User CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                RaisedPropertyChanged(() => CurrentItem);

                if (_currentItem != null)
                    Navigation.PushAsync(new UserRegisterViewPage(_currentItem));
            }
        }
    }
}
