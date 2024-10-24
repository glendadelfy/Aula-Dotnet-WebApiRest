using Microsoft.EntityFrameworkCore;
using WebAPIREST.Context;
using WebAPIREST.Models;
using WebAPIREST.Repositories.Interface;

namespace WebAPIREST.Repositories.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppContextDb _context;

        public UsuarioRepository(AppContextDb context)
        {
            _context = context;
        }


        public UsuarioModel Add(UsuarioModel model)
        {
            _context.Usuario.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            bool status = false;

            try
            {
                var user = _context.Usuario.Find(id);

                if (user != null) { 
                    _context.Usuario.Remove(user);
                    _context.SaveChanges();
                }

                status = true;

            }
            catch{}

            return status;
        }

        public UsuarioModel Get(int id)
        {
            var user = _context.Usuario.Include(c => c.ListaEndereco).FirstOrDefault(m => m.UsuarioId ==  id);
            return user;
        }

        public UsuarioModel GetLogin(string email, string password)
        {
            var user = _context.Usuario.FirstOrDefault(m => m.Email == email && m.Password == password);
            return user;
        }

        public IEnumerable<UsuarioModel> List()
        {
            return _context.Usuario.Include(c => c.ListaEndereco).ToList();
        }

        public UsuarioModel Update(UsuarioModel model)
        {
            _context.Usuario.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
