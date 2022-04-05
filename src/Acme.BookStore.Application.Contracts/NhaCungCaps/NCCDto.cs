using Acme.BookStore.NhaCungCap;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.NhaCungCaps
{
    public class NCCDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TellPhone { get; set; }
        public NCCType Type { get; set; }
    }
}
