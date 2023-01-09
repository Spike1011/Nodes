using System;
using FluentValidation;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.Application.Notes.Commands.UpdateNote
{
	public class UpdateNoteCommandValidation : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidation()
        {
            RuleFor(note => note.UserId).NotEqual(Guid.Empty);
            RuleFor(note => note.Id).NotEqual(Guid.Empty);
            RuleFor(note => note.Title).NotEmpty().MaximumLength(250);
        }
    }
}

