using UserManagement.Domain;
using UserManagement.Domain.Entities.Pessoas;
using UserManagement.Domain.Repositories.Pessoas;

namespace UserManagement.Infra.Repositories.Pessoas
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApiContext apiContext) : base(apiContext)
        {
        }
    }
}
