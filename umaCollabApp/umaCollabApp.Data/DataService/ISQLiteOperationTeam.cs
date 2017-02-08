using System.Collections.Generic;
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

        void addUserTeam(Team team, User user);

       IList<User> ShowUserTeam(Team team);


    }
}
