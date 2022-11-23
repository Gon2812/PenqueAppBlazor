using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class Partido
    {
        public enum Tipo_Resultado
        {
            Local,
            Visitante,
            Empate,
            Indefinido
        }
        public int id { get; set; }
        public DateTime fecha { get; set; }

        public int Idlocal { get; set; }

        public int Idvisitante { get; set; }

        public string local { get; set; }

        public string visitante { get; set; }

        public Tipo_Resultado resultado { get; set; }

        public Tipo_Deporte deporte { get; set; }
    }
}
