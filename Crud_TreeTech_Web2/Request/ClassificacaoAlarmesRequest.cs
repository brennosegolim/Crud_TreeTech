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
    public class ClassificacaoAlarmesRequest
    {
        private readonly string urlApi = new Base().getAPIUrl();

        public async Task<List<ClassificacaoAlarmesModel>> ListarTodosClassificacaoAlarme()
        {
            List<ClassificacaoAlarmesModel> classificacaoAlarmeModel = new List<ClassificacaoAlarmesModel>();
            string URI = urlApi + "v1/ClassificacaoAlarme/ListarTodos";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        classificacaoAlarmeModel = JsonConvert.DeserializeObject<List<ClassificacaoAlarmesModel>>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter a classificação de alarme : " + response.StatusCode);
                    }
                }
                client.Dispose();
            }
            return classificacaoAlarmeModel;
        }

        public async Task<ClassificacaoAlarmesModel> ListarUmClassificacaoAlarme(int idClassificacaoAlarme)
        {
            ClassificacaoAlarmesModel classificacaoAlarmesModel = new ClassificacaoAlarmesModel();
            string URI = urlApi + string.Format("v1/ClassificacaoAlarme/ListarUm?idClassificacaoAlarme={0}", idClassificacaoAlarme);
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        classificacaoAlarmesModel = JsonConvert.DeserializeObject<ClassificacaoAlarmesModel>(JsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter a classificação de alarme : " + response.StatusCode);
                    }
                }
                client.Dispose();
            }
            return classificacaoAlarmesModel;
        }

        public async Task<bool> CadastroClassificacaoAlarme(ClassificacaoAlarmesModel classificacaoAlarmes)
        {
            bool retorno = false;

            string URI = urlApi + "v1/ClassificacaoAlarme/Cadastrar";
            using (var client = new HttpClient())
            {
                var serializedClassificacaoAlarme = JsonConvert.SerializeObject(classificacaoAlarmes);
                var content = new StringContent(serializedClassificacaoAlarme, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<bool> AtualizarClassificacaoAlarme(ClassificacaoAlarmesModel classificacaoAlarmes)
        {
            bool retorno = false;

            string URI = urlApi + "v1/ClassificacaoAlarme/Atualizar";
            using (var client = new HttpClient())
            {
                var serializedClassificacaoAlarme = JsonConvert.SerializeObject(classificacaoAlarmes);
                var content = new StringContent(serializedClassificacaoAlarme, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<bool> DeletarClassificacaoAlarme(ClassificacaoAlarmesModel classificacaoAlarmes)
        {
            bool retorno = false;

            string URI = urlApi + "v1/ClassificacaoAlarme/Deletar";
            using (var client = new HttpClient())
            {
                var serializedClassificacaoAlarme = JsonConvert.SerializeObject(classificacaoAlarmes);
                var content = new StringContent(serializedClassificacaoAlarme, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }
    }
}