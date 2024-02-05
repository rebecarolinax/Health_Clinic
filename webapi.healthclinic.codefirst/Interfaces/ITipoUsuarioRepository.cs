using webapi.healthclinic.codefirst.Domains;

namespace webapi.healthclinic.codefirst.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario usuarioCadastrado);
        List<TipoUsuario> ListarTodos();
        void Atualizar(Guid id, TipoUsuario usuarioAtualizado);
        void Deletar(Guid id);
        TipoUsuario BuscarPorId(Guid id);
    }
}
