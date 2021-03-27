using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BTMovieManagement.Models;
using BTMovie.DataAccess.GenericRepository;
using BTMovie.Core.Entity;
using BTMovie.Dto.VM;
using BTMovie.Encryption;
using BTMovie.WebServices.Abstract.OMDB;
using BTMovie.Dto.VM.OMDB;

namespace BTMovieManagement.Controllers
{
    public class LoginController : BaseController
    {
       

        public LoginController(IGenericRepository<BTUser> _genericRepository, IOMDBWebService _oMDBWebService,IGenericRepository<OMDBMovieList> _omdbMovieService) : 
            base(_genericRepository, _oMDBWebService, _omdbMovieService) {  }
     

        public IActionResult Index()
        {

            try
            {
                //web servisten tam olarak neleri çekeceğim açıkça belirtilmemiş 
                //bende type=movie isimi "ave" ile başlayanları çekip veritabanı boş ise yazdım.
                //bu listeye görede delete update yaparım
                var movieService = omdbMovieService.All();
                if (movieService.Count() == 0)
                {
                    OMDBListMain omdbList = oMDBWebService.GetImdbList("1e4c3c64", "ave", "movie");
                    foreach (var item in omdbList.Search)
                    {
                        OMDBMovieList movieList = new OMDBMovieList();
                        movieList.CreateDate = DateTime.Now;
                        movieList.Gid = Guid.NewGuid().ToString();
                        movieList.imdbID = item.imdbID;
                        movieList.Poster = item.Poster;
                        movieList.Title = item.Title;
                        movieList.Type = item.Type;
                        movieList.Year = item.Year;
                        omdbMovieService.Add(movieList);
                    }
                }

                return View();
            }
            catch (Exception)
            {
                //log
                throw;
            }
        }
        [HttpPost]
        public IActionResult Index(LoginVM loginVM)
        {
            try
            {
                var user = genericRepository.Where(x => x.UserName == loginVM.userName).SingleOrDefault();
                if (user == null)
                {
                    TempData["err"] = "Kullanıcı adı hatalı";
                    return View();
                }
                string password = EncryptionLibrary.EncryptText(user.HashCode, loginVM.password);
                if (user.HashPassword == password)
                {
                    return RedirectToAction("Index","Movie");
                }
                else
                {
                    TempData["err"] = "Şifre hatalı";
                }

                return View();
            }
            catch (Exception )
            {
                //log
                TempData["err"] = "Bir hata oluştu lütfen tekrar deneyiniz.";
                return View();
            }

        }
        public IActionResult CreateUser()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(UserVM user)
        {
            try
            {
                BTUser bTUser = new BTUser();
                bTUser.CreateDate = DateTime.Now;
                bTUser.Gid = Guid.NewGuid().ToString();
                bTUser.Name = user.name;
                bTUser.Surname = user.surname;
                bTUser.HashCode = "randomuretilirilerde";
                string _password = EncryptionLibrary.EncryptText(bTUser.HashCode, user.password);
                bTUser.HashPassword = _password;
                bTUser.UserName = user.userName;
                genericRepository.Add(bTUser);

                TempData["err"] = "Kaydınız başarılı ile oluşturulmuştur.";

                return View();
            }
            catch (Exception ex)
            {
                TempData["err"] = "Bir hata oluştu lütfen tekrar deneyiniz.";
                return View();
            }

        }

    }
}
