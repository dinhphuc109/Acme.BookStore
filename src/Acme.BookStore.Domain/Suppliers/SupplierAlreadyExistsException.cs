using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace Acme.BookStore.Suppliers
{
    public class SupplierAlreadyExistsException : BusinessException
    {

        public SupplierAlreadyExistsException(string name)
            : base(BookStoreDomainErrorCodes.NCCAlreadyExists)
        {
            WithData("name", name);
        }
    }
}