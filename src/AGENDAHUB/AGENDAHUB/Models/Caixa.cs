using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AGENDAHUB.Models
{
    [Table("Caixa")]
    public class Caixa
    {
        [Key]
        public int ID_Caixa { get; set; }

        [Required(ErrorMessage = "� obrigat�rio informar a categoria")]
        public CategoriaMovimentacao Categoria { get; set; }

        [Required(ErrorMessage = "� obrigat�rio informar o valor")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "� Obrigat�rio informar a data")]
        [Column(TypeName = "date")]
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

        // Propriedade de navega��o para Usuario
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

        // Propriedade de navega��o para Agendamento
        public int? ID_Agendamento { get; set; }
        public Agendamentos Agendamento { get; set; }

        public enum CategoriaMovimentacao
        {
            Entrada,
            Sa�da
        }
    }
}
