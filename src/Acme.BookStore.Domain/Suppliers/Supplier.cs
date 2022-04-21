using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Suppliers
{
    public class Supplier : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelePhone { get; set; }

        private Supplier()
        {

        }

        internal Supplier(
            Guid id,
            [NotNull] string name,
            string address,
            string telephone)
            : base(id)
        {
            SetName(name);
            Address = address;
            TelePhone = telephone;
        }

        internal Supplier ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: SupplierConsts.MaxNameLength
            );
        }
    }
}
