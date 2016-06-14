using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace TripPlanner.Models
{
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}