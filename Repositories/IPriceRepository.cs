using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BaseRepositories;

namespace PriceService.Repository
{
    public interface IPriceRepository : IBaseRepository<PriceDbModel>
    {
        Task<IEnumerable<PriceDbModel>> GetAll(CancellationToken token);
    }
}