using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.entities;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
      public  interface ISQLiteOperationTeamMember
     {


        void addTeamMember(TeamMember user);

        void deleteTeamMember(TeamMember user);


    }
}
