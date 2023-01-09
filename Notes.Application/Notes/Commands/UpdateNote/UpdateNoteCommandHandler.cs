using System;
using MediatR;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exception;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler
        : IRequestHandler<UpdateNoteCommand>
    {

        private readonly INotesDbContext _dbContext;

        /// <summary>
        /// Конструктур для передачи контекста
        /// </summary>
        /// <param name="dbContext"></param>
        public UpdateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                new NotFoundException(nameof(Note), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

