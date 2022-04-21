using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Acme.BookStore.Suppliers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Suppliers
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditSupplierViewModel Supplier { get; set; }

        private readonly ISupplierAppService _supplierAppService;

        public EditModalModel(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var supplierDto = await _supplierAppService.GetAsync(id);
            Supplier = ObjectMapper.Map<SupplierDto, EditSupplierViewModel>(supplierDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _supplierAppService.UpdateAsync(
                Supplier.Id,
                ObjectMapper.Map<EditSupplierViewModel, UpdateSupplierDto>(Supplier)
            );

            return NoContent();
        }

        public class EditSupplierViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [Required]
            [StringLength(SupplierConsts.MaxNameLength)]
            public string Name { get; set; }

            public string Address { get; set; }

            public string TelePhone { get; set; }
        }
    }
}
