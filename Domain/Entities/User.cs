namespace Domain.Entities
{
    public class User
    {
        public User()
        {
            Name = string.Empty;
            Role = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}