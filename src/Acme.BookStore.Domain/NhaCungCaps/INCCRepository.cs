using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.NhaCungCaps
{
    public interface INCCRepository : IRepository<NCC, Guid>
    {
        Task<NCC> FindByNameAsync(string name);
        
        Task<List<NCC>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}
