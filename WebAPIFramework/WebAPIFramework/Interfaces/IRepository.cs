using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIFramework.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAll(string filter=null);
        Task<T> GetByIndex(int i);
        Task<T> DeleteByIndex(int i);
        Task<T> DeleteByItem(T item);
        Task<T> AddItem(T item);
        Task<T> AddOnIndex(T item, int i);
        Task<T> UpdateByIndex(T item, int i);
    }
}
