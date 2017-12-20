using System;
using System.Collections.Generic;
using XamarinNotes.Interfaces;

namespace XamarinNotes.Classes
{
    public class Model: Repository<Note>, IObservable
    {
        private List<IObserver> observers;

        List<Note> NoteList = new List<Note>();

        public Model()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver newObserver)
        {
            observers.Add(newObserver);
        }

        public void RemoveObserver(IObserver currentObserver)
        {
            observers.Remove(currentObserver);
        }

        public void NotifyObservers(string answer)
        {
            if (answer == "ok")
            {
                NoteList.Clear();
                NoteList = GetAll();
            }
            else
            {
                NoteList = null;
            }

            foreach (IObserver item in observers)
            {
                item.Update(NoteList, answer);
            }
        }

        public void ToDo(string task, Note newNote)
        {
            try
            {
                switch (task)
                {
                    case "Create":
                        Create(newNote);    // add element to local collection
                        break;
                    case "Delete":
                        Delete(newNote);    // delete element from local collection
                        break;
                    case "Change":
                        Update(newNote);  // update element in local collection
                        break;
                    case "Synchronize":
                    default:
                        NotifyObservers("ok");
                        return;
                }

                NotifyObservers("ok");
            }
            catch (Exception ex)
            {
                NotifyObservers(ex.Message);
            }
        }
    }
}
