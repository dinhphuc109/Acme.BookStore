using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Suppliers
{
    public class SupplierDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelePhone { get; set; }
    }
}