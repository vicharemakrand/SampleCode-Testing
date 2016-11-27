using SampleCode.ViewModels;
using System.Collections.Generic;

namespace SampleCode.ServiceResponse
{
    public class ResponseResult<VM> : BaseResponseResult
        where VM:BaseViewModel
    {
        public VM ViewModel { get; set; }
    }
}
