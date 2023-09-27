using webapi.healthclinic.codefirst.Contexts;
using webapi.healthclinic.codefirst.Domains;
using webapi.healthclinic.codefirst.Interfaces;

namespace webapi.healthclinic.codefirst.Repositories
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly HealthClinicContext c;
        public FeedBackRepository()
        {
            c = new HealthClinicContext();
        }

        public void Atualizar(Guid id, FeedBack feedbackAtualizado)
        {
            try
            {
                FeedBack feedbackBuscado = c.FeedBack!.Find(id)!;

                if (feedbackBuscado != null)
                {
                    feedbackBuscado.FeedbackConsulta = feedbackAtualizado.FeedbackConsulta;
                }

                c.FeedBack.Update(feedbackBuscado!);

                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FeedBack BuscarPorId(Guid id)
        {
            return c.FeedBack!.FirstOrDefault(f => f.IdFeedBack == id)!;
        }

        public void Cadastrar(FeedBack feedbackCadastrado)
        {
            try
            {
                c.FeedBack!.Add(feedbackCadastrado);
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
                FeedBack feedbackBuscado = c.FeedBack!.Find(id)!;
                c.FeedBack.Remove(feedbackBuscado);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FeedBack> ListarTodos()
        {
            return c.FeedBack!.ToList();
        }
    }
}
