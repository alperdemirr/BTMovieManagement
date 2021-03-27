using BTMovie.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTMovie.Core.Entity
{
    public class BTUser: BaseEntity
    {
        [StringLength(50, ErrorMessage = "Maximum Karakter sayısı 50")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Maximum Karakter sayısı 50")]
        public string Surname { get; set; }
        [StringLength(50, ErrorMessage = "Maximum Karakter sayısı 50")]
        public string UserName { get; set; }
        [StringLength(16, ErrorMessage = "Maximum Karakter sayısı 16")]
        public string HashPassword { get; set; }
        public string HashCode { get; set; }
    }
}
