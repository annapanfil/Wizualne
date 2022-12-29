using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskShare.Models
{
    [Index(nameof(Label), IsUnique = true)]
    public class Task
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int TimeCost { get; set; }
        public int Priority { get; set; }

        public List<Status> Statuses { get; set; } = new ();

        [ForeignKey("User")]
        public int? UserID { get; set; }
        public User? User { get; set; }
        
        public Issue? Issue { get; set; }

    }
}
