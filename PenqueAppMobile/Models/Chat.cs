using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class Chat
    {
        public int id { get; set; }
        public int idusuario { get; set; }
        public int idempresa { get; set; }
        public string usuario { get; set; }
        public string empresa { get; set; }
    }
}
