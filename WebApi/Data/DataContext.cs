using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tp3WebApiMarcio.Models;

namespace Tp3WebApiMarcio
{
    public class DataContext : DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public DbSet<Amigo> Amigo;
        public System.Data.Entity.DbSet<Tp3WebApiMarcio.Models.Amigo> Amigos { get; set; }
    }
}