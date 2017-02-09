using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities;
using umaCollabApp.Entities;

namespace umaCollabApp.Data
{
    class EventDataService : ISQLiteOperationEvent
    {
        private SQLiteConnection _connection;


        public EventDataService(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Event>();
        }
        public void addEventToProject(Project project, Event events)
        {
            project.Events = new List<Event> { events };
            _connection.UpdateWithChildren(project);
        }

        public void delete(Event events)
        {
            _connection.Delete(events);
        }

        public void save(Event events)
        {
            _connection.Insert(events);
        }

        public void update(Event events)
        {
            _connection.Update(events);
        }
    }
}
