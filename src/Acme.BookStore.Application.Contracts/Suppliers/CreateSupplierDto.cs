using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Suppliers
{
    public class CreateSupplierDto
    {
        [Required]
        [StringLength(SupplierConsts.MaxNameLength)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelePhone { get; set; }
    }
}