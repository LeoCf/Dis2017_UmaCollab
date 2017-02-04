using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel;
using Xamarin.Forms;

namespace umaCollabApp.Views
{
    public partial class StartViewPage : IMessage
    {
        public StartViewPage()
        {
            InitializeComponent();

            var viewModel = new StartViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;
            BindingContext = viewModel;
        }
    }
}
