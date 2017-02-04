using umaCollabApp.Data;
using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using umaCollabApp.ViewModel.Projects;
using Xamarin.Forms;

namespace umaCollabApp.Views.Projects
{
    public partial class RatePage : IMessage
    {
        public RatePage()
        {
            InitializeComponent();

            var viewModel = new ProjectRateViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;

            BindingContext = viewModel;
        }
    }
}
