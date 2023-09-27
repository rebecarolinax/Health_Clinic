using webapi.healthclinic.codefirst.Domains;

namespace webapi.healthclinic.codefirst.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidadeCadastrada);
        List<Especialidade> ListarTodos();
        void Atualizar(Guid id, Especialidade especialidadeAtualizada);
        void Deletar(Guid id);
        Especialidade BuscarPorId(Guid id);
    }
}
