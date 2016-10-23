using System;

namespace WebServices.Models
{
    public class NoteDto
    {
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
    }
}