using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
    public interface ISQLiteOperationUser
    {
        void Save(User user);

        void Delete(User user);

        void Update(User user);

        void Login(User user);

        IList<User> Select();


    }
}
