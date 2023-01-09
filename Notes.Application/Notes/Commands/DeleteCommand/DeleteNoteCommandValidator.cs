using System;
using FluentValidation;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
	public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(note => note.Id).NotEqual(Guid.Empty);
            RuleFor(note => note.UserId).NotEqual(Guid.Empty);
        }
    }
}

