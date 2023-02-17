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
        T Get(int id);
    }
}
