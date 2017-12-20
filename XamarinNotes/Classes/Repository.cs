using System.Collections.Generic;
using XamarinNotes.Interfaces;

namespace XamarinNotes.Classes
{
    public abstract class Repository<T> : IRepository<T> where T : IObjectId
    {
        private DataBase<T> _dbContext = new DataBase<T>();

        public void Create(T newElement)
        {
            _dbContext.WriteToDB(newElement);
        }

        public void Delete(T element)
        {
            _dbContext.DeleteFromDB(element);
        }

        public void Update(T element)
        {
            _dbContext.Update(element);
        }

        public List<T> GetAll()
        {
            return _dbContext.ReadFromDB();
        }

        public T Get(IObjectId id)
        {
            return _dbContext.GetItemFromDB(id);
        }
    }
}
