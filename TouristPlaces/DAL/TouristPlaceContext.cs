using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristPlaces.Models;

namespace TouristPlaces.DAL
{
    internal class TouristPlaceContext:DbContext
    {
        public TouristPlaceContext():base()
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
        public DbSet<TouristPlace> TouristPlaces { get; set; }
    }
}
