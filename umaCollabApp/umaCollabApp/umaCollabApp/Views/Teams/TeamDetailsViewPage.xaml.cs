using umaCollabApp.entities;
using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel.Teams;

namespace umaCollabApp.Views.Teams
{
    public partial class TeamDetailsViewPage : IMessage
    {
        public TeamDetailsViewPage(Team CurrentItem)
        {
            InitializeComponent();
            var viewModel = new TeamDetailsViewModel(CurrentItem);
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;
            BindingContext = viewModel;
        }
    }
}
