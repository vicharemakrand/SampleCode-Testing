using SampleCode.IRepositories;
using SampleCode.IRepositories.Core;
using SampleCode.Models;
using SampleCode.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.Repositories
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {

        public UserRepository(DataFactory dataFactory)
            : base(dataFactory) {
        }

        public UserModel GetUserByName(string userName)
        {
            var category = this.DataContext.Users.Where(c => c.UserName == userName).FirstOrDefault();

            return category;
        }

    }
 
}
