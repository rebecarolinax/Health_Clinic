using webapi.healthclinic.codefirst.Domains;

namespace webapi.healthclinic.codefirst.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinicaCadastrada);
        List<Clinica> ListarTodos();
        void Atualizar(Guid id, Clinica clinicaAtualizada);
        void Deletar(Guid id);
        Clinica BuscarPorId(Guid id);
    }
}
