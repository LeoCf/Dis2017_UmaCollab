using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Data;
using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Users;
using Xamarin.Forms;

namespace umaCollabApp.Views.Users
{
    public partial class UserRegisterViewPage: IMessage
    {
        private User user;
        private UserDataService dataService;

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
