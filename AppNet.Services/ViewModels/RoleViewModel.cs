using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.ViewModels
{
    public class RoleViewModel : BaseViewModel
    {
        public string CreatedByName { get; set; }
        public string CreatedOnStr { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedByName { get; set; }
        public string ModifiedOnStr { get; set; }
        public DateTime ModifiedOn { get; set; }

        public string Name { get; set; }
        [MaxLength(1)]
        public string StatusName { get; set; }
    }
}
