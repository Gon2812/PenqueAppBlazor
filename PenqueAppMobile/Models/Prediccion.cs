using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public enum Tipo_Resultado
    {
        Local,
        Visitante,
        Empate,
        Indefinido
    }
    public class Prediccion
    {
        public int idPartido { get; set; }

        public int idUsuario { get; set; }

        public int idPenca { get; set; }

        public Tipo_Resultado tipo { get; set; }
    }
}
