using BTMovie.Core.Entity;
using BTMovie.DataAccess.GenericRepository;
using BTMovie.Services.Abstract.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BTMovie.Services.Concrete.OMDB
{
    public class OMDBService : IOMDBService
    {
        public IGenericRepository<OMDBMovieList> genericRepository;
        public OMDBMovieList Add(OMDBMovieList entity)
        {
            genericRepository.Add(entity);
            return entity;
        }

        public IEnumerable<OMDBMovieList> All()
        {
            var model = genericRepository.All();
            return model;
        }

        public OMDBMovieList Get(int id)
        {
            var res = genericRepository.Get(id);
            return res;
        }

        public bool Remove(OMDBMovieList entity)
        {
            var res = genericRepository.Remove(entity);
            return res;
        }

        public bool Update(OMDBMovieList entity)
        {
            var res = genericRepository.Update(entity);
            return res;
        }

        public IEnumerable<OMDBMovieList> Where(Expression<Func<OMDBMovieList, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
