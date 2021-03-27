using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTMovie.Core.Constants
{
    public class BaseEntity:IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate  { get; set; }
        public string Gid { get; set; }
    }
}
