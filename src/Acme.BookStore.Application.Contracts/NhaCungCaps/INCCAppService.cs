using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.NhaCungCaps
{
    public interface INCCAppService :
        ICrudAppService<
            NCCDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateNCCDto>
    {

    }
}
