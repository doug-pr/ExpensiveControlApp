using System.ComponentModel.DataAnnotations;

namespace ExpensiveControlApp.DTOs
{
    public class CreateExpensiveDTO
    {
        public CreateExpensiveDTO()
        {
            Date = DateTime.Now;
        }
        
        [Required(ErrorMessage = "Descrição é Obrigatória!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Valor é Obrigatório!")]
        [Range(0.01, 9999999999, ErrorMessage = "Valor Deve Ser Maior Que 0!")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Data é Obrigatório!")]
        public DateTime Date { get; set; }
    }
}
