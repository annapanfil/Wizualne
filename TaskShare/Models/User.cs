using Microsoft.EntityFrameworkCore;

namespace TaskShare.Models
{
    [Index(nameof(Pseudonym), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudonym { get; set; }

        public List<Task> Tasks { get; set; } = new ();
        public List<Issue> Issues { get; set; } = new ();
    }
}
