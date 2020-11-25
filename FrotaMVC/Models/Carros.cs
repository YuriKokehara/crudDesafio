using System.ComponentModel.DataAnnotations;

namespace FrotaMVC.Models
{
    public class Carros
    {
        [Display(Name = "Id")]
        public int IdCarro { get; set; }

        [Required(ErrorMessage = "Informe a Marca do Carro")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Informe o Modelo do Carro")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Informe a Cor do Carro")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "Informe o Ano de Fabricação do Carro")]
        public int AnoFabric { get; set; }

    }
}