using MoneySenseWeb.Models.ActorsContext;

namespace MoneySenseWeb.Models.Expense
{
    public class Other : Quotation
    {
        public Other(string title, string description, decimal value, int userId) : base(title, description, value)
        {
            UserId = userId;
        }
        public Actor User { get; set; }
        public int UserId { get; set; }
    }
}
