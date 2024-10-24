using WebAPIREST.Models;

namespace WebAPIREST.Repositories.Interface
{
    public interface IEnderecoRepository
    {
        EnderecoModel Get(int id);

        EnderecoModel Add(EnderecoModel model);

        IEnumerable<EnderecoModel> List();

        EnderecoModel Update(EnderecoModel model);

        bool Delete(int id);
        bool Delete(List<EnderecoModel> itens);
    }
}
