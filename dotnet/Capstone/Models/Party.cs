using Capstone.DAO;
using Capstone.Services;
using Newtonsoft.Json;
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
        public string PartyInviteCode { get; set; }
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
        public string PartyInviteCode { get; set; }
        public IList<Guest> GuestList { get; set; }
        public IList<Restaurant> Restaurants { get; set; }
        public PartyViewModel(Party party, IList<Guest> guests, IList<Restaurant> restaurants)
        {
            PartyId = party.PartyId;
            Location = party.Location;
            Date = party.Date;
            Owner = party.Owner;
            Description = party.Description;
            Name = party.Name;
            InviteLink = party.InviteLink;
            GuestList = guests;
            Restaurants = restaurants;
            PartyInviteCode = party.PartyInviteCode;
        }
    }
}
