using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel.Projects;
using Xamarin.Forms;

namespace umaCollabApp.Views.Projects
{
    public partial class ProjectListByUserViewPage : IMessage
    {
        public ProjectListByUserViewPage()
        {
            InitializeComponent();
            var viewModel = new ProjectListByUserViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;

            BindingContext = viewModel;
        }
    }
}
