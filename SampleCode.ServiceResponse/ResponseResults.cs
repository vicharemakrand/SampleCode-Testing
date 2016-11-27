using SampleCode.ViewModels;
using System.Collections.Generic;

namespace SampleCode.ServiceResponse
{
    public class ResponseResults<VM> : BaseResponseResult  where VM:BaseViewModel
    {
        public List<VM> ViewModels { get; set; } 
    }
}
