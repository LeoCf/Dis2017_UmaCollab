using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Users;
using Xamarin.Forms;

namespace umaCollabApp.Views.Users
{
    public partial class UsersViewPage : IMessage
    {
        public UsersViewPage()
        {
            InitializeComponent();

            var viewModel = new UsersViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;
            BindingContext = viewModel;
        }
    }
}
