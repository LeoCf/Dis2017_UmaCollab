using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite.Net;
using umaCollabApp.Data.DataService;
using umaCollabApp.Entities;
using umaCollabApp;
using umaCollabApp.entities;
using SQLiteNetExtensions.Extensions;

namespace umaCollabApp.Data
{
    public class UserDataService : ISQLiteOperationUser
    {
        private SQLiteConnection _connection;

        // obter a conexão e criar a tabela de users
        public UserDataService(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<User>();
        }

        // guardar user
        public void Save(User user)
        {
            _connection.Insert(user);
        }

        // apagar user
        public void Delete(User user)
        {
            _connection.Delete(user);
        }

        // atualizar user
        public void Update(User user)
        {
            _connection.Update(user);
            
        }

        public void AddUserTeam(User user,Team team)
        {

            user.Teams.Add(team);
            _connection.UpdateWithChildren(user);
        }

        

        public bool Login(User user)
        {
            string userEmail = user.Email;
            string userPassword = user.Password;
            var dados = _connection.Table<User>();
            var verification = dados.Where(x => x.Email == userEmail && x.Password == userPassword).FirstOrDefault();
            if (verification != null)
            {
                return true;
            }
            else
                return false;
                     
        }

        public int GetCurrentUser(User user)
        {
            var dados = _connection.Table<User>();
            var currentUser = dados.Where(x => x.Email == user.Email).FirstOrDefault();
            return currentUser.UserId;
        }
        
        // obter todos os users
        public IList<User> Select()
        {
            return _connection.Table<User>().ToList();
        }

    }
}
