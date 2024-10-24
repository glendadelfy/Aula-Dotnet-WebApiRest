using WebAPIREST.Models;

namespace WebAPIREST.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioModel GetLogin(string email, string password);

        UsuarioModel Get(int id);

        UsuarioModel Add(UsuarioModel model);

        IEnumerable<UsuarioModel> List();

        UsuarioModel Update(UsuarioModel model);

        bool Delete(int id);

    }
}
