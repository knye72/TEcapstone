﻿using Capstone.DAO;
using Capstone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Party
    {
        public int PartyId { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public string InviteLink { get; set; }
    }
    public class PartyMinModel : Party
    {
        public IList<RestaurantMinModel> Restaurants { get; set; }
        public PartyMinModel(int partyId)
        {
            IPartyDao PartyDao = new PartySqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
            IRestaurantDao RestaurantsDao = new RestaurantSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");

            PartyId = partyId;
            Party temp = PartyDao.GetParty(partyId);
            Location = temp.Location;
            Date = temp.Date;
            Owner = temp.Owner;
            Description = temp.Description;
            Name = temp.Name;
            IList<Restaurant> tempRestaurants = RestaurantsDao.GetRestaurants(partyId);
            Restaurants = new List<RestaurantMinModel>();            foreach (Restaurant restaurant in tempRestaurants)            {                Restaurants.Add(new RestaurantMinModel(restaurant));
            }
        }
    }
    public class PartyViewModel
    {
        public int PartyId { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; } // Updated to DateTime type
        public string Owner { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public string InviteLink { get; set; }

        public IList<Guest> GuestList { get; set; }
        public Businesses YelpBusinesses { get; set; }
        
        // Default Constructor to 
        public PartyViewModel()
        {
        }
        public PartyViewModel(Party party, IList<Guest> guests, Businesses businesses)
        {
            PartyId = party.PartyId;
            Location = party.Location;
            Date = party.Date;
            Owner = party.Owner;
            Description = party.Description;
            Name = party.Name;
            InviteLink = party.InviteLink;
            GuestList = guests;
            YelpBusinesses = businesses;
        }
    }
}
