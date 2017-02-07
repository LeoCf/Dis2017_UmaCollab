using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel.Users;

namespace umaCollabApp.Views.Users
{
    public partial class UserProfileViewPage : IMessage
    {
        public UserProfileViewPage(User user)       
        {
            InitializeComponent();
            var viewModel = new UserProfileViewModel();
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;
            BindingContext = viewModel;
        }
    }
}

