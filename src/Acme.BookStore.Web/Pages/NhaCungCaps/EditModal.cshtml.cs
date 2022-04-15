using Acme.BookStore.NhaCungCaps;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Acme.BookStore.NhaCungCap;

namespace Acme.BookStore.Web.Pages.NhaCungCaps
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditNCCViewModel NCC { get; set; }


        private readonly INCCAppService _nCCAppService;

        public EditModalModel(INCCAppService nCCAppService)
        {
            _nCCAppService = nCCAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var nccDto = await _nCCAppService.GetAsync(id);
            NCC = ObjectMapper.Map<NCCDto, EditNCCViewModel>(nccDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _nCCAppService.UpdateAsync(
            NCC.Id,
            ObjectMapper.Map<EditNCCViewModel, UpdateNCCDto>(NCC)
            );
            return NoContent();
        }

        public class EditNCCViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [Required]
            [StringLength(NCCConsts.MaxNameLength)]
            public string Name { get; set; }

            public string Address { get; set; }

            public string TellPhone { get; set; }

            public NCCType Type { get; set; } = NCCType.Undefined;
        }
    }
}
