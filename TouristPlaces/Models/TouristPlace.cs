using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristPlaces.Models
{
    internal class TouristPlace
    {
        public int TouristPlaceId {  get; set; }

        public string TouristPlaceName { get; set; }

        public string Description { get; set; }

        public  DbGeography Location { get; set; }
    }
}
