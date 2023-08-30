using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Book.Reading.Event.Core.Entities;

namespace Book.Reading.Event.Business.Data
{
    public class EventContext : IdentityDbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }
        public DbSet<Event1> events { get; set; }
        public DbSet<Comment> comment { get; set; }
    }
}
