using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lourtec.ContactoMVC.DAL.Contracts
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Create(TEntityModel entity);
        Task<bool> Update(TEntityModel entity);
        Task<bool> Delete(int id);
        Task<TEntityModel> Get(int id);
        Task<IQueryable<TEntityModel>> GetAll();
    }
}
