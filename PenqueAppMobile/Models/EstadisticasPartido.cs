using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class EstadisticasPartido
    {
        int id { get; set; }
        public int local { get; set; }
        public int visitante { get; set; }
        public int empate { get; set; }
    }
}
