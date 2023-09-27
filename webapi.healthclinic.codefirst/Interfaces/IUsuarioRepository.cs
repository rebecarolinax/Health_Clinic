using webapi.healthclinic.codefirst.Domains;

namespace webapi.healthclinic.codefirst.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuarioCadastrado);
        List<Usuario> ListarTodos();
        void Atualizar(Guid id, Usuario usuarioAtualizado);
        void Deletar(Guid id);
        Usuario BuscarPorEmailESenha(string Email, string Senha);
        Usuario BuscarPorId(Guid id);
    }
}
