using Lourtec.ContactoMVC.UI.Models.ViewModels;
using Lourtec.ContactoMVC.Logic.Contracts;
using Microsoft.AspNetCore.Mvc;
using Lourtec.ContactoMVC.Models;

namespace Lourtec.ContactoMVC.UI.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContactoService _contactoService;

        public ContactoController(IContactoService contactoService)
        {
            _contactoService = contactoService;
        }

        public async Task<IActionResult> Index(ContactoViewModel contactoViewModel)
        {
            IQueryable<Contacto> queryContactoSQL = await _contactoService.GetAll();
            List<ContactoViewModel> lstContactoViewModel = queryContactoSQL.Select(c => new ContactoViewModel() {
                IdContacto = c.IdContacto,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                FechaNacimiento = c.FechaNacimiento
                }).ToList();

            return View(lstContactoViewModel);
        }
        public async Task<IActionResult> Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactoViewModel contactoViewModel)
        {
            Contacto contacto = new Contacto()
            {
                Nombre = contactoViewModel.Nombre,
                Telefono = contactoViewModel.Telefono,
                FechaNacimiento = contactoViewModel.FechaNacimiento
            };
            if (ModelState.IsValid)
            {
                bool respuesta = await _contactoService.Create(contacto);
                return RedirectToAction("Index", "Contacto");
            }
            return View();
        }

        public async Task<IActionResult> Update(int id) 
        {
            Task<Contacto> _contacto = _contactoService.Get(id);
            ContactoViewModel contactoViewModel = new ContactoViewModel()
            {
                IdContacto = _contacto.Result.IdContacto,
                Nombre = _contacto.Result.Nombre,
                Telefono = _contacto.Result.Telefono,
                FechaNacimiento = _contacto.Result.FechaNacimiento,
            };
            return View(contactoViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ContactoViewModel contactoViewModel)
        {
            Contacto contacto = new Contacto() {
                IdContacto = contactoViewModel.IdContacto,
                Nombre = contactoViewModel.Nombre,
                Telefono = contactoViewModel.Telefono,
                FechaNacimiento = contactoViewModel.FechaNacimiento,
            };
            if (ModelState.IsValid)
            {
                bool resppuesta = await _contactoService.Update(contacto);
                return RedirectToAction("Index", "Contacto");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id) 
        {
            Task<Contacto> _contacto = _contactoService.Get(id);
            ContactoViewModel contactoViewModel = new ContactoViewModel()
            {
                IdContacto = _contacto.Result.IdContacto,
                Nombre = _contacto.Result.Nombre,
                Telefono = _contacto.Result.Telefono,
                FechaNacimiento = _contacto.Result.FechaNacimiento,
            };
            return View(contactoViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, ContactoViewModel contactoViewModel) 
        {
            bool respuesta = await _contactoService.Delete(id);
            return RedirectToAction("Index","Contacto");
        }
    }
}
