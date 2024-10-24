using Microsoft.EntityFrameworkCore;
using WebAPIREST.Context;
using WebAPIREST.Models;
using WebAPIREST.Repositories.Interface;

namespace WebAPIREST.Repositories.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppContextDb _context;

        public EnderecoRepository(AppContextDb context)
        {
            _context = context;
        }


        public EnderecoModel Add(EnderecoModel model)
        {
            _context.Endereco.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            bool status = false;

            try
            {
                var user = _context.Endereco.Find(id);

                if (user != null)
                {
                    _context.Endereco.Remove(user);
                    _context.SaveChanges();
                }

                status = true;

            }
            catch { }

            return status;
        }


        public bool Delete(List<EnderecoModel> itens)
        {
            bool status = false;

            try
            {

                foreach(var enrdereco in itens)
                {
                    _context.Remove(enrdereco);
                }

                _context.SaveChanges();

                status = true; 

            }
            catch { }

            return status;
        }

        public EnderecoModel Get(int id)
        {
            var user = _context.Endereco.FirstOrDefault(m => m.EnderecoId == id);
            return user;
        }

    
        public IEnumerable<EnderecoModel> List()
        {
            return _context.Endereco.ToList();
        }

        public EnderecoModel Update(EnderecoModel model)
        {
            _context.Endereco.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
