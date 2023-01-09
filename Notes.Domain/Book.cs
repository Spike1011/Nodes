using System;
namespace Notes.Domain
{
	public class Book
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int CountPage { get; set; }
        public string Autor { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

