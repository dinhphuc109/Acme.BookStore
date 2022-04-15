using Acme.BookStore.NhaCungCap;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.NhaCungCaps
{
    public class UpdateNCCDto
    {
        [Required]
        [StringLength(NCCConsts.MaxNameLength)]
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string TellPhone { get; set; }

        public NCCType Type { get; set; } = NCCType.Undefined;
    }
}