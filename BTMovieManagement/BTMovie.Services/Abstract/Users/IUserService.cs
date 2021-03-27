using BTMovie.Core.Entity;
using BTMovie.DataAccess.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTMovie.Services.Abstract.Users
{
    public interface IUserService : IGenericRepository<BTUser>
    {

        BTUser GetUserName(string userName);
    }
}
