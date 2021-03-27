using BTMovie.Dto.VM.OMDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTMovie.WebServices.Abstract.OMDB
{
    public interface IOMDBWebService
    {
        OMDBListMain GetImdbList(string apiKey, string movieName, string type);
    }
}
