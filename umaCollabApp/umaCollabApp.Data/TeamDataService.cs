using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities;
using umaCollabApp.Entities;
using SQLiteNetExtensions.Extensions;

namespace umaCollabApp.Data
{
    public class TeamDataService : ISQLiteOperationTeam
    {
        private SQLiteConnection _connection;

        public TeamDataService(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Team>();
            _connection.CreateTable<TeamMember>();
        }

        public void Save(Team team)
        {
            _connection.Insert(team);
        }

        public void Delete(Team team)
        {
            _connection.Delete(team);
        }

        public void Update(Team team)
        {
            _connection.Update(team);
        }

        public IList<Team> Select()
        {
            return _connection.Table<Team>().ToList();
        }

        public void addUserTeam(Team team, User user)
        {

            team.Users .Add( user);
            _connection.UpdateWithChildren(team);
        }


        public IList<User> ShowUserTeam(Team team)
        {
       
            return team.Users;
        }

    }
}
