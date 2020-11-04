using System.Collections.Generic;
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

        public override async Task<IEnumerable<PriceDbModel>> GetAll()
        {
            await using var db = await GetSqlConnection();
            return await db.QueryAsync<PriceDbModel>($"SELECT * FROM [Price] WHERE [IsDeleted] = 0");
        }
    }
}