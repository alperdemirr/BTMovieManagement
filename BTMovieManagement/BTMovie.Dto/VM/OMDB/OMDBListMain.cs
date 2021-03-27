using System;
using System.Collections.Generic;
using System.Text;

namespace BTMovie.Dto.VM.OMDB
{
    public class OMDBListMain:OMDBHeader
    {
        public IEnumerable<OMDBList> Search { get; set; }
    }
}
