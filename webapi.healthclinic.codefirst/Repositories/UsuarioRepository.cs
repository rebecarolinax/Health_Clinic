using webapi.healthclinic.codefirst.Contexts;
using webapi.healthclinic.codefirst.Domains;
using webapi.healthclinic.codefirst.Interfaces;
using webapi.healthclinic.codefirst.Utils;

namespace webapi.healthclinic.codefirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext c;
        public UsuarioRepository()
        {
            c = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Usuario usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = c.Usuario!.Find(id)!;

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
                }

                c.Usuario.Update(usuarioBuscado!);

                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                Usuario usuarioBuscado = c.Usuario!
                 .Select(u => new Usuario
                 {
                     IdUsuario = u.IdUsuario,
                     IdTipoUsuario = u.IdTipoUsuario,
                     NomeUsuario = u.NomeUsuario,
                     CPF = u.CPF,
                     Email = u.Email,
                     Senha = u.Senha,
                     TipoUsuario = new TipoUsuario
                     {
                         Titulo = u.TipoUsuario!.Titulo
                     }

                 }).FirstOrDefault(u => u.Email == Email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            return c.Usuario!.FirstOrDefault(t => t.IdUsuario == id)!;
        }

        public void Cadastrar(Usuario usuarioCadastrado)
        {
            try
            {
                c.Usuario!.Add(usuarioCadastrado);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = c.Usuario!.Find(id)!;
                c.Usuario.Remove(usuarioBuscado);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> ListarTodos()
        {
            return c.Usuario!.ToList();
        }
    }
}
