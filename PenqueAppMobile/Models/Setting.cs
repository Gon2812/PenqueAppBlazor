using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    internal class Setting
    {
        public static Usuario UserBasicDetail { get; set; }
        public static PencaCompartida PencaCompartidaDetail { get; set; }
        public static PencaEmpresa PencaEmpresaDetail { get; set; }
        public const string BaseUrl = "https://penqueapp-backend.azurewebsites.net";
    }
}
