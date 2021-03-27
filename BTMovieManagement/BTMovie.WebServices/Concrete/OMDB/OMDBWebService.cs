using BTMovie.Dto.VM.OMDB;
using BTMovie.WebServices.Abstract.OMDB;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTMovie.WebServices.Concrete.OMDB
{
    public class OMDBWebService : IOMDBWebService
    {

        //ben tam olarak api ile neleri çekeceğimi anlamadığım için sabit olan bir isime göre arama yaptırdım
        public OMDBListMain GetImdbList(string apiKey , string movieName,string type)
        {
            var client = new RestClient("http://www.omdbapi.com/?apikey="+apiKey+"&type="+type+"&s="+movieName);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var list = JsonConvert.DeserializeObject<OMDBListMain>(response.Content);
            return list;
        }



    }
}
