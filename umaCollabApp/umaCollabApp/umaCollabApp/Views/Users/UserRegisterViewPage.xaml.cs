using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel.Users;

namespace umaCollabApp.Views.Users
{
    public partial class UserRegisterViewPage : IMessage
    {
        public UserRegisterViewPage()
        {
            InitializeComponent();
            var viewModel = new UserRegisterViewModel();
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;
            BindingContext = viewModel;
        }

        public UserRegisterViewPage(User user)
        {
            InitializeComponent();
            var viewModel = new UserRegisterViewModel(user);
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;
            BindingContext = viewModel;
        }       
    }
}
