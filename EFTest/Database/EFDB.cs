using EFTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFTest.Database
{
    public class EFDB : DbContext
    {
        public EFDB() : base("AnimeDB")
        {
            System.Data.Entity.Database.SetInitializer<EFDB>(new CreateDatabaseIfNotExists<EFDB>());
        }

        public DbSet<AniList> AnimeProp { get; set; }
        public DbSet<Rating> AnimeRating { get; set; }
    }
}