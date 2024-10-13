namespace TestBlog.Core.ViewModels.Admin.Account
{
    public class FilterUserViewModel
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAdmin { get; set; }
    }
}
