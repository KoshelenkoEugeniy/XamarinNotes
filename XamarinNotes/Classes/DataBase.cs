using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XamarinNotes.Interfaces;
using SQLite;

namespace XamarinNotes.Classes
{
    public class DataBase<T> : IDataBase<T>
    {
        SQLiteConnection databaseConnection;

        public DataBase()
        {
            databaseConnection = new SQLiteConnection(GetDatabasePath());
            databaseConnection.CreateTable<NoteForDB>();
            databaseConnection.CreateTable<Picture>();
        }

        public string GetDatabasePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "NoteDB.db3");

            return path;
        }

        public T GetItemFromDB(IObjectId id)
        {
            List<Picture> attachments = new List<Picture>();
            Note currentNote = new Note();
            IObjectId tempObject = id;
            NoteForDB noteDB = new NoteForDB();

            noteDB = (from i in databaseConnection.Table<NoteForDB>()
                           where i.Id == tempObject.Id
                           select i).FirstOrDefault();

            attachments = (from j in databaseConnection.Table<Picture>()
                           where j.NoteId == noteDB.Id
                           select j).ToList();
            
            currentNote.Id = noteDB.Id;
            currentNote.Status = noteDB.State;
            currentNote.Text = noteDB.Text;
            currentNote.DateOfCreation = noteDB.DateOfCreation;
            currentNote.Attachments = attachments;

            return (T)((object)currentNote);
        }

        public List<T> ReadFromDB()
        {
            List<Picture> attachments = new List<Picture>();
            List<NoteForDB> notes = new List<NoteForDB>();
            List <Note> notesToShow = new List<Note>();

            notes = (from i in databaseConnection.Table<NoteForDB>()
                      select i).ToList();

            foreach(NoteForDB item in notes)
            {
                Note currentNote = new Note();
                currentNote.Id = item.Id;
                currentNote.Status = item.State;
                currentNote.Text = item.Text;
                currentNote.DateOfCreation = item.DateOfCreation;

                attachments = (from j in databaseConnection.Table<Picture>()
                               where j.NoteId == item.Id
                               select j).ToList();

                currentNote.Attachments = attachments;

                notesToShow.Add(currentNote);
            }

            List<T> returnList = (List<T>)((object)notesToShow);

            return returnList;
        }

        public void WriteToDB(T item)
        {
            Note currentNote = new Note();

            NoteForDB noteDB = new NoteForDB();

            currentNote = item as Note;

            noteDB = PrepareNoteDB(currentNote);

            databaseConnection.Insert(noteDB);

            if (currentNote.Attachments.Count > 0) 
            {
                foreach (var element in currentNote.Attachments)
                {
                    Picture pictureDB = new Picture();
                    pictureDB = element;
                    pictureDB.NoteId = noteDB.Id;

                    databaseConnection.Insert(pictureDB);
                }
            }
        }

        public void DeleteFromDB(T item)
        {
            Note currentNote = new Note();

            currentNote = item as Note;

            NoteForDB noteDB = new NoteForDB();

            noteDB = PrepareNoteDB(currentNote);

            databaseConnection.Delete(noteDB);

            if (currentNote.Attachments.Count > 0)
            {
                foreach (var element in currentNote.Attachments)
                {
                    Picture pictureDB = new Picture();
                    pictureDB = element;
                    pictureDB.NoteId = noteDB.Id;

                    databaseConnection.Delete(pictureDB);
                }
            }
        }

        public void Update(T item)
        {
            Note currentNote = new Note();

            currentNote = item as Note;

            T oldElement = GetItemFromDB(currentNote);

            DeleteFromDB(oldElement);

            WriteToDB(item);
        }

        private NoteForDB PrepareNoteDB (Note item)
        {
            NoteForDB temp = new NoteForDB();

            temp.Id = item.Id;
            temp.State = item.Status;
            temp.Text = item.Text;
            temp.DateOfCreation = item.DateOfCreation;

            return temp;
        }
    }
}
