using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class Participante
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Tipo_Area Area { get; set; }
    }
}
