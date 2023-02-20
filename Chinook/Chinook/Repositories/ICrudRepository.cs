using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Repositories
{
    public interface ICrudRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetByName(string name);
        IEnumerable<T> GetPage(int limit, int offset);

        void Add(T entity);

        void Update( int id, T entity);

        
    }
}
