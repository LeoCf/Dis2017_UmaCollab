using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;
using umaCollabApp.Data.DataService;
using umaCollabApp.Entities;
using umaCollabApp;

namespace umaCollabApp.Data
{
    public class ProjectDataService : ISQLiteOperationProject
    {
        private SQLiteConnection _connection;
        

        public ProjectDataService(SQLiteConnection connection)
        {
            // _connection = DependencyService.Get<ISQLite>().GetConnection();


            _connection = connection;
            _connection.CreateTable<Project>();
        }



        public void Save(Project project,int userId)
        {

            project.managerID = userId;
            _connection.Insert(project);

        }

        public void Delete(Project project)
        {
            _connection.Delete(project);
        }

        public void Update(Project project)
        {
            _connection.Update(project);
        }

        public IList<Project> Select()
        {
            return _connection.Table<Project>().ToList();
        }

        public IList<Project> SelectByUser(int userId)
        {
            return _connection.Table<Project>().Where(x => x.managerID == userId).ToList();
        }


    }
}
