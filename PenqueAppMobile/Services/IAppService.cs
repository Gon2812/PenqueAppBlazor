using PenqueAppMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Services
{
    public interface IAppService
    {
        public Task<Usuario> AuthenticateUser(LoginModel loginModel);
        Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser);
        public Task<List<PencaCompartida>> ListaPencasCompartidas();
        public Task<List<Penca>> ListaPencasUsuario(int idUsu);
        public Task<Penca> SeleccionarPenca(int id);
        public Task<PencaCompartida> SeleccionarPencaC(int id);
        public Task<PencaEmpresa> SeleccionarPencaE(int id);
        public Task<int> verLiga(int id);
        public Task<List<Partido>> ListaPartidos(int idLiga);
        public Task<List<Competencia>> ListaCompetencias(int idLiga);
        public Task<List<Chat>> miBuzonMensajes(int id);
        public Task<List<Mensaje>> casillaIndividualMensajes(int id);
        public Task<List<DtPuntaje>> getPosiciones(int id);

        public Task<List<Participante>> ListaParticipantes(int id);
        Task<(bool IsSuccess, string ErrorMessage)> EnviarMensaje(DtEnviar DtE);
        public Task<string> verMiApuesta(int idCompetencia, int idUser, int idPenca);
        Task<(bool IsSuccess, string ErrorMessage)> ApostarCompetencia(Apuesta apuesta);
        public Task<List<DtResultadoC>> resultadoCompetencia(int id);
        public Task<Partido> SeleccionarPartido(int idPartido);
        public Task<Competencia> SeleccionarCompetencia(int idComptencia);
        public Task<Liga_Equipo> SeleccionarLigaE(int id);
        public Task<Liga_Individual> SeleccionarLigaI(int id);
        public Task<Prediccion> PredecirPartido(Prediccion prediccion);
        public Task<int> PrediccionPartidoU(int idPartido, int idUsuario, int idPenca);
    }
}
