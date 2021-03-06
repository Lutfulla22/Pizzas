using Microsoft.EntityFrameworkCore;
using Pizzas.Entities;

namespace Pizzas.Data
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        
        
        public PizzaDbContext(DbContextOptions options)
            : base(options) { }            
        
    }
}