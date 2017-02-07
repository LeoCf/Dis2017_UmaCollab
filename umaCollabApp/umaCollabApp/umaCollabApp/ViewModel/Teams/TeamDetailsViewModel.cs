using System.Windows.Input;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Teams
{
    class TeamDetailsViewModel : ViewModelList<User>
    {
        private ICommand _backCommand;
        private User _currentItem;

        public TeamDetailsViewModel(User CurrentItem)
        {
            _currentItem = CurrentItem;
        }

        public User CurrentItem
        {
            get { return _currentItem; }
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
