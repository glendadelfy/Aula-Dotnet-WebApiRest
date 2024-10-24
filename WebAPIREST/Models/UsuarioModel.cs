using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIREST.Models
{
    [Table("USUARIO")]
    public class UsuarioModel
    {
        [Key]
        [Column("USUARIO_ID")]
        public int UsuarioId { get; set; }

        [Column("NOME")]
        [Required(ErrorMessage ="Nome Requerido")]
        [StringLength(150, ErrorMessage ="Tamanho máximo 150 caracteres")]
        public string Nome { get; set; }

        [Column("EMAIL")]
        [Required(ErrorMessage = "Email Requerido")]
        [StringLength(150, ErrorMessage = "Tamanho máximo 150 caracteres")]
        public string Email { get; set; }

        [Column("PASSWORD")]
        [Required(ErrorMessage = "Password Requerido")]
        [StringLength(50, ErrorMessage = "Tamanho máximo 50 caracteres")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Column("DATA_NASC")]
        [Required(ErrorMessage = "Data de Nascimento Requerida")]
        public DateTime DataNascimento { get; set; }

        public List<EnderecoModel> ListaEndereco { get; set; }


    }
}
