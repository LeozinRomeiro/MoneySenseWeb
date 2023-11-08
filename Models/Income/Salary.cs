using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneySenseWeb.Models.Income
{
    public class Salary : Quotation
    {
        public Salary(string title, string description, decimal value, int paymentDate) : base(title, description, value)
        {
            PaymentDate = paymentDate;
        }
        [DisplayName("Dia do pagamento")]
        [Required(ErrorMessage = "A data que sua renda é renovada é obrigatório!")]
        public int PaymentDate { get; set; }
    }
}
