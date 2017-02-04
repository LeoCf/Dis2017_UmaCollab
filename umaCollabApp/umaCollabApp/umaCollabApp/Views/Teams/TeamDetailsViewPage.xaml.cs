using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.ViewModel.Teams;

namespace umaCollabApp.Views.Teams
{
    public partial class TeamDetailsViewPage : IMessage
    {
        public TeamDetailsViewPage()
        {
            InitializeComponent();
            var viewModel = new TeamDetailsViewModel();
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }

    }
}
