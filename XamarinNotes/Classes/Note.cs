using System;
using System.Collections.Generic;
using XamarinNotes.Interfaces;

namespace XamarinNotes.Classes
{
    public class Note: IObjectId, IComparable<Note>
    {
        public int Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public bool Status { get; set; }

        public string Text { get; set; }

        public List<Picture> Attachments { get; set; }

        public Note()
        {
            DateOfCreation = DateTime.MinValue;
            Text = "";
            Status = false;
            Attachments = new List<Picture>();
        }

        public Note(String text)
        {
            DateOfCreation = DateTime.Now;
            Text = text;
            Status = true;
            Attachments = new List<Picture>();
        }

        public Note(String text, bool status, int id, List<Picture> attachments)
        {
            DateOfCreation = DateTime.Now;
            Text = text;
            Status = status;
            Id = id;
            Attachments = attachments;
        }

        public int CompareTo(Note otherNote)
        {
            return this.DateOfCreation.CompareTo(otherNote.DateOfCreation);
        } 
    }
}
