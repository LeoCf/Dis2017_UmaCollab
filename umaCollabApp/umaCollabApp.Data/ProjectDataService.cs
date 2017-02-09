using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using umaCollabApp.Data.DataService;
using umaCollabApp.Entities;
using umaCollabApp.entities;
using SQLiteNetExtensions.Extensions;

namespace umaCollabApp.Data
{
    public class ProjectDataService : ISQLiteOperationProject
    {
        private SQLiteConnection _connection;

        public ProjectDataService(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Project>();
        }

        public void Save(Project project, int userId)
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

        public void AddTeamProject(Project project, Team team)
        {
            project.Teams = new List<Team> { team };
            _connection.UpdateWithChildren(project);
        }

        public IList<Team> ShowProjectTeams (Project project)
        {
           return  _connection.Table<Team>().Where(x => x.ProjectId == project.ProjectId).ToList();

    }
    }
}

