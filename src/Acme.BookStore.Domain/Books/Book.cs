using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    public class Book : AggregateRoot<Guid>
    {
        public const int MaxNameLength = 128;
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }

        public Guid AuthorId { get; set; }

        protected Book()
        {

        }

        public Book(Guid id, [NotNull] string name, BookType type, float? price = 0)
        {
            Id = id;
            Name = CheckName(name);
            Type = type;
            Price = (float)price;
        }

        public virtual void ChangeName([NotNull] string name)
        {
            Name = CheckName(name);
        }

        private static string CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    $"name can not be empty or white space!");
            }

            if (name.Length > MaxNameLength)
            {
                throw new ArgumentException(
                    $"name can not be longer than {MaxNameLength} chars!");
            }

            return name;
        }
    }
}
