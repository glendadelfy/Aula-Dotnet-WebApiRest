using Microsoft.EntityFrameworkCore;
using WebAPIREST.Models;

namespace WebAPIREST.Context
{
    public class AppContextDb : DbContext
    {
        public AppContextDb(DbContextOptions<AppContextDb> options) : base(options) { }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<UsuarioLoginModel> UsuarioLogin { get; set; }

    }
}
