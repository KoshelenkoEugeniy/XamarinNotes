using System.Collections.Generic;

namespace XamarinNotes.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T newElement);

        void Delete(T element);

        void Update(T element);

        List<T> GetAll();

        T Get(IObjectId id);
    }
}
