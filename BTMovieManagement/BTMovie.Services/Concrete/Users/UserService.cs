using BTMovie.Core.Entity;
using BTMovie.DataAccess.GenericRepository;
using BTMovie.Services.Abstract.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTMovie.Services.Concrete.Users
{
    public class UserService 
    {
        public IGenericRepository<BTUser> genericRepository;

        public UserService(IGenericRepository<BTUser> _genericRepository)
        {
            genericRepository = _genericRepository;
        }

        public BTUser Add(BTUser model)
        {
            genericRepository.Add(model);
            return model;
        }
  
    }
}
