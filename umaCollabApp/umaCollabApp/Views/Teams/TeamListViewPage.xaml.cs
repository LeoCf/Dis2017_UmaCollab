using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Teams;
using Xamarin.Forms;

namespace umaCollabApp.Views.Teams
{
    public partial class TeamListViewPage : IMessage
    {
        public TeamListViewPage()
        {
            InitializeComponent();
            var viewModel = new TeamListViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;

            BindingContext = viewModel;
        }


        public TeamListViewPage(ObservableCollection<Team> team)
        {
            InitializeComponent();
            var viewModel = new TeamListViewModel();
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }

    }
}
