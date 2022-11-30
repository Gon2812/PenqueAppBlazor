using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class Apuesta
    {
        public int   idCompetencia { get; set; }
        public int idUsuario { get; set; }
        public int idPenca { get; set; }
        public int idParticipante { get; set; }
    }
}
