using System.Collections.Generic;
using umaCollabApp.entities;

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
