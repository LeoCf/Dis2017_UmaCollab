using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
    public interface ISQLiteOperationProject
    {
        void Save(Project project);

        void Delete(Project project);

        void Update(Project project);

        IList<Project> Select();
    }
}
