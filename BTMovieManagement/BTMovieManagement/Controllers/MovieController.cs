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
    public class MovieController : BaseController
    {

        public MovieController(IGenericRepository<BTUser> _genericRepository, IOMDBWebService _oMDBWebService, IGenericRepository<OMDBMovieList> _omdbMovieService) :
            base(_genericRepository, _oMDBWebService, _omdbMovieService) { }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<OMDBMovieList> oMDBMovieList = omdbMovieService.All();

                return View(oMDBMovieList);
            }
            catch (Exception)
            {
                //log
                throw;
            }

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(OMDBMovieList model)
        {
            try
            {
                model.CreateDate = DateTime.Now;
                model.Gid = Guid.NewGuid().ToString();
                omdbMovieService.Add(model);
                TempData["err"] = "Başarı ile eklendi";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //log
                TempData["err"] = "Beklenmeyen bir hata oluştu.";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            try
            {
                var res = omdbMovieService.Get(Id);
                var sonuc = omdbMovieService.Remove(res);
                if (sonuc)
                {
                    TempData["err"] = "Başarı ile silindi";
                }
                else
                {
                    TempData["err"] = "Beklenmeyen bir hata oluştu.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //log
                TempData["err"] = "Beklenmeyen bir hata oluştu.";
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            try
            {
                var res = omdbMovieService.Get(Id);

                return View(res);
            }
            catch (Exception)
            {
                //log
                TempData["err"] = "Beklenmeyen bir hata oluştu.";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Update(OMDBMovieList model)
        {
            try
            {
                model.UpdateDate = DateTime.Now;
                var res = omdbMovieService.Update(model);
                if (res)
                {
                    TempData["err"] = "Başarı ile güncellendi.";
                }
                else
                {
                    TempData["err"] = "Beklenmeyen bir hata oluştu.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //log
                TempData["err"] = "Beklenmeyen bir hata oluştu.";
                return RedirectToAction("Index");
            }

        }
    }
}
