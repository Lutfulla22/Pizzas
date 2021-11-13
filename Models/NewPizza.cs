using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pizzas.Models
{
    public class NewPizza
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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

    }
}