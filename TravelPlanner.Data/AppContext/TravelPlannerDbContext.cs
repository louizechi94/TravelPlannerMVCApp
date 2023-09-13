using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;

namespace TravelPlanner.Data.AppContext
{
    public class TravelPlannerDbContext :DbContext
    {
        public TravelPlannerDbContext(DbContextOptions<TravelPlannerDbContext> options):base(options) { }
        public DbSet<Trip> Trips{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Destination> Destinations{ get; set; }
        public DbSet<Itinerary> Itineraries{ get; set;}
        public DbSet<ScheduledEvent> ScheduledEvents { get; set;}



    }
}
