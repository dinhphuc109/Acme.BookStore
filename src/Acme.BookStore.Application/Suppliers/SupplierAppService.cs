using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Suppliers
{
    public class SupplierAppService : BookStoreAppService, ISupplierAppService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierManager _supplierManager;

        public SupplierAppService(
            ISupplierRepository supplierRepository,
            SupplierManager supplierManager)
        {
            _supplierRepository = supplierRepository;
            _supplierManager = supplierManager;
        }
        public async Task<SupplierDto> CreateAsync(CreateSupplierDto input)
        {
            var supplier = await _supplierManager.CreateAsync(
                input.Name,
                input.Address,
                input.TelePhone
            );

            await _supplierRepository.InsertAsync(supplier);

            return ObjectMapper.Map<Supplier, SupplierDto>(supplier);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _supplierRepository.DeleteAsync(id);
        }

        public async Task<SupplierDto> GetAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetAsync(id);
            return ObjectMapper.Map<Supplier, SupplierDto>(supplier);
        }

        public async Task<PagedResultDto<SupplierDto>> GetListAsync(GetSupplierListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Supplier.Name);
            }

            var suppliers = await _supplierRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _supplierRepository.CountAsync()
                : await _supplierRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<SupplierDto>(
                totalCount,
                ObjectMapper.Map<List<Supplier>, List<SupplierDto>>(suppliers)
            );
        }

        public async Task UpdateAsync(Guid id, UpdateSupplierDto input)
        {
            var supplier = await _supplierRepository.GetAsync(id);

            if (supplier.Name != input.Name)
            {
                await _supplierManager.ChangeNameAsync(supplier, input.Name);
            }

            supplier.Address = input.Address;
            supplier.TelePhone = input.TelePhone;

            await _supplierRepository.UpdateAsync(supplier);
        }
    }
}
