using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Suppliers;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Acme.BookStore.MongoDB;

[ConnectionStringName("Default")]
public class BookStoreMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<Supplier> Suppliers => Collection<Supplier>();

    public IMongoCollection<Author> Authors => Collection<Author>();

    public IMongoCollection<Book> Books => Collection<Book>();
    
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //builder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
