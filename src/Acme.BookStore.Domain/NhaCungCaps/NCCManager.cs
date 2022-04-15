using Acme.BookStore.NhaCungCap;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.NhaCungCaps
{
    public class NCCManager : DomainService
    {
        private readonly INCCRepository _nCCRepository;

        public NCCManager(INCCRepository nCCRepository)
        {
            _nCCRepository = nCCRepository;
        }

        public async Task<NCC> CreateAsync(
            [NotNull] string name,
            [CanBeNull] string address = null,
            [CanBeNull] string tellPhone = null,
            NCCType type = NCCType.Undefined)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingNCC = await _nCCRepository.FindByNameAsync(name);
            if (existingNCC != null)
            {
                throw new NCCAlreadyExistsException(name);
            }

            return new NCC(
                GuidGenerator.Create(),
                name,
                address,
                tellPhone,
                type
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] NCC nhaCungCap,
            [NotNull] string newName)
        {
            Check.NotNull(nhaCungCap, nameof(nhaCungCap));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingNCC = await _nCCRepository.FindByNameAsync(newName);
            if (existingNCC != null && existingNCC.Id != nhaCungCap.Id)
            {
                throw new NCCAlreadyExistsException(newName);
            }

            nhaCungCap.ChangeName(newName);
        }
    }
}
