using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Teams;
using Xamarin.Forms;

namespace umaCollabApp.Views.Teams
{
    public partial class TeamsViewPage : IMessage
    {
        public TeamsViewPage()
        {
            InitializeComponent();

            var viewModel = new TeamViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;
            BindingContext = viewModel;
        }
    }
}


