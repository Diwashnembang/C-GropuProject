using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturant.Models;

namespace Resturant.Data
{
    public class ResturantContext : IdentityDbContext<Customer>
    {
        public ResturantContext (DbContextOptions<ResturantContext> options)
            : base(options)
        {
        }

        public DbSet<Resturant.Models.Menus> Menu { get; set; } = default!;
        public DbSet<Resturant.Models.MenuItems> MenuItems { get; set; } = default!;
        public DbSet<Resturant.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Resturant.Models.Reservation> Reservation { get; set; } = default!;
        
    }
}
