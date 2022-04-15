using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.NhaCungCaps
{
    [Authorize(BookStorePermissions.NhaCungCaps.Default)]
    public class NCCAppService :
        BookStoreAppService,
        INCCAppService
    {
        private readonly INCCRepository _nCCRepository;
        private readonly NCCManager _nCCManager;

        public NCCAppService(
            INCCRepository nCCRepository,
            NCCManager nCCManager)
        {
            _nCCRepository = nCCRepository;
            _nCCManager = nCCManager;
        }

        [Authorize(BookStorePermissions.NhaCungCaps.Create)]
        public async Task<NCCDto> CreateAsync(CreateNCCDto input)
        {
            var ncc = await _nCCManager.CreateAsync(
                input.Name,
                input.Address,
                input.TellPhone,
                input.Type
                );
            await _nCCRepository.InsertAsync(ncc);
            return ObjectMapper.Map<NCC, NCCDto>(ncc);
        }

        [Authorize(BookStorePermissions.NhaCungCaps.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _nCCRepository.DeleteAsync(id);
        }

        public async Task<NCCDto> GetAsync(Guid id)
        {
            var ncc = await _nCCRepository.GetAsync(id);
            return ObjectMapper.Map<NCC, NCCDto>(ncc);
        }

        public async Task<PagedResultDto<NCCDto>> GetListAsync(GetNCCListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(NCC.Name);
            }
            var nccs = await _nCCRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
                );
            var totalCount = input.Filter==null
                ? await _nCCRepository.CountAsync()
                : await _nCCRepository.CountAsync(
                    ncc=> ncc.Name.Contains(input.Filter));
            return new PagedResultDto<NCCDto>(
                totalCount,
                ObjectMapper.Map<List<NCC>, List<NCCDto>>(nccs));
        }

        [Authorize(BookStorePermissions.NhaCungCaps.Edit)]
        public async Task UpdateAsync(Guid id, UpdateNCCDto input)
        {
            var ncc=await _nCCRepository.GetAsync(id);
            if (ncc.Name != input.Name)
            {
                await _nCCManager.ChangeNameAsync(ncc, input.Name);
            }
            ncc.Address = input.Address;
            ncc.TellPhone = input.TellPhone;
            ncc.Type = input.Type;
            await _nCCRepository.UpdateAsync(ncc);
        }
    }
}
