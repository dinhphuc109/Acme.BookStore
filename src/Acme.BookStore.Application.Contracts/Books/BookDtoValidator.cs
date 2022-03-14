﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Books
{
    public class BookDtoValidator : AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(c => c.Name).Length(3, 12).NotEmpty().NotNull();
            RuleFor(c => c.Price).ExclusiveBetween(0.0f, 999.0f).NotEmpty().NotNull();
        }
    }
}