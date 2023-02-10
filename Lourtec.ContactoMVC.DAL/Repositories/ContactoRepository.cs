using Lourtec.ContactoMVC.DAL.Contracts;
using Lourtec.ContactoMVC.DAL.DataContext;
using Lourtec.ContactoMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lourtec.ContactoMVC.DAL.Repositories
{
    public class ContactoRepository : IGenericRepository<Contacto>
    {
        private readonly DbcontactoContext _dbContext;

        public ContactoRepository(DbcontactoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Contacto entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Contacto contacto = _dbContext.Contactos.First(c => c.IdContacto == id);
            _dbContext.Contactos.Remove(contacto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Contacto> Get(int id)
        {
            return await _dbContext.Contactos.FindAsync(id);
        }

        public async Task<IQueryable<Contacto>> GetAll()
        {
            IQueryable<Contacto> queryContactoSQL = _dbContext.Contactos; // Se usan mas para
                                                                          // informaciones genericas asincornas
            return queryContactoSQL;
        }

        public async Task<bool> Update(Contacto entity)
        {
            _dbContext.Contactos.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
