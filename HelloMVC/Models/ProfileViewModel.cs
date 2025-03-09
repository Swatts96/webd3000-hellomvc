namespace HelloMVC.Models
{
    public class ProfileViewModel
    {
        public AppUser User { get; set; } = default!;
        public IEnumerable<Discussion> Discussions { get; set; } = new List<Discussion>();
    }
}
