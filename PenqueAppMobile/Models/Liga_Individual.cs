namespace PenqueAppMobile.Models
{
    public enum Tipo_Area
    {
        Natacion,
        Ciclismo,
        Atletismo
    }
    public class Liga_Individual
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TopeCompetencias { get; set; }
        public Tipo_Area TipoArea { get; set; }
    }
}