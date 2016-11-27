using FizzWare.NBuilder;
using SampleCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.IOC.Test.MockTestData
{
    public class UserModelTestData
    {
        public static List<UserModel> GetTestRecords()
        {
            return Builder<UserModel>.CreateListOfSize(10).Build().ToList();
        }
    }
}
