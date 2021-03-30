using LasFiszkas.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LasFiszkas.DAL
{
    public class FishContext : IdentityDbContext<ApplicationUser>
    {
        public FishContext() : base("FishContext")
        {
        }

        public static FishContext Create()
        {
            return new FishContext();
        }

        public DbSet<Set> Sets { get; set; }
        public DbSet<Fish> Fishes { get; set; }
    }
}