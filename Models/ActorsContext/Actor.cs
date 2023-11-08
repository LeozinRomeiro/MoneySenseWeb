namespace MoneySense.Models.Actors
{
    public class Actor
    {
        public Actor(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
