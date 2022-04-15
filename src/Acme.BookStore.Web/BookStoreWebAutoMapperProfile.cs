using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.NhaCungCaps;
using AutoMapper;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        
        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<NCCDto, Pages.NhaCungCaps.EditModalModel.EditNCCViewModel>();
        CreateMap<Pages.NhaCungCaps.EditModalModel.EditNCCViewModel, UpdateNCCDto>();
        CreateMap<Pages.NhaCungCaps.CreateModalModel.CreateNCCViewModel, CreateNCCDto>();

        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();

        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();

        CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel, UpdateAuthorDto>();

        CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();

        CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();

        CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

    }
}
