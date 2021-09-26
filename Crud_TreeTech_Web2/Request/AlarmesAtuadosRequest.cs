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
    public class AlarmesAtuadosRequest
    {
        private readonly string urlApi = new Base().getAPIUrl();

        public async Task<List<AlarmesAtuadosModel>> ListarTodosAlarmeAtuados()
        {
            List<AlarmesAtuadosModel> alarmesAtuadosModels = new List<AlarmesAtuadosModel>();
            string URI = urlApi + "v1/AlarmeAtuado/ListarTodos";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        alarmesAtuadosModels = JsonConvert.DeserializeObject<List<AlarmesAtuadosModel>>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter os alarmes atuados: " + response.StatusCode);
                    }
                    response.Dispose();
                }
                client.Dispose();
            }
            return alarmesAtuadosModels;
        }

        public async Task<AlarmesAtuadosModel> ListarUmAlarmeAtuado(int idAlarmeAtuado)
        {
            AlarmesAtuadosModel alarmesAtuadosModel = new AlarmesAtuadosModel();
            string URI = urlApi + string.Format("v1/AlarmeAtuado/ListarUm?idAlarmeAtuado={0}", idAlarmeAtuado);
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        alarmesAtuadosModel = JsonConvert.DeserializeObject<AlarmesAtuadosModel>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o alarme atuado: " + response.StatusCode);
                    }
                    response.Dispose();
                }
                client.Dispose();
            }
            return alarmesAtuadosModel;
        }

        public async Task<bool> CadastroAlarmeAtuado(AlarmesAtuadosModel alarmeAtuado)
        {
            bool retorno = false;

            string URI = urlApi + "v1/AlarmeAtuado/Cadastrar";
            using (var client = new HttpClient())
            {
                var serializedAlarmeAtuado = JsonConvert.SerializeObject(alarmeAtuado);
                var content = new StringContent(serializedAlarmeAtuado, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<bool> AtualizarAlarmeAtuado(AlarmesAtuadosModel alarmeAtuado)
        {
            bool retorno = false;

            string URI = urlApi + "v1/AlarmeAtuado/Atualizar";
            using (var client = new HttpClient())
            {
                var serializedAlarmeAtuado = JsonConvert.SerializeObject(alarmeAtuado);
                var content = new StringContent(serializedAlarmeAtuado, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<bool> DeletarAlarmeAtuado(AlarmesAtuadosModel alarmeAtuado)
        {
            bool retorno = false;

            string URI = urlApi + "v1/AlarmeAtuado/Deletar";
            using (var client = new HttpClient())
            {
                var serializedAlarmeAtuado = JsonConvert.SerializeObject(alarmeAtuado);
                var content = new StringContent(serializedAlarmeAtuado, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<List<AlarmesAtuadosModel>> RankingAlarmeAtuados()
        {
            List<AlarmesAtuadosModel> alarmesAtuadosModels = new List<AlarmesAtuadosModel>();
            string URI = urlApi + "v1/AlarmeAtuado/RankingAlarmes";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        alarmesAtuadosModels = JsonConvert.DeserializeObject<List<AlarmesAtuadosModel>>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter os alarmes atuados: " + response.StatusCode);
                    }
                    response.Dispose();
                }
                client.Dispose();
            }
            return alarmesAtuadosModels;
        }
    }
}