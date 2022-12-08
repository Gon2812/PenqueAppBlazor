using PenqueAppMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenqueAppMobile.Data;
using System.Text.Json;
//using AVFoundation;

namespace PenqueAppMobile.Services
{
    public class AppService : IAppService
    {
        public async Task<Usuario> AuthenticateUser(LoginModel loginModel)
        {
            var returnResponse = new Usuario();
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.AuthenticateUser}";

                var serializedStr = JsonConvert.SerializeObject(loginModel);

                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Usuario>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.RegisterUser}";

                var serializedStr = JsonConvert.SerializeObject(registerUser);
                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage = await response.Content.ReadAsStringAsync();
                }
            }
            return (isSuccess, errorMessage);
        }

        public async Task<List<PencaCompartida>> ListaPencasCompartidas()
        {
            var returnResponse = new List<PencaCompartida>();        
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.ListarPencas}";
                //var serializedStr = JsonConvert.SerializeObject();
                var response = await p.GetAsync(url);
                //var response = await p.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var pencas = JsonConvert.DeserializeObject<List<Penca>>(contentStr);
                    foreach (var aux in pencas)
                    {
                        if (aux.tipo_Penca.ToString().Equals("Compartida"))
                        {
                            var r = new PencaCompartida();
                            r.id = aux.id;
                            r.nombre = aux.nombre;
                            r.tipoDeporte = aux.tipo_Deporte;
                            r.entrada = aux.entrada;
                            r.pozo = aux.pozo;
                            r.tipo_Liga = aux.tipo_Liga;
                            r.estado = aux.estado;
                            returnResponse.Add(r);
                        }
                    }
                }
            }
            return returnResponse;
        }

        public async Task<List<Penca>> ListaPencasUsuario(int id)
        {
            var returnResponse = new List<Penca>();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.ListarPencasUsuario}{id}";
                //var serializedStr = JsonConvert.SerializeObject();
                var response = await p.GetAsync(url);
                //var response = await p.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var pencas = JsonConvert.DeserializeObject<List<Penca>>(contentStr);
                    foreach (var aux in pencas)
                    {
                        var r = new Penca();
                        r.id = aux.id;
                        r.nombre = aux.nombre;
                        r.estado = aux.estado;
                        r.fecha_Creacion = aux.fecha_Creacion;
                        r.tipo_Deporte = aux.tipo_Deporte;
                        r.tipo_Liga = aux.tipo_Liga;
                        r.tipo_Plan = aux.tipo_Plan;
                        r.entrada = aux.entrada;
                        r.pozo = aux.pozo;
                        r.color = aux.color;
                        r.tipoPenca= aux.tipoPenca;

                        returnResponse.Add(r);
                    }
                }
            }
            return returnResponse;
        }

        public async Task<Penca> SeleccionarPenca(int id)
        {
            var returnResponse = new Penca();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.SeleccionarPenca}{id}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Penca>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<PencaCompartida> SeleccionarPencaC(int id)
        {
            var returnResponse = new PencaCompartida();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.SeleccionarPenca}{id}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<PencaCompartida>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<PencaEmpresa> SeleccionarPencaE(int id)
        {
            var returnResponse = new PencaEmpresa();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.SeleccionarPenca}{id}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<PencaEmpresa>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<int> verLiga(int id)
        {
            var returnResponse = new int();
            using (var l = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.VerLigas}{id}";
                var response = await l.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<int>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<List<Partido>> ListaPartidos(int idLiga)
        {
            var returnResponse = new List<Partido>();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.verPartidos}{idLiga}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var partidos = JsonConvert.DeserializeObject<List<Partido>>(contentStr);
                    foreach (var aux in partidos)
                    {
                        returnResponse.Add(aux);
                    }
                }
            }
            return returnResponse;
        }

        public async Task<List<Competencia>> ListaCompetencias(int idLiga)
        {
            var returnResponse = new List<Competencia>();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.verCompetencias}{idLiga}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var competencias = JsonConvert.DeserializeObject<List<Competencia>>(contentStr);
                    foreach (var aux in competencias)
                    {
                        returnResponse.Add(aux);
                    }
                }
            }
            return returnResponse;
        }

        public async Task<List<Chat>> miBuzonMensajes(int id)
        {
            var returnResponse = new List<Chat>();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.verListaMensajes}{id}";
                //var serializedStr = JsonConvert.SerializeObject();
                var response = await p.GetAsync(url);
                //var response = await p.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var chats = JsonConvert.DeserializeObject<List<Chat>>(contentStr);
                    foreach (var aux in chats)
                    {
                        returnResponse.Add(aux);
                    }
                }
            }
            return returnResponse;
        }

        public async Task<List<Mensaje>> casillaIndividualMensajes(int id)
        {
            var returnResponse = new List<Mensaje>();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.verCasillaPersonal}{id}";
                //var serializedStr = JsonConvert.SerializeObject();
                var response = await p.GetAsync(url);
                //var response = await p.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var mensaje = JsonConvert.DeserializeObject<List<Mensaje>>(contentStr);
                    foreach (var aux in mensaje)
                    {
                        returnResponse.Add(aux);
                    }
                }
            }
            return returnResponse;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> EnviarMensaje(DtEnviar DtE)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.enviarMensaje}";

                var serializedStr = JsonConvert.SerializeObject(DtE);
                var response = await client.PutAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage = await response.Content.ReadAsStringAsync();
                }
            }
            return (isSuccess, errorMessage);
        }

        public async Task<List<DtPuntaje>> getPosiciones(int id)
        {
            var returnResponse = new List<DtPuntaje>();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.verDashboard}{id}";
                //var serializedStr = JsonConvert.SerializeObject();
                var response = await p.GetAsync(url);
                //var response = await p.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var puntos = JsonConvert.DeserializeObject<List<DtPuntaje>>(contentStr);
                    foreach (var aux in puntos)
                    {
                        returnResponse.Add(aux);
                    }
                }
            }
            return returnResponse;
        }

        public async Task<List<Participante>> ListaParticipantes(int id)
        {
            var returnResponse = new List<Participante>();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.getParticipantes}{id}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var participantes = JsonConvert.DeserializeObject<List<Participante>>(contentStr);
                    foreach (var aux in participantes)
                    {
                        returnResponse.Add(aux);
                    }
                }
            }
            return returnResponse;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> ApostarCompetencia(Apuesta apuesta)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.apostarParticipante}";

                var serializedStr = JsonConvert.SerializeObject(apuesta);
                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage = await response.Content.ReadAsStringAsync();
                }
            }
            return (isSuccess, errorMessage);
        }

        public async Task<string> verMiApuesta(int idCompetencia, int idUser, int idPenca)
        {
            var returnResponse = "";
            using (var l = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.verInfoApuesta}{idUser}{APIs.verInfoApuesta2}{idCompetencia}{APIs.verInfoApuesta3}{idPenca}";
                var response = await l.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = contentStr;
                }
            }
            return returnResponse;
        }

        public async Task<List<DtResultadoC>> resultadoCompetencia(int id)
        {
            var returnResponse = new List<DtResultadoC>();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.verResultadosCompetencia}{id}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    var participantes = JsonConvert.DeserializeObject<List<DtResultadoC>>(contentStr);
                    foreach (var aux in participantes)
                    {
                        returnResponse.Add(aux);
                    }
                }
            }
            return returnResponse;
        }

        public async Task<Partido> SeleccionarPartido(int idPartido)
        {
            var returnResponse = new Partido();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.SeleccionarPartido}{idPartido}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Partido>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<Competencia> SeleccionarCompetencia(int idComptencia)
        {
            var returnResponse = new Competencia();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.SeleccionarCompetencia}{idComptencia}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Competencia>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<Liga_Equipo> SeleccionarLigaE(int id)
        {
            var returnResponse = new Liga_Equipo();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.SeleccionarLigaEquipo}{id}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Liga_Equipo>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<Liga_Individual> SeleccionarLigaI(int id)
        {
            var returnResponse = new Liga_Individual();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.SeleccionarLigaIndividual}{id}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Liga_Individual>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<Prediccion> PredecirPartido(Prediccion prediccion)
        {
            var returnResponse = new Prediccion();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.PredecirPartido}";

                var serializedStr = JsonConvert.SerializeObject(prediccion);

                var response = await p.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Prediccion>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<int> PrediccionPartidoU(int idPartido, int idUsuario, int idPenca)
        {
            var returnResponse = new int();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.PrediccionPartUsu}{idUsuario}{APIs.PrediccionPartUsu2}{idPartido}{APIs.PrediccionPartUsu3}{idPenca}";
                var response = await p.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<int>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<EstadisticasPartido> Estadisticas(int idPartido)
        {
            var returnResponse = new EstadisticasPartido();
            using (var p = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.EstadisticasPartido}{idPartido}";
                var response = await p.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<EstadisticasPartido>(contentStr);
                }
            }
            return returnResponse;
        }
    }
}
