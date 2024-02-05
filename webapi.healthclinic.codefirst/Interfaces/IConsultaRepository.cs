using webapi.healthclinic.codefirst.Domains;

namespace webapi.healthclinic.codefirst.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consultaCadastrada);
        List<Consulta> ListarTodos();
        void Atualizar(Guid id, Consulta consultaAtualizada);
        void Deletar(Guid id);
        Consulta BuscarPorId(Guid id);
    }
}
