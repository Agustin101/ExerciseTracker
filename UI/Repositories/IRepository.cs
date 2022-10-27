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
        
        Task<TType> Insert(TType entity);
        Task Remove(TKey id);
        Task<TType> Update(TType entity, TKey id);
        Task Save();

    }
}
