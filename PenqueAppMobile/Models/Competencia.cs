using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class Competencia
    {
        public int Id { get; set; }
        public Tipo_Area Area { get; set; }
        public DateTime fecha_competencia { get; set; }
        public string nombre { get; set; }
        public int topeParticipantes { get; set; }
        public bool estado { get; set; }
    }
}
