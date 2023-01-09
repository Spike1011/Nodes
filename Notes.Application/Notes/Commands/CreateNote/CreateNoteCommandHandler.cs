using System;
using MediatR;
using Notes.Domain;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Commands.CreateNote
{
	/// <summary>
	/// Описывает запрос, ответ в интерфейсе
	/// </summary>
	public class CreateNoteCommandHandler
		:IRequestHandler<CreateNoteCommand, Guid>
	{

		private readonly INotesDbContext _dbContext;

		/// <summary>
		/// Конструктур для передачи контекста
		/// </summary>
		/// <param name="dbContext"></param>
		public CreateNoteCommandHandler(INotesDbContext dbContext) =>
			_dbContext = dbContext;

		/// <summary>
		/// Бизнес логика сохранения
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<Guid> Handle(CreateNoteCommand request,
			CancellationToken cancellationToken)
		{
			var note = new Note
			{
				UserId = request.UserId,
				Title = request.Title,
				Details = request.Details,
				Id = Guid.NewGuid(),
				CreationDate = DateTime.Now,
				EditDate = null
			};

			// сохранение
			await _dbContext.Notes.AddAsync(note, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return note.Id;
		}
	}
}

