﻿
using System.Collections.Generic;
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


        [ForeignKey(typeof(Project))]     // Chave estrangeira de projecto
        public int ProjectId { get; set; }
        [ManyToOne]                      //relaçao com projectos
        public Project project { get; set; }

        // propriedade virtual usada para ciar a relação um para muitos
        // TeamMembers é o lado "muitos", é uma ICollection (lista genérica). 
        [ManyToMany(typeof(TeamMember))]
        public List<User> Users { get; set; } = new List<User>();

        

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Description))
            {
                throw new MandatoryException("Description must be filled");
            }

        }
    }
}
