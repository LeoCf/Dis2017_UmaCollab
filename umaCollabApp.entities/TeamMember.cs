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
    public class TeamMember : EntitiesBase
    {
        // corresponde a "user has team"

        [Column("TEAMMEMBERID")]
        [AutoIncrement, PrimaryKey]
        public int TeamMemberId { get; set; }


        [ForeignKey(typeof(User))]     // Chave estrangeira
        [Column("USERID")]
        public int UserId { get; set; }

        // propriedades virtuais usadas para ciar as relações
        // lado "muitos"
        [ManyToOne]
        public virtual Team Team { get; set; }

        public virtual User User { get; set; }



        public override void Validate()
        {
            // rever validações para estes inputs
        }
    }
}
