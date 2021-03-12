using LasFiszkas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LasFiszkas.DAL
{
    public class FishContext : DbContext
    {
        public FishContext() : base("FishContext")
        {
        }

        public DbSet<Set> Sets { get; set; }
        public DbSet<Fish> Fishes { get; set; }
    }
}