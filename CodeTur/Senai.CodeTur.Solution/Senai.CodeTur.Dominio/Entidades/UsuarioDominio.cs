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

        [Column("Email", TypeName = "varchar(150)")]
        [Required]
        public string Email { get; set; }

        [Column("Senha", TypeName = "varchar(15)")]
        [Required]
        public string Senha { get; set; }

        [Column("Tipo", TypeName = "varchar(20)")]
        [Required]
        public string Tipo { get; set; }
    }
}
