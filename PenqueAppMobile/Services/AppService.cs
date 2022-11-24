using PenqueAppMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenqueAppMobile.Data;
using System.Text.Json;

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
                        if (aux.Tipo_Penca == 0)
                        {
                            var r = new PencaCompartida();
                            r.id = aux.Id;
                            r.nombre = aux.Nombre;
                            r.tipoDeporte = aux.Tipo_Deporte;
                            r.entrada = aux.Entrada;
                            r.pozo = aux.Pozo;
                            r.tipo_Liga = aux.Tipo_Liga;
                            r.estado = aux.Estado;
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
                        returnResponse.Add(aux);
                    }
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
    }
}
