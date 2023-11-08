namespace MoneySense.Models.Actors
{
    public class User : Actor
    {
        public User(string name, string email) : base(name)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
