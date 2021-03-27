using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTMovie.Core.Entity;
using BTMovie.DataAccess.GenericRepository;
using BTMovie.WebServices.Abstract.OMDB;
using Microsoft.AspNetCore.Mvc;

namespace BTMovieManagement.Controllers
{
    public class BaseController : Controller
    {
        public readonly IGenericRepository<BTUser> genericRepository;
        public readonly IOMDBWebService oMDBWebService;
        public readonly IGenericRepository<OMDBMovieList> omdbMovieService;
        public BaseController(IGenericRepository<BTUser> _genericRepository, IOMDBWebService _oMDBWebService, IGenericRepository<OMDBMovieList> _omdbMovieService)
        {
            genericRepository = _genericRepository;
            oMDBWebService = _oMDBWebService;
            omdbMovieService = _omdbMovieService;
        }
    }
}
