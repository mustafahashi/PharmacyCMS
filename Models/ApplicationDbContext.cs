 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacy.DTO;
using PharmacyCMS.DTO;

namespace pharmacyCMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<sales> sales { get; set; }
        public DbSet<mediciene> mediciene { get; set; }
        public DbSet<pharmacy.DTO.login> login { get; set; }
        public DbSet<PharmacyCMS.DTO.salesDTO> salesDTO { get; set; }
    }
}
