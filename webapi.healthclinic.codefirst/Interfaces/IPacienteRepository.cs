using webapi.healthclinic.codefirst.Domains;

namespace webapi.healthclinic.codefirst.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente pacienteCadastrado);
        List<Paciente> ListarTodos();
        void Atualizar(Guid id, Paciente pacienteAtualizado);
        void Deletar(Guid id);
        Paciente BuscarPorId(Guid id);
    }
}
