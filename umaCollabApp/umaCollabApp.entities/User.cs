using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using umaCollabApp.entities;
using umaCollabApp.entities.Base;
using umaCollabApp.entities.Exceptions;

namespace umaCollabApp.Entities
{
    [Table("TBUSER")]

    public class User : EntitiesBase
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _password;
        private string _confirmPassword;

        [Column("USERID")]
        [AutoIncrement, PrimaryKey]
        public int UserId { get; set; }

        [Column("FIRSTNAME")]
        [MaxLength(150)]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisedPropertyChanged(() => FirstName);
            }
        }

        [Column("LASTNAME")]
        [MaxLength(150)]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisedPropertyChanged(() => LastName);
            }
        }

        [Column("EMAIL")]
        [MaxLength(100)]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisedPropertyChanged(() => Email);
            }
        }

        [Column("PHONENUMBER")]
        [MaxLength(20)]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                RaisedPropertyChanged(() => PhoneNumber);
            }
        }


        [Column("PASSWORD")]
        [MaxLength(20)]
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisedPropertyChanged(() => Password);
            }
        }

        [Column("CONFIRMPASSWORD")]
        [MaxLength(20)]
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                RaisedPropertyChanged(() => ConfirmPassword);
            }
        }


        // propriedade virtual usada para ciar a relação um para muitos
        // TeamMembers é o lado "muitos", é uma ICollection (lista genérica). 
        [OneToMany]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }



        public override void Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                throw new MandatoryException("First Name must be filled");
            }

            if (string.IsNullOrEmpty(LastName))
            {
                throw new MandatoryException("Last Name must be filled");
            }

            if (string.IsNullOrEmpty(Email))
            {
                throw new MandatoryException("Email must be filled");
            }

            if (string.IsNullOrEmpty(PhoneNumber))
            {
                throw new MandatoryException("Phone Number must be filled");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new MandatoryException("Password must be filled");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new MandatoryException("Password must be confirmed");
            }
        }
    }
}
