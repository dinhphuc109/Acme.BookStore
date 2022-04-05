
using Acme.BookStore.NhaCungCap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.NhaCungCaps
{
    public class NCC : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TellPhone { get; set; }
        public NCCType Type { get; set; }
    }
}
