using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SampleCode.ViewModels
{
    public class UserViewModel : AuditableViewModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

       [Display(Name = "First name")]
        public string FirstName { get; set; }

       [Display(Name = "Last name")]
       public string LastName { get; set; }

    }
}
