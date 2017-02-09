using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.entities;
using umaCollabApp.Entities;

namespace umaCollabApp.Data.DataService
{
    interface ISQLiteOperationEvent
    {
        void save(Event events);

        void update(Event events);

        void delete(Event events);

        void addEventToProject(Project project, Event events);



    }
}
