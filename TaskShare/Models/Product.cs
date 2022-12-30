using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskShare.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        // public ProductCategory ProductCategory { get; set; }

        public int? ProducentID { get; set; }
        public Producent? Producent { get; set; }

    }
}
