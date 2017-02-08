﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities;
using umaCollabApp.Entities;

namespace umaCollabApp.Data
{
    public class TeamDataService : ISQLiteOperationTeam
    {
        private SQLiteConnection _connection;
        private SQLiteConnection sQLiteConnection;

        public TeamDataService(SQLiteConnection connection)
        {
            // _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection = connection;
            _connection.CreateTable<Team>();
           
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


        public IList<User> ShowUserTeam(Team team)
        {

            var userTable = _connection.Table<Team>();
            var currentTeam=userTable.Where(x => x.TeamId == team.TeamId).FirstOrDefault();
            return currentTeam.Users.ToList();

        }

    }
}