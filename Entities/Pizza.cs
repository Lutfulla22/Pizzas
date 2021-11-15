using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pizzas.Entities
{
    public class Pizza
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(3)]
        public string ShortName { get; set; }

        [Required]
        public EPizzaStockStatus Status { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Ingridients { get; set; }

        [Required]
        [Range(0, 1000)]
        public Double Price { get; set; }



        [Obsolete("User only for entity building", true)]
        public Pizza() { }

        public Pizza(string title, string shortName, EPizzaStockStatus status, string ingridients, double price)
        {
            Id = Guid.NewGuid();
            Title = title;
            ShortName = shortName;
            Status = status;
            Ingridients = ingridients;
            Price = price;
        }

    }
}