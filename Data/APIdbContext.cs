using BigBangAssessmentNew.Model;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessmentNew.Data
{
    public class APIdbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Hotel> hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public APIdbContext(DbContextOptions<APIdbContext> options) : base(options)
        {

        }
    }
}
