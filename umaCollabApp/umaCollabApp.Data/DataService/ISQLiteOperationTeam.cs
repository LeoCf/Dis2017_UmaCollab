using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.entities;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
    public interface ISQLiteOperationTeam
    {
        void Save(Team team);

        void Delete(Team team);

        void Update(Team team);

        IList<Team> Select();

    }
}
