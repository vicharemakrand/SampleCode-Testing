using SampleCode.IOC.Test.MockTestData;
using SampleCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.IOC.Test
{
    public static class MockEntities
    {
        public static Dictionary<string, dynamic> MockData = new Dictionary<string, dynamic>();

        public static void LoadData()
        {
            if (!MockData.ContainsKey(typeof(UserModel).Name))
            {
                MockData.Add(typeof(UserModel).Name, UserModelTestData.GetTestRecords());
            }
        }

        public static List<T> GetData<T>() where T : class
        {
            return (List<T>)MockData[typeof(T).Name];
        }
    }
}
