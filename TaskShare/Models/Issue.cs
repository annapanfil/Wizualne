using Microsoft.EntityFrameworkCore;

namespace TaskShare.Models
{
    [Index(nameof(Label), IsUnique = true)]
    public class Issue
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public List<Task> Tasks { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}
