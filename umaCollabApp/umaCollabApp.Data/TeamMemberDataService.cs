using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.entities;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
    class TeamMemberDataService : ISQLiteOperationTeamMember
    {
        private SQLiteConnection _connection;
        private SQLiteConnection sQLiteConnection;

        public TeamMemberDataService(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<TeamMember>();
        }


        public void addTeamMember(TeamMember user)
        {
            _connection.Insert(user);
        }

        public void deleteTeamMember(TeamMember user)
        {
            _connection.Delete(user);
        }
    }
}
