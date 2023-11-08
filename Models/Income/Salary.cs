namespace MoneySense.Models.Income
{
    public class Salary : Quotation
    {
        public Salary(string title, string description, decimal value, DateTime paymentDate) : base(title, description, value)
        {
            PaymentDate = paymentDate;
        }
        public DateTime PaymentDate { get; set; }
    }
}
