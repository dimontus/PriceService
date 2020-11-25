using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BaseRepositories;
using Dapper;
using Microsoft.Extensions.Options;
using PriceService.Repositories;

namespace PriceService.Repository
{
    public class PriceRepository : BaseRepository<PriceDbModel>, IPriceRepository
    {
        public PriceRepository(IOptions<PriceDbOptions> dbOptions) : base(dbOptions)
        {
        }

        public async Task<IEnumerable<PriceDbModel>> GetAll(CancellationToken token)
        {
            await using var db = await GetSqlConnection();
            return await db.QueryAsync<PriceDbModel>(new CommandDefinition($"SELECT * FROM [Price] WHERE [IsDeleted] = 0", token));
        }
    }
}