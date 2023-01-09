using System;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfigurations;

namespace Notes.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Test> Tests { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            builder.ApplyConfiguration(new BookConfigurations());
            builder.ApplyConfiguration(new TestConfigurations());
            base.OnModelCreating(builder);
        }
    }
}

