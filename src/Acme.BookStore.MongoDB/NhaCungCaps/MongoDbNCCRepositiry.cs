using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Abp.Collections.Extensions;

namespace Acme.BookStore.NhaCungCaps
{
    public class MongoDbNCCRepositiry
                : MongoDbRepository<BookStoreMongoDbContext, NCC, Guid>,
        INCCRepository
    {
        public MongoDbNCCRepositiry(
            IMongoDbContextProvider<BookStoreMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<NCC> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(ncc=>ncc.Name==name);
        }
        public async Task<List<NCC>> GetListAsync(
            int skipCount, 
            int maxResultCount, 
            string sorting, 
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<NCC, IMongoQueryable<NCC>>(
                    !filter.IsNullOrWhiteSpace(),
                    ncc => ncc.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<NCC>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
