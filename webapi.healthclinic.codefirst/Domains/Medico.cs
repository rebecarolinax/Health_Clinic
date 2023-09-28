using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.codefirst.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? NomeMedico { get; set; }

        [Required(ErrorMessage = "O campo CRM é obrigatório.")]
        [Column(TypeName = "CHAR(14)")]
        public string? CRM { get; set; }

        [Required(ErrorMessage = "O campo Especialidade é obrigatório.")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        [Required(ErrorMessage = "O campo IdUsuario é obrigatório.")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
