using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Data;
using umaCollabApp.entities;
using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Teams;
using Xamarin.Forms;

namespace umaCollabApp.Views.Teams
{
    public partial class TeamRegisterViewPage : IMessage
    {
        private Team team;
        private TeamDataService dataService;

        public TeamRegisterViewPage()
        {
            InitializeComponent();
            var viewModel = new TeamRegisterViewModel();
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }

        public TeamRegisterViewPage(Team team)
        {
            InitializeComponent();
            var viewModel = new TeamRegisterViewModel(team);
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }


    }
}
