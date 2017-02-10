using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using umaCollabApp.entities.Base;
using umaCollabApp.entities.Exceptions;
using SQLiteNetExtensions.Attributes;
using umaCollabApp.entities;

namespace umaCollabApp.Entities
{
    [Table("TBPROJECT")]

    public class Project : EntitiesBase
    {
        private string _name;
        private string _description;
        private int _duration;
        private int _projectRate;
        private int _memberLimit;
        
        [Column("PROJECTID")]
        [AutoIncrement, PrimaryKey]
        public int ProjectId { get; set; }

        [Column("NAME")]
        [MaxLength(150)]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisedPropertyChanged(() => Name);
            }
        }

        [Column("DESCRIPTION")]
        [MaxLength(200)]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisedPropertyChanged(() => Description);
            }
        }

        [Column("DURATION")]
        [MaxLength(3)]
        public int Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                RaisedPropertyChanged(() => Duration);
            }
        }

        [Column("MEMBERLIMIT")]
        [MaxLength(3)]
        public int MemberLimit
        {
            get { return _memberLimit; }
            set
            {
                _memberLimit = value;
                RaisedPropertyChanged(() => Duration);
            }
        }

        [Column("PROJECTRATE")]
        [MaxLength(5)]
        public int ProjectRate
        {
            get { return _projectRate; }
            set
            {
                _projectRate = value;
                RaisedPropertyChanged(() => Duration);
            }
        }

        [Column("MANAGERID")]
        [ForeignKey(typeof(User))]
        [MaxLength(20)]
        public int managerID { get; set; }

        //Relaão 1 para muitos com as equipas
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Team> Teams { get; set; } 

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Event> Events{ get; set; }


        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new MandatoryException("Project name must be filled");
            }

            if (string.IsNullOrEmpty(Description))
            {
                throw new MandatoryException("Description must be filled");
            }


            if (Duration == null || Duration == 0)
            {
                throw new MandatoryException("Duration must be filled and longer than zero days");
            }

            if (MemberLimit == null || MemberLimit == 0)
            {
                throw new MandatoryException("You must set the max number of members for this project");
            }
        }
    }
}
