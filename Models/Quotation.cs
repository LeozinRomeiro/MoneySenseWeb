using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneySenseWeb.Models
{
    public abstract class Quotation
    {
        public Quotation(string title, string description, decimal value, string userName)
        {
            Title = title;
            Description = description;
            Value = value;
            UserName = userName;
        }

        public int Id { get; set; }
        [DisplayName("Título")]
        [Required(ErrorMessage="Campo obrigatório, por favor adicione uma identificação")]
        public string Title { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Valor")]
        [Required(ErrorMessage = "Não faz sentido deixar o valor zerado")]
        public decimal Value { get; set; }
        [DisplayName("Criado em")]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [DisplayName("Atualizado em")]
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        [DisplayName("Usuário criador")]
        public string UserName { get; set; }
    }
}
