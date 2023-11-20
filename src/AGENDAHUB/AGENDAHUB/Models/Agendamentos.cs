using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGENDAHUB.Models
{
    [Table("Agendamentos")]
    public class Agendamentos
    {
        [Key]
        public int ID_Agendamentos { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o servi�o!")]
        [Display(Name = "Servi�o")]
        public int ID_Servico { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o cliente!")]
        [Display(Name = "Cliente")]
        public int ID_Cliente { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar a data!")]
        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar a hora!")]
        [Column(TypeName = "time")]
        public TimeSpan Hora { get; set; }

        public StatusAgendamento Status { get; set; }
        [Required(ErrorMessage = "Obrigat�rio informar o profissional!")]
        [Display(Name = "Profissional")]
        public int ID_Profissional { get; set; }

        // Propriedade de navega��o para Usuario
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

        // Propriedade de navega��o para o cliente
        [ForeignKey("ID_Cliente")]
        public Clientes Cliente { get; set; }

        // Propriedade de navega��o para o servi�o
        [ForeignKey("ID_Servico")]
        public Servicos Servicos { get; set; }

        // Propriedade de navega��o para o profissional
        [ForeignKey("ID_Profissional")]
        public Profissionais Profissionais { get; set; }

        // Propriedade de navega��o para o caixa
        public Caixa Caixa { get; set; }

        public enum StatusAgendamento
        {
            Pendente,
            Concluido,
            Cancelado
        }
    }
}
