using Acme.BookStore.Books;
using Acme.BookStore.NhaCungCap;
using Acme.BookStore.NhaCungCaps;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Acme.BookStore.Web.Pages.NhaCungCaps
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateNCCViewModel NCC { get; set; }


        private readonly INCCAppService _nCCAppService;

        public CreateModalModel(INCCAppService nCCAppService)
        {
            _nCCAppService = nCCAppService;
        }

        public void OnGet()
        {
            NCC = new CreateNCCViewModel();
            //NCC2 = new CreateUpdateBookDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var nccdto = ObjectMapper.Map<CreateNCCViewModel, CreateNCCDto>(NCC);
            await _nCCAppService.CreateAsync(nccdto);
            return NoContent();
        }

        public class CreateNCCViewModel
        {
            [Required]
            [StringLength(NCCConsts.MaxNameLength)]
            public string Name { get; set; }

            public string Address { get; set; }

            public string TellPhone { get; set; }

            public NCCType Type { get; set; } = NCCType.Undefined;
        }

    }
}
