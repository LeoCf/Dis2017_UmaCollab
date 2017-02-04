using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Projects;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Projects
{
    class ProjectsViewModel : ViewModelBase
    {
        private ICommand _projectRegisterCommand;
        private ICommand _projectListCommand;

        public ICommand ProjectRegisterCommand
        {
            get
            {
                return _projectRegisterCommand ?? (_projectRegisterCommand = new Command(() =>
                {
                    Navigation.PushAsync(new ProjectRegisterViewPage());
                }));
            }
        }



        public ICommand ProjectListCommand
        {
            get
            {
                return _projectListCommand ?? (_projectListCommand = new Command(() =>
                {
                    Navigation.PushAsync(new ProjectListViewPage());
                }));
            }
        }
    }
}
