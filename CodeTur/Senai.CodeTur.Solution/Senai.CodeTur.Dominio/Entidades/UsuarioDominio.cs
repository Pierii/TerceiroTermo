using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.CodeTur.Dominio.Entidades
{
    [Table("Usuarios")]
    public class UsuarioDominio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Nome", TypeName = "varchar(150)")]
        public string Nome { get; set; }

        [Required]
        [Column("Email", TypeName = "varchar(150)")]
        public string Email { get; set; }

        [Required]
        [Column("Senha", TypeName = "varchar(20)")]
        public string Senha { get; set; }

        [Required]
        [Column("Tipo", TypeName = "varchar(150)")]
        public string Tipo { get; set; }
    }
}
