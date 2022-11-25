namespace PenqueAppMobile.Models
{
    public class Mensaje
    {
        public int id { get; set; }

        public string mensaje { get; set; }

        public string empresa { get; set; }
        public string usuario { get; set; }

        public int idEmpresa { get; set; }

        public int rol { get; set; }
    }
}