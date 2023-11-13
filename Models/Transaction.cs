using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneySenseWeb.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Campo obrigatório, por favor aponte a categoria")]
        public Category Category { get; set; }
        public int Amount { get; set; }
        [DisplayName("Descrição")]
        public string? Description { get; set; }
        [DisplayName("Data")]
        [Required(ErrorMessage = "Campo obrigatório, por favor indique a data da movimentação")]
        public DateTime Date { get; set; } = DateTime.Now;
        [DisplayName("Registrado em")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
