using BTMovie.Core.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTMovie.DataAccess.Context
{
    public class BTMovieContext: IdentityDbContext
    {
        public BTMovieContext(DbContextOptions<BTMovieContext> options) : base(options) { }

        public DbSet<BTUser> BTUser { get; set; }
        public DbSet<OMDBMovieList> OMDBMovieList { get; set; }
    }
}
