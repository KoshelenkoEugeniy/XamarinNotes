using System.Collections.Generic;

namespace XamarinNotes.Interfaces
{
    public interface IDataBase<T>
    {
        void WriteToDB(T item);

        void DeleteFromDB(T item);

        void Update(T item);

        List<T> ReadFromDB();

        T GetItemFromDB(IObjectId id);
    }
}
