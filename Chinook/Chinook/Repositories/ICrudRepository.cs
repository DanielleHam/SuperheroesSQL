using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Repositories
{
    public interface ICrudRepository<T>
    {
        /// <summary>
        /// Gets all entities within the repository
        /// </summary>
        /// <returns>IEnumerable of fetched entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets an entity by ID
        /// </summary>
        /// <param name="id">ID of entity</param>
        /// <returns>Fetched entity</returns>
        T GetById(int id);
        /// <summary>
        /// Gets all entities with names that are similar to input
        /// </summary>
        /// <param name="name">Name to fetch for</param>
        /// <returns>IEnumerable of fetched entities</returns>
        IEnumerable<T> GetByName(string name);

        /// <summary>
        /// Gets an IEnumerable of entities limited by a limit and offset.
        /// </summary>
        /// <param name="limit">How many entities to fetch</param>
        /// <param name="offset">Where to start fetching entities from</param>
        /// <returns>IEnumerable of fetched entities</returns>
        IEnumerable<T> GetPage(int limit, int offset);

        /// <summary>
        /// Adds an entity to the repository
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Add(T entity);
        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="id">ID to update from</param>
        /// <param name="entity">Updated entity</param>
        void Update( int id, T entity);
    }
}
