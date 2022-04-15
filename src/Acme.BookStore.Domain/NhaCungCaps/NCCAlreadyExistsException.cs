using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace Acme.BookStore.NhaCungCaps
{
    [Serializable]
    internal class NCCAlreadyExistsException : BusinessException
    {
        public NCCAlreadyExistsException(string name)
            : base(BookStoreDomainErrorCodes.NCCAlreadyExists)
        {
            WithData("name", name);
        }

    }
}