using Acme.BookStore.NhaCungCaps;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Acme.BookStore.Web.Pages.NhaCungCaps
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateUpdateNCCDto NCC { get; set; }

        private readonly INCCAppService _nCCAppService;

        public CreateModalModel(INCCAppService nCCAppService)
        {
            _nCCAppService = nCCAppService;
        }

        public void OnGet()
        {
            NCC = new CreateUpdateNCCDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _nCCAppService.CreateAsync(NCC);
            return NoContent();
        }
    }
}
