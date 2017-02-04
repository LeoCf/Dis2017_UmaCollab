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
    public partial class UserListViewPage : IMessage
    {



        public UserListViewPage()
        {
            InitializeComponent();
            var viewModel = new UserListViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;

            BindingContext = viewModel;
        }
    }
}
