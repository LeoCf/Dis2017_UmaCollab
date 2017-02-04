using umaCollabApp.Data;
using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Projects;

namespace umaCollabApp.Views.Projects
{
    public partial class ProjectRegisterViewPage : IMessage
    {
        private Project project;
        private ProjectDataService dataService;

        public ProjectRegisterViewPage()
        {
            InitializeComponent();
            var viewModel = new ProjectRegisterViewModel();
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }

        public ProjectRegisterViewPage(Project project)
        {
            InitializeComponent();
            var viewModel = new ProjectRegisterViewModel(project);
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }

        
    }
}
