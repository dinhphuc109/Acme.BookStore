using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Books
{
    [DependsOn(
    //...other dependencies
    typeof(BookDtoValidator) //Add the FluentValidation module
    )]
    public class BookDto : AuditedEntityDto<Guid>
    {
        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
