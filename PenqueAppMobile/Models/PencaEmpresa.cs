using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class PencaEmpresa
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Tipo_Deporte tipoDeporte { get; set; }
        public float? entrada { get; set; }
        public float? premioFinal { get; set; }
        public int idLiga { get; set; }
        public Tipo_Liga tipo_Liga { get; set; }
        public Tipo_Plan? tipo_Plan { get; set; }
        public int idEmpresa { get; set; }
    }
}
