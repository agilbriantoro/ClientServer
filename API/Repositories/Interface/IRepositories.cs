using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.SqlTypes;

namespace API.Repositories.Interface
{
    public interface IRepository<Key, Entity> where Entity : class
    {
        // GET
        Task<IEnumerable<Entity>> GetAll();
        // GetByID
        Task<Entity> GetById(Key key);
        // Create
        Task<int> Insert(Entity entity);
        // Update
        Task<int> Update(Entity entity);
        // Delete
        Task<int> Delete(Key key);
    }
}
