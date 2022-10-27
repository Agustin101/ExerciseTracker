using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Repositories
{
    public interface IRepository<TType, TKey> where TType : class
    {
        Task<TType> GetById(TKey id);
        Task<IEnumerable<TType>> GetAll();
        
        Task<bool> Insert(TType entity);
        Task<bool> Remove(TKey id);
        Task<bool> Update(TType entity);
        Task Save();

    }
}
