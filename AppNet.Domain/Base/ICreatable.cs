using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Domain.Base
{
    public interface ICreatable
    {
        [Required]
        int CreatedBy { get; set; }
        [Required]
        DateTime CreateOn { get; set; }

    }
}
