using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Books
{
    [DependsOn(
    //...other dependencies
    typeof(CreateUpdateBookDtoValidator) //Add the FluentValidation module
    )]
    public class CreateUpdateBookDto
    {
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }
        
    }
}
