using System;
using System.Collections.Generic;
using System.Text;

namespace BTMovie.Dto.VM.OMDB
{
    public class OMDBList
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
