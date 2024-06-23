using CarProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars{ get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        
    }
}
