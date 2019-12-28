using AppNet.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Domain.Models
{
    public class User : IEntity, ICreatable, IModifiable, IDeletable, IAuditable
    {
        public int ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateOn { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", Name, SurName); } }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
