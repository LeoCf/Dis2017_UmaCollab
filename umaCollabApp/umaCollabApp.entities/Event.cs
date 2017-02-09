using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.entities.Base;
using umaCollabApp.Entities;

namespace umaCollabApp.entities
{
    [Table("TBEVENT")]

    public class Event : EntitiesBase
    {
        private string _description;
        private string _name;
        private DateTime _date;

        [Column("EVENTID")]
        [AutoIncrement, PrimaryKey]
        public int EventId { get; set; }

        [Column("DESCRIPTION")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisedPropertyChanged(() => Description);
            }
        }

        [Column("NAME")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisedPropertyChanged(() => Name);
            }
        }

        [Column("DATE")]
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                RaisedPropertyChanged(() => Date);
            }
        }

        [ForeignKey(typeof(Project))]
        public int ProjectId { get; set; }
        [ManyToOne]
        public Project project { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
