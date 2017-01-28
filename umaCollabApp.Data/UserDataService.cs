using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        // obter todos os users
        public IList<User> Select()
        {
            return _connection.Table<User>().ToList();
        }

    }
}
