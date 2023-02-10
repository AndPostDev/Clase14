namespace Lourtec.ContactoMVC.UI.Models.ViewModels
{
    public class ContactoViewModel
    {
        public int IdContacto { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        
        // No se toma fecha de registro porque la configuramos en la BD que se rellena 
        // automaticamente
    }
}
