using XamarinNotes.Interfaces;
using SQLite;

namespace XamarinNotes.Classes
{
    public class Picture:IObjectId
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Link { get; set; }
        public int NoteId { get; set; }
        
        public Picture()
        {
            Name = "";
            Extension = "";
            Link = "";
        }

        public Picture(string name, string extension, string link)
        {
            Name = name;
            Extension = extension;
            Link = link;
        }

        public Picture(int id, string name, string extension, string link, int noteId)
        {
            Id = id;
            Name = name;
            Extension = extension;
            Link = link;
            NoteId = noteId;
        }
    }
}
