using System.Collections.Generic;
using umaCollabApp.entities;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
    public interface ISQLiteOperationProject
    {
        void Save(Project project,int userId);

        void Delete(Project project);

        void Update(Project project);

        void AddTeamProject(Project project, Team team);

        IList<Project> Select();

        IList<Project> SelectByUser(int usedId);

        IList<Team> ShowProjectTeams(Project project);

    }
}
