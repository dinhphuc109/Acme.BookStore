using Acme.BookStore.NhaCungCaps;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.NhaCungCaps
{
    public class EditModalModel : BookStorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateNCCDto NCC { get; set; }

        private readonly INCCAppService _nCCAppService;

        public EditModalModel(INCCAppService nCCAppService)
        {
            _nCCAppService = nCCAppService;
        }
        public async Task OnGetasync()
        {
            var nCCDto = await _nCCAppService.GetAsync(Id);
            NCC = ObjectMapper.Map<NCCDto, CreateUpdateNCCDto>(nCCDto);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _nCCAppService.UpdateAsync(Id, NCC);
            return NoContent();
        }
    }
}
