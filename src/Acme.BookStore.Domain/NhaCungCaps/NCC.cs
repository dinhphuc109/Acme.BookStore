
using Acme.BookStore.NhaCungCap;
using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.NhaCungCaps
{
    public class NCC : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TellPhone { get; set; }
        public NCCType Type { get; set; }

        private NCC()
        {
        }

        internal NCC(
            Guid id,
            [NotNull] string name,
            [CanBeNull] string address = null,
            [CanBeNull] string tellPhone = null,
            NCCType type = NCCType.Undefined) : base(id)
        {
            SetName(name);
            Address = address;
            TellPhone = tellPhone;
            Type = type;
        }

        internal NCC ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: NCCConsts.MaxNameLength
            );
        }
    }
}
