using FluentValidation;
using Music.Application.CQRS.Music.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Music.Validator
{
    public class CreateMusicValidator : AbstractValidator<CreateMusicCommand>
    {
        public CreateMusicValidator()
        {
            RuleFor(x => x.ArtistId)
               .NotEmpty();
            RuleFor(x => x.Name)
               .NotEmpty();
        }
    }
}
