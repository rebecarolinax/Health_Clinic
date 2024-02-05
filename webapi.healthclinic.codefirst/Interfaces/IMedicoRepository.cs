using webapi.healthclinic.codefirst.Domains;

namespace webapi.healthclinic.codefirst.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medicoCadastrado);
        List<Medico> ListarTodos();
        void Atualizar(Guid id, Medico medicoAtualizado);
        void Deletar(Guid id);
        Medico BuscarPorId(Guid id);
    }
}
