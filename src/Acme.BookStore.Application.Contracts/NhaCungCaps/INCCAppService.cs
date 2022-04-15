using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.NhaCungCaps
{
    public interface INCCAppService :
        IApplicationService
    {
        Task<NCCDto> GetAsync(Guid id);

        Task<PagedResultDto<NCCDto>> GetListAsync(GetNCCListDto input);

        Task<NCCDto> CreateAsync(CreateNCCDto input);

        Task UpdateAsync(Guid id, UpdateNCCDto input);

        Task DeleteAsync(Guid id);
    }
}
