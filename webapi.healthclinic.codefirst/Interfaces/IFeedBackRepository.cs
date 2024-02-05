using webapi.healthclinic.codefirst.Domains;

namespace webapi.healthclinic.codefirst.Interfaces
{
    public interface IFeedBackRepository
    {
        void Cadastrar(FeedBack feedbackCadastrado);
        List<FeedBack> ListarTodos();
        void Atualizar(Guid id, FeedBack feedbackAtualizado);
        void Deletar(Guid id);
        FeedBack BuscarPorId(Guid id);
    }
}
