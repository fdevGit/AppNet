using AppNet.Services.Services.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Errors = new List<string>();
        }
        public bool IsError { get; set; }
        public List<string> Errors { get; set; }
        public int Id { get; set; }
        public bool Status { get; set; }
        public UserManager UserManager;
        public void AddError(string message)
        {
            this.IsError = true;
            if (Errors == null) Errors = new List<string>();
            {
                Errors.Add(message);
            }
        }
    }
}