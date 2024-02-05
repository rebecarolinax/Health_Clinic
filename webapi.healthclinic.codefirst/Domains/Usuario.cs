using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.codefirst.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do usuário é obrigatório!")]
        public string? NomeUsuario { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "CPF do usuário é obrigatório!")]
        [StringLength(14, ErrorMessage = "Confira os dígitos do CPF e os insira corretamente! (Apenas números)")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do usuário é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha do usuário é obrigatório!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres!")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Informe o tipo do usuário!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
