using Lourtec.ContactoMVC.DAL.Contracts;
using Lourtec.ContactoMVC.Logic.Contracts;
using Lourtec.ContactoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lourtec.ContactoMVC.Logic.Service
{
    public class ContactoService : IContactoService
    {
        private readonly IGenericRepository<Contacto> _contactoService;
        public ContactoService(IGenericRepository<Contacto> contactoService)
        {
            _contactoService = contactoService;
        }
        public async Task<bool> Create(Contacto contacto)
        {
            return await _contactoService.Create(contacto);
        }

        public async Task<bool> Delete(int id)
        {
            return await _contactoService.Delete(id);
        }

        public async Task<Contacto> Get(int id)
        {
            return await _contactoService.Get(id);
        }

        public async Task<IQueryable<Contacto>> GetAll()
        {
            return await _contactoService.GetAll();
        }

        public async Task<Contacto> GetName(string name)
        {
            IQueryable<Contacto> queryContactSQL = await _contactoService.GetAll();
            Contacto contacto = queryContactSQL.Where(c => c.Nombre == name).FirstOrDefault();
            return contacto;
        }

        public async Task<bool> Update(Contacto contacto)
        {
            return await _contactoService.Update(contacto);
        }
    }
}
