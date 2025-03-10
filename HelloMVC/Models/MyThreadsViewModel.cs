namespace HelloMVC.Models
{
    public class MyThreadsViewModel
    {
        public AppUser User { get; set; } = default!;

        // Discussions created by this user
        public IEnumerable<Discussion> Discussions { get; set; } = new List<Discussion>();

        // Comments created by this user
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
