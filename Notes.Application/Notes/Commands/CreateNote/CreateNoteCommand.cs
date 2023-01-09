using System;
using MediatR;

namespace Notes.Application.Notes.Commands.CreateNote
{
    /// <summary>
    /// Отправка данных на сохранение. В IRequest описан return
    /// </summary>
    public class CreateNoteCommand : IRequest<Guid>
	{
		public Guid UserId { get; set; }
		public string Title { get; set; }
		public string Details { get; set; }
	}
}

