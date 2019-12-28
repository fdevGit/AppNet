using System;
using System.Collections.Generic;
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
        public string StatusName { get; set; }
    }
}
