using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Senai.CodeTur.Dominio.Entidades
{
    [Table("Pacotes")]
    public class PacoteDominio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Titulo", TypeName = "varchar(250)")]
        public string Titulo { get; set; }

        [Required]
        [Column("Imagem", TypeName = "varchar(350)")]
        public string Imagem { get; set; }

        [Required]
        [Column("Descricao", TypeName = "TEXT")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Required]
        [Column("Pais", TypeName = "varchar(150)")]
        public string Pais { get; set; }

        
        [Column("Ativo", TypeName = "bit")]
        public bool Ativo { get; set; }
    }
}
