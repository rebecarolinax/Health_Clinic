using webapi.healthclinic.codefirst.Contexts;
using webapi.healthclinic.codefirst.Domains;
using webapi.healthclinic.codefirst.Interfaces;

namespace webapi.healthclinic.codefirst.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthClinicContext c;
        public TipoUsuarioRepository()
        {
            c = new HealthClinicContext();
        }

        public void Atualizar(Guid id, TipoUsuario usuarioAtualizado)
        {
            try
            {
                TipoUsuario tipoBuscado = c.TipoUsuario!.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.Titulo = usuarioAtualizado.Titulo;
                }

                c.TipoUsuario.Update(tipoBuscado!);

                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return c.TipoUsuario!.FirstOrDefault(t => t.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TipoUsuario usuarioCadastrado)
        {
            try
            {
                c.TipoUsuario!.Add(usuarioCadastrado);
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
                TipoUsuario tipoBuscado = c.TipoUsuario!.Find(id)!;
                c.TipoUsuario.Remove(tipoBuscado);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoUsuario> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
