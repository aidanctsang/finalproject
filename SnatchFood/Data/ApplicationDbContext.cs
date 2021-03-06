using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnatchFood.Models;


namespace SnatchFood.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> Cart { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}
