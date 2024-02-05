using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.codefirst.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Título da especialidade é obrigatório!")]
        public string? TituloEspecialidade { get; set; }
    }
}
