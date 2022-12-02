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
        public static Penca PencaDetail { get; set; }
        //public static PencaCompartida PencaCompartidaDetail { get; set; }
        //public static PencaEmpresa PencaEmpresaDetail { get; set; }
        public static Partido PartidoDetail { get; set; }
        public static Competencia CompetenciaDetail { get; set; }
        public static Liga_Equipo LigaEquipoDetail { get; set; }
        public static Liga_Individual LigaIndividualDetail { get; set; }
        public static Mensaje casillaIndividual { get; set; }

        public static Competencia competencia { get; set; }
        //public const string BaseUrl = "https://penqueapp-backend.azurewebsites.net";
        public const string BaseUrl = "https://localhost:7210";
    }
}
