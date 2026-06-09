using BlazorApp2.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorApp2.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Inventoryitems> Inventoryitems { get; set; }

        public DbSet<Module> Modules { get; set; } 

        public DbSet<Programme> Programmes { get; set; }

        public DbSet<Staff> Staffing  { get; set; }
    }
}