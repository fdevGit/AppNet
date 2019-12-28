using AppNet.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Domain.Models
{
    public class Role : IEntity, ICreatable, IModifiable, IAuditable
    {
        public int ModifyBy { get; set; }
        public DateTime ModifyOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateOn { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

    }
}
