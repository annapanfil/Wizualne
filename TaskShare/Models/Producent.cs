using Microsoft.EntityFrameworkCore;

namespace TaskShare.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class Producent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Product> Products { get; set; } = new ();
    }
}
