namespace MoneySense.Models.Expense
{
    public class Unexpected : Quotation
    {
        public Unexpected(string title, string description, decimal value) : base(title, description, value)
        {
        }
    }
}
