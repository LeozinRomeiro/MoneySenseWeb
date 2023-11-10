using MoneySenseWeb.Models.ActorsContext;

namespace MoneySenseWeb.Models.Expense
{
    public class Other : Quotation
    {
        public Other(string title, string description, decimal value, string userName, int userId) : base(title, description, value, userName)
        {
            UserId = userId;
        }
        public Actor User { get; set; }
        public int UserId { get; set; }
    }
}
