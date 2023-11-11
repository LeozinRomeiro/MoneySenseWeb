namespace MoneySenseWeb.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public DateTime Date {  get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
