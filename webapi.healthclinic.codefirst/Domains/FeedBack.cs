using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.codefirst.Domains
{
    [Table(nameof(FeedBack))]
    public class FeedBack
    {
        [Key]
        public Guid IdFeedBack { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Feedback da consulta é obrigatório!")]
        public string? FeedbackConsulta { get; set; }

        [Required(ErrorMessage = "Informe o paciente relacionado ao feedback!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Informe a consulta relacionada ao feedback!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
