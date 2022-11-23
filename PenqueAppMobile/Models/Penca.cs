using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public enum Tipo_Penca
    {
        Compartida,
        Empresa
    }

    public enum Tipo_Deporte
    {
        Futbol,
        Basquetball,
        Tenis,
        Voley,
        Competencia
    }

    public enum Tipo_Plan
    {
        Basico,
        Premium
    }
    public enum Tipo_Liga
    {
        Equipo,
        Individual
    }

    public class Penca
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public Tipo_Penca Tipo_Penca { get; set; }

        public Tipo_Deporte Tipo_Deporte { get; set; }

        public List<Mensaje> Foro { get; set; }

        //Empresa
        public float? Premio_empresa { get; set; }

        public Tipo_Plan? Tipo_Plan { get; set; }

        //Compartido
        public float? Entrada { get; set; }

        public float? Pozo { get; set; }

        //Relaciones
        public Liga_Equipo Liga_Equipo { get; set; }
        public Liga_Individual Liga_Individual { get; set; }

        public List<Puntuacion> Participantes_puntos { get; set; } // Aca guarda todas las puntuaciones de cada participante para luego ranquearlo y entregar el premio

        public Tipo_Liga Tipo_Liga { get; set; }

        public string Color { get; set; }

        public int EmpresaId { get; set; }

    }
}
