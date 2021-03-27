using BTMovie.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTMovie.Core.Entity
{
    public class OMDBMovieList :BaseEntity
    {
        public string Title { get; set; }
        [StringLength(4, ErrorMessage = "Maximum Karakter sayısı 4")]
        public string Year { get; set; }
        [StringLength(10, ErrorMessage = "Maximum Karakter sayısı 10")]
        public string imdbID { get; set; }
        [StringLength(10, ErrorMessage = "Maximum Karakter sayısı 10")]
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
