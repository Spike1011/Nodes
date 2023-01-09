using System;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Interfaces
{
	public interface INotesDbContext
	{
		DbSet<Note> Notes { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Test> Tests { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}

