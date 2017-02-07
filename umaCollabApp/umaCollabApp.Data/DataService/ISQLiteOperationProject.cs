using System.Collections.Generic;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
    public interface ISQLiteOperationProject
    {
        void Save(Project project,int userId);

        void Delete(Project project);

        void Update(Project project);

        IList<Project> Select();

        IList<Project> SelectByUser(int usedId);
    }
}
