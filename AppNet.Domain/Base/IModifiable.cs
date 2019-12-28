using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Domain.Base
{
    public interface IModifiable
    {
        [Required]
        int ModifyBy { get; set; }
        [Required]
        DateTime ModifyOn { get; set; }

    }
}
