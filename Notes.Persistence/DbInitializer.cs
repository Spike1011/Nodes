using System;
using Microsoft.EntityFrameworkCore;

namespace Notes.Persistence
{
	public static class DbInitializer
	{
		public static void Initialize(NotesDbContext context)
        {
            //context.Database.EnsureCreated();
            //context.Database.Migrate();

            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
	}
}

