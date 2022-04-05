using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.NhaCungCaps
{
    public class NCCAppService :
        CrudAppService<
            NCC,
            NCCDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateNCCDto>,
        INCCAppService
    {
        public NCCAppService(IRepository<NCC, Guid> repository) : base(repository)
        {
        }
    }
}
