namespace PenqueAppMobile.Models
{
    public class Liga_Equipo
    {
        public int Id { get; set; }
        public string NombreLiga { get; set; }
        public int Tope { get; set; }
        public Tipo_Deporte Tipo_Deporte { get; set; }
    }
}