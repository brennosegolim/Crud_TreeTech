using Crud_TreeTech_Web2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Crud_TreeTech_Web2.Request
{
    public class AlarmesRequest
    {
        private readonly string urlApi = new Base().getAPIUrl();

        public async Task<List<AlarmesModel>> ListarTodosAlarme()
        {
            List<AlarmesModel> alarmesModel = new List<AlarmesModel>();
            string URI = urlApi + "v1/Alarme/ListarTodos";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        alarmesModel = JsonConvert.DeserializeObject<List<AlarmesModel>>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o alarme : " + response.StatusCode);
                    }
                }
                client.Dispose();
            }
            return alarmesModel;
        }

        public async Task<List<AlarmesModel>> ListarTodosAlarmeOrdenado(string coluna)
        {
            List<AlarmesModel> alarmesModel = new List<AlarmesModel>();
            string URI = urlApi + string.Format("v1/Alarme/ListarTodosOrdenado?coluna={0}",coluna);
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        alarmesModel = JsonConvert.DeserializeObject<List<AlarmesModel>>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o alarme : " + response.StatusCode);
                    }
                }
                client.Dispose();
            }
            return alarmesModel;
        }

        public async Task<List<AlarmesModel>> ListarTodosAlarmeOrdenado(string coluna,string filtro)
        {
            List<AlarmesModel> alarmesModel = new List<AlarmesModel>();
            string URI = urlApi + string.Format("v1/Alarme/ListarTodosPequisa?coluna={0}&filtro={1}", coluna, filtro);
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        alarmesModel = JsonConvert.DeserializeObject<List<AlarmesModel>>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o alarme : " + response.StatusCode);
                    }
                }
                client.Dispose();
            }
            return alarmesModel;
        }

        public async Task<AlarmesModel> ListarUmAlarme(int idAlarme)
        {
            AlarmesModel alarmesModel = new AlarmesModel();
            string URI = urlApi + string.Format("v1/Alarme/ListarUm?idAlarme={0}", idAlarme);
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        alarmesModel = JsonConvert.DeserializeObject<AlarmesModel>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o alarme : " + response.StatusCode);
                    }
                }
                client.Dispose();
            }
            return alarmesModel;
        }

        public async Task<bool> CadastroAlarme(AlarmesModel alarme)
        {
            bool retorno = false;

            string URI = urlApi + "v1/Alarme/Cadastrar";
            using (var client = new HttpClient())
            {
                var serializedAlarme = JsonConvert.SerializeObject(alarme);
                var content = new StringContent(serializedAlarme, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<bool> AtualizarAlarme(AlarmesModel alarme)
        {
            bool retorno = false;

            string URI = urlApi + "v1/Alarme/Atualizar";
            using (var client = new HttpClient())
            {
                var serializedAlarme = JsonConvert.SerializeObject(alarme);
                var content = new StringContent(serializedAlarme, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<bool> DeletarAlarme(AlarmesModel alarme)
        {
            bool retorno = false;

            string URI = urlApi + "v1/Alarme/Deletar";
            using (var client = new HttpClient())
            {
                var serializedAlarme = JsonConvert.SerializeObject(alarme);
                var content = new StringContent(serializedAlarme, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }
    }
}