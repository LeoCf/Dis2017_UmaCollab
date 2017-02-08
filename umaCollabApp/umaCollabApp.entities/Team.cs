using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using umaCollabApp.entities.Base;
using umaCollabApp.entities.Exceptions;
using umaCollabApp.Entities;


namespace umaCollabApp.entities
{
    [Table("TBTEAM")]


    public class Team : EntitiesBase
    {
        private string _description;

        [Column("TEAMID")]
        [AutoIncrement, PrimaryKey]
        public int TeamId { get; set; }

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


        // propriedade virtual usada para ciar a relação um para muitos
        // TeamMembers é o lado "muitos", é uma ICollection (lista genérica). 
        [ManyToMany(typeof(TeamMember))]
        public List<User> Users { get; set; }
        

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Description))
            {
                throw new MandatoryException("Description must be filled");
            }

        }
    }
}
