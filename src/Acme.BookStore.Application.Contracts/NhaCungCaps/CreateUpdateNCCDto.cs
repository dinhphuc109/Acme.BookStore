using Acme.BookStore.NhaCungCap;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.NhaCungCaps
{
    public class CreateUpdateNCCDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string TellPhone { get; set; }
        [Required]
        public NCCType Type { get; set; } = NCCType.Undefined;
    }
}
