using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySenseWeb.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Campo obrigatório, por favor aponte a categoria")]
        public Category? Category { get; set; }
        public double Amount { get; set; }
        [DisplayName("Descrição")]
        public string? Description { get; set; }
        [DisplayName("Data")]
        [Required(ErrorMessage = "Campo obrigatório, por favor indique a data da movimentação")]
        public DateTime Date { get; set; } = DateTime.Now;
        [DisplayName("Registrado em")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.TitleWithIcon;
            }
        }

        [NotMapped]
        public string? FormattedValue
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    }
}
