namespace LorryGlory_Frontend_MVC.ViewModels.Staff
{
    public class AllStaffUsersViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<string>? Roles { get; set; } = new List<string>();
    }
}
