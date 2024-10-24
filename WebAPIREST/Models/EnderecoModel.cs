using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPIREST.Models
{
    [Table("ENDERECO")]
    public class EnderecoModel
    {
        [Key]
        [Column("ENDERECO_ID")]
        public int EnderecoId { get; set; }

        [Column("LOGRADOURO")]
        [StringLength(250,ErrorMessage ="Tamanho maximo é de 250 caracteres")]
        public string Logradouro { get; set; }

        [Column("CIDADE")]
        [StringLength(20, ErrorMessage = "Tamanho maximo é de 20 caracteres")]
        public string Cidade { get; set; }

        [Column("uf")]
        [StringLength(2, ErrorMessage = "Tamanho maximo é de 2 caracteres")]
        public string Uf { get; set; }

        [JsonIgnore]
        public virtual UsuarioModel? Usuario { get; set; }

    }
}
