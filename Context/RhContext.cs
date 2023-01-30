using EDP_WebAPI_Security.Models;
using Microsoft.EntityFrameworkCore;

namespace EDP_WebAPI_Security.Context
{
    public class RhContext : DbContext
    {
        public RhContext(DbContextOptions<RhContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; set; }
    
    }
}
