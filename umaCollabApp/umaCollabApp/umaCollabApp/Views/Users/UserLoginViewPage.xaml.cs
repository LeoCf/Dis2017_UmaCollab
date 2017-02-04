using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Users;


namespace umaCollabApp.Views.Users
{
    public partial class UserLoginViewPage : IMessage
    {
        public UserLoginViewPage()
        {
            InitializeComponent();
            var viewModel = new UserLoginViewModel();
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }

        public UserLoginViewPage(User user)
        {
            InitializeComponent();
            var viewModel = new UserLoginViewModel(user);
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }


    }
}
