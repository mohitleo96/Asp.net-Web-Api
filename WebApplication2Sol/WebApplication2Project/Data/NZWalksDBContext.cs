
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication2Project.Models.domain;

namespace WebApplication2Project.Data
{
    public class NZWalksDBContext : DbContext
    {
        //ctor shortcut for creating construtor
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options) : base(options)
        {

        }
        //we have to create three properties for region walk and walk difficuty.
        //By using of DbSet we telling the Database to create a Region table in database
        //if it not exixts. And take the Fields As Column names.
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }


    }
}
