using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.codefirst.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(6)")]
        [Required(ErrorMessage = "Data de nascimento do paciente é obrigatória!")]
        public string? DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o usuário relacionado ao paciente!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
