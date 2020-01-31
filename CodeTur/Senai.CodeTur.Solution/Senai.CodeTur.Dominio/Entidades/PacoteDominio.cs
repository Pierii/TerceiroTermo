using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.CodeTur.Dominio.Entidades
{
    [Table("Pacotes")]
    public class PacoteDominio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Titulo", TypeName = "varchar(150)")]
        public string Titulo { get; set; }

        [Required]
        [Column("Ima", TypeName = "varchar(150)")]
        public string Titulo { get; set; }
    }
}
