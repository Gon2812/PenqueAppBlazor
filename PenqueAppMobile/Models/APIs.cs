using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class APIs
    {
        public const string AuthenticateUser = "/api/Usuario/login";
        public const string RegisterUser = "/api/Usuario/Registro";
        public const string ListarPencas = "/api/Penca";
        public const string ListarPencasUsuario = "/api/Usuario/misPencas/";
        public const string SeleccionarPenca = "/api/Penca/";
        public const string VerLigas = "/api/Penca/getIdLiga/";
        public const string verPartidos = "/api/LigaEquipo/getPartidos/";
        public const string verCompetencias = "/api/LigaIndividual/mostrarCompetencias/";
        public const string verListaMensajes = "/api/Usuario/mostrarChats?idUsuario=";
        public const string verCasillaPersonal = "/api/Usuario/mostrarMensajes?idChat=";
        public const string enviarMensaje = "/api/Usuario/enviarMensaje";
        public const string verDashboard = "/api/Penca/ListarPosiciones/";
        
    }
}
