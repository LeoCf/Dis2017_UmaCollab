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
    [Table("TEAMMEMBER")]

    public class TeamMember : EntitiesBase
    {

        [PrimaryKey, AutoIncrement]
        public int TeamMemberId { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ForeignKey(typeof(Team))]
        public int TeamId { get; set; }

        public override void Validate()
        {
            // rever validações para estes inputs
        }

    }
}
