namespace Domain.ViewModels.ReturnViewModels
{
    public class UserReturnViewModel
    {
        public UserReturnViewModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            Role = string.Empty;
            Password = string.Empty;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
