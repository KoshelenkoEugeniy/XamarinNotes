using System;
using SQLite;

namespace XamarinNotes
{
    public class NoteForDB
    {   
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public bool State { get; set; }

        public string Text { get; set; }

        public NoteForDB(int id, DateTime date, bool state, string text)
        {
            Id = id;
            DateOfCreation = date;
            State = state;
            Text = text;
        }

        public NoteForDB()
        {
        }
    }
}
