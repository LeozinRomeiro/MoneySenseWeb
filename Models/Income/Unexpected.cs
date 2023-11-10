namespace MoneySenseWeb.Models.Income
{
    public class Unexpected : Quotation
    {
		public Unexpected() : base("", "", 0,"")
		{
		}
		public Unexpected(string title, string description, decimal value, string userName) : base(title, description, value, userName)
        {
        }
    }
}
