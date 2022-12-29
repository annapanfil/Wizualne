namespace TaskShare.Models
{
    public class Status
    {
        public int Id { get; set; }
        public StatusType StatusType { get; set; }
        public DateTime Occurred { get; set; }
        public Product? Task { get; set; }
    }
}
