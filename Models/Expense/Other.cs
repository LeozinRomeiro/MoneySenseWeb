using MoneySense.Models.Actors;

namespace MoneySense.Models.Expense
{
    public class Other : Quotation
    {
        public Other(string title, string description, decimal value, int user) : base(title, description, value)
        {
            UserConsumer = user;
        }
        //public Actor UserConsumer { get; set; }
        public int UserConsumer { get; set; }
    }
}
