using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.NhaCungCaps
{
    public class GetNCCListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}