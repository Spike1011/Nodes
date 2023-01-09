using System;
using FluentValidation;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.Application.Notes.Queries.GetNoteList
{
	public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}

