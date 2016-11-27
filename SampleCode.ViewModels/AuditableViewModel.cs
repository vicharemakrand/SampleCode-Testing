using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SampleCode.ViewModels
{
    public abstract class AuditableViewModel : BaseViewModel
    {
        [HiddenInput]
        public byte[] TimeStamp { get; set; }

        [Display(Name = "Updated On")]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "Updated By")]
        public long UpdatedBy { get; set; }
    }
}
