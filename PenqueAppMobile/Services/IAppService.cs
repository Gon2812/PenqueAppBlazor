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
        public Task<PencaCompartida> SeleccionarPencaC(int id);
        public Task<PencaEmpresa> SeleccionarPencaE(int id);
        public Task<int> verLiga(int id);
        public Task<List<Partido>> ListaPartidos(int idLiga);
        public Task<List<Competencia>> ListaCompetencias(int idLiga);
        public Task<List<Chat>> miBuzonMensajes(int id);
        public Task<List<Mensaje>> casillaIndividualMensajes(int id);
        public Task<List<DtPuntaje>> getPosiciones(int id);
        Task<(bool IsSuccess, string ErrorMessage)> EnviarMensaje(DtEnviar DtE);
    }
}
