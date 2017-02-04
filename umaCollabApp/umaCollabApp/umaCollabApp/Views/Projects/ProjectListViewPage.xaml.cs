using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Projects;


namespace umaCollabApp.Views.Projects
{
    public partial class ProjectListViewPage : IMessage
    {
        public ProjectListViewPage()
        {
            InitializeComponent();
            var viewModel = new ProjectListViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;

            BindingContext = viewModel;
        }
    }
}
