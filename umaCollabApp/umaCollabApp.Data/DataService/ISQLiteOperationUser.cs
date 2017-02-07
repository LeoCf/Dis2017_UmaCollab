using System.Collections.Generic;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
    public interface ISQLiteOperationUser
    {
        void Save(User user);

        void Delete(User user);

        void Update(User user);

        bool Login(User user);

        IList<User> Select();

        IList<User> Select(int usedId);

        IList<User> Select(User user);
    }
}
