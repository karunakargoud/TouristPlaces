using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristPlaces.DAL;
using TouristPlaces.Models;

namespace TouristPlaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TouristPlaceContext dal= new TouristPlaceContext();

            TouristPlace tp1= new TouristPlace();
            tp1.TouristPlaceId = 9001;
            tp1.TouristPlaceName = "Charminar";
            tp1.Description = "The Charminar is a monument located in Hyderabad, " +
                "Telangana, India. Constructed in 1591, the landmark is a symbol" +
                " of Hyderabad and officially incorporated in the emblem of Telangana." +
                " The Charminar's long history includes the existence of a mosque on " +
                "its top floor for more than 425 years";
            tp1.Location = DbGeography.FromText("POINT(17.3616 78.4747)");
            dal.TouristPlaces.Add(tp1);

            TouristPlace tp2= new TouristPlace();
            tp2.TouristPlaceId = 9002;
            tp2.TouristPlaceName = "Golconda Fort";
            tp2.Description = "Golconda is a fortified citadel and ruined city" +
                " located on the western outskirts of Hyderabad, Telangana, India. " +
                "The fort was originally built by Kakatiya ruler Pratāparudra in the " +
                "11th century out of mud walls";
            tp2.Location = DbGeography.FromText("POINT(17.3842 78.4019)");
            dal.TouristPlaces.Add(tp2);

            TouristPlace tp3 = new TouristPlace();
            tp3.TouristPlaceId = 9003;
            tp3.TouristPlaceName = "Salar Jung Museum";
            tp3.Description = "The Salar Jung Museum is an art museum" +
                " located at Dar-ul-Shifa, on the southern bank of the " +
                "Musi River in the city of Hyderabad, Telangana, India. " +
                "It is one of the notable National Museums of India";
            tp3.Location = DbGeography.FromText("POINT(17.3716 78.4802)");
            dal.TouristPlaces.Add(tp3);

            TouristPlace tp4 = new TouristPlace();
            tp4.TouristPlaceId = 9004;
            tp4.TouristPlaceName = "Tank Bund";
            tp4.Description = "The Tank Bund Road is a road in Secunderabad, Hyderabad," +
                " India. The Tank Bund dams Hussain Sagar lake on the eastern side and connects " +
                "the twin cities of Hyderabad and Secunderabad." +
                " It has become an attraction with 33 statues of famous people from the region";
            tp4.Location = DbGeography.FromText("POINT(17.4239 78.4738)");
            dal.TouristPlaces.Add(tp4);

            TouristPlace tp5 = new TouristPlace();
            tp5.TouristPlaceId = 9005;
            tp5.TouristPlaceName = "Birla Mandir";
            tp5.Description = "Birla Mandir is a Hindu temple built on a 280 feet high hillock" +
                " called Naubath Pahad on a 13 acres plot in Hyderabad, Telangana, India." +
                " The construction took ten years and was opened in 1976 by " +
                "Swami Ranganathananda of Ramakrishna Mission";
            tp5.Location = DbGeography.FromText("POINT(17.4062 78.4691)");
            dal.TouristPlaces.Add(tp5);

            TouristPlace tp6 = new TouristPlace();
            tp6.TouristPlaceId = 9006;
            tp6.TouristPlaceName = "Ramoji Film City";
            tp6.Description = "Ramoji Film City is an integrated film studio facility located in Hyderabad," +
                " India. Spread over 1,666 acres, it holds the title of the largest film studio complex in the " +
                "world, as certified by the Guinness World Records. It was established by Telugu media tycoon " +
                "Ramoji Rao in 1996";
            tp6.Location = DbGeography.FromText("POINT(17.2641 78.6818)");
            dal.TouristPlaces.Add(tp6);

            TouristPlace tp7 = new TouristPlace();
            tp7.TouristPlaceId = 9007;
            tp7.TouristPlaceName = "Shilparamam Art & Craft Village";
            tp7.Description = "Shilparamam is an arts and crafts village located in Madhapur, Hyderabad, Telangana, " +
                "India. The village was conceived with an idea to create an environment for the preservation of traditional" +
                " Indian crafts. There are ethnic festivals round the year.";
            tp7.Location = DbGeography.FromText("POINT(17.4526 78.3783)");
            dal.TouristPlaces.Add(tp7);

            TouristPlace tp8 = new TouristPlace();
            tp8.TouristPlaceId = 9008;
            tp8.TouristPlaceName = "Nehru Zoological Park";
            tp8.Description = "Nehru Zoological Park is a zoo located near Mir Alam Tank in Bahadurpura, Telangana, India." +
                " It is one of the most visited destinations in Hyderabad";
            tp8.Location = DbGeography.FromText("POINT(17.3506 78.4523)");
            dal.TouristPlaces.Add(tp8);

            dal.SaveChanges();
            var CustomerLocation = DbGeography.FromText("POINT(17.4357 78.4446)");
            var nearestPlaces = (from x in dal.TouristPlaces
                                 orderby x.Location.Distance(CustomerLocation)
                                 select x);
            Console.WriteLine("Nearest places to the customer Location:");
            foreach(var p in nearestPlaces)
            {
                Console.WriteLine(p.TouristPlaceName + " " + "Distance:" + p.Location.Distance(CustomerLocation));
            }
        }
    }
}
