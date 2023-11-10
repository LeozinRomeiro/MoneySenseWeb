namespace MoneySenseWeb.Models.Expense
{
    public class Unexpected : Quotation
    {
        public Unexpected(string title, string description, decimal value, string userName) : base(title, description, value, userName)
        {
        }
    }
}
