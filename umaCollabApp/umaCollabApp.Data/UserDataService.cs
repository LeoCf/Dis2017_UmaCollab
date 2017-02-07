using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using umaCollabApp.Data.DataService;
using umaCollabApp.Entities;

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

        public bool Login(User user)
        {
            string userEmail = user.Email;
            string userPassword = user.Password;            
            var dados = _connection.Table<User>();
            var verification = dados.Where(x => x.Email == userEmail && x.Password == userPassword).FirstOrDefault();
            if (verification != null)
                return true;
            else
                return false;                    
        }

        // obter o Id do user atual
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

        // obter um user específico por Id
        public IList<User> Select(int userId)
        {
            return _connection.Table<User>().Where(x => x.UserId == userId).ToList();
        }

        public IList<User> Select(User user)
        {
            return _connection.Table<User>().Where(x => x == user).ToList();
        }

    }
}
