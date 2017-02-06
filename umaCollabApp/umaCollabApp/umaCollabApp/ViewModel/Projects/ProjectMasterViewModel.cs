using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.ViewModel.Projects;
using umaCollabApp.Data.DataService;
using umaCollabApp.Entities;
using umaCollabApp.Data;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel
{
    class ProjectMasterViewModel
    {
        private ProjectDataService _dataService;
        public ProjectListViewModel projectList { get; set; }
        public ProjectListViewModel projectListUser { get; set; }
        

        public ProjectMasterViewModel()
        {

            _dataService = new ProjectDataService(DependencyService.Get<ISQLite>().GetConnection());
            _dataService.Select();
            this.projectList = new ProjectListViewModel(_dataService);
      

            
        }
    }
}
