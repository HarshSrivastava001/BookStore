using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllAsync();
        T GetByIdAsync(int id);
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(int id);
    }
}
