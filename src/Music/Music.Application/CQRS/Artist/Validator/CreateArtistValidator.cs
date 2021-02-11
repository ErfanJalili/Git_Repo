using FluentValidation;
using Music.Application.CQRS.Artist.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Artist.Validator
{
    public class CreateArtistValidator : AbstractValidator<CreateArtistCommand>
    {
        public CreateArtistValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty();
        }
    }
}
