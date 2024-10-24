using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIREST.Models
{
    [NotMapped]
    public class UsuarioLoginModel
    {
        [Column("EMAIL")]
        [EmailAddress]
        public string Email { get; set; }

        [Column("PASSW0RD")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
