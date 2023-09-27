using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.codefirst.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "Data e horário da consulta é obrigatório!")]
        public DateTime? DatetimeConsulta { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição para prontuário da consulta é obrigatória!")]
        public string? DescricaoConsulta { get; set; }

        [Required(ErrorMessage = "Informe a clínica relacionada a consulta!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        [Required(ErrorMessage = "Informe o paciente relacionado a consulta!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Informe o médico relacionado a consulta!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
    }
}
