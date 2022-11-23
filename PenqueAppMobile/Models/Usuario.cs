using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public float billetera { get; set; }
        public int tipo_rol { get; set; }
    }
}
