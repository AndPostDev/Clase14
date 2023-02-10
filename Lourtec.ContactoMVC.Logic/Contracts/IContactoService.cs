using Lourtec.ContactoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lourtec.ContactoMVC.Logic.Contracts
{
    public interface IContactoService
    {
        Task<bool> Create(Contacto contacto);
        Task<bool> Update(Contacto contacto);
        Task<bool> Delete(int id);
        Task<Contacto> Get(int id);
        Task<IQueryable<Contacto>> GetAll();
        Task<Contacto> GetName(string name);
    }
}
