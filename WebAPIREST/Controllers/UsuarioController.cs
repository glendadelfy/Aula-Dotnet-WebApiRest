using Microsoft.AspNetCore.Mvc;
using WebAPIREST.Models;
using WebAPIREST.Repositories.Interface;

namespace WebAPIREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;


        public UsuarioController(IEnderecoRepository enderecoRepository, IUsuarioRepository usuarioRepository)
        {
            _enderecoRepository = enderecoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login([FromBody] UsuarioLoginModel login)
        {

            var user = _usuarioRepository.GetLogin(login.Email, login.Password);
            if (user == null)
                return NotFound("E-mmail ou senha inválida");

            return Ok(user);
        }

        [HttpGet]
        [Route("List")]
        public IActionResult Get()
        {
            var user = _usuarioRepository.List();

            if (user == null)
                return NotFound("Nada encontrado");

            return Ok(user);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Post([FromBody] UsuarioModel user) {

            if (user == null)
                return BadRequest();

            _usuarioRepository.Add(user);

            return Ok("Registro adicionado com sucesso");
        
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Put([FromBody] UsuarioModel user) {

            if (user == null)
                return BadRequest();

            if (user.UsuarioId == 0)
                return BadRequest("ID do usuário não fornecido");

            var userResponse = _usuarioRepository.Update(user);
            if (userResponse.UsuarioId == 0)
                return BadRequest();

            return Ok(userResponse);

        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id) { 
        
            if(id == 0)
                return BadRequest();

            var user = _usuarioRepository.Get(id);

            if (user == null)
                return NoContent();


            if (user.ListaEndereco.Count() > 0)
                _enderecoRepository.Delete(user.ListaEndereco);


            var status = _usuarioRepository.Delete(id);

            if(!status)
                return BadRequest();

            return Ok("Registro excluido com sucesso");
        
        
        }
    }
}
