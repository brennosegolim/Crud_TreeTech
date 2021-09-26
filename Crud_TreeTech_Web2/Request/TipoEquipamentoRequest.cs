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
    public class TipoEquipamentoRequest
    {
        private readonly string urlApi = new Base().getAPIUrl();

        public async Task<List<TipoEquipamentoModel>> ListarTodosTipoEquipamento()
        {
            List<TipoEquipamentoModel> tipoEquipamentoModel = new List<TipoEquipamentoModel>();
            string URI = urlApi + "v1/TipoEquipamento/ListarTodos";
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        tipoEquipamentoModel = JsonConvert.DeserializeObject<List<TipoEquipamentoModel>>(JsonString);
                    }
                    else
                    {
                        msgErro = "Não foi possível obter o tipo de equipamento : " + response.StatusCode;
                    }
                }
                client.Dispose();
            }
            return tipoEquipamentoModel;
        }

        public async Task<TipoEquipamentoModel> ListarUmTipoEquipamento(int idTipoEquipamento)
        {
            TipoEquipamentoModel tipoEquipamentoModel = new TipoEquipamentoModel();
            string URI = urlApi + string.Format("v1/TipoEquipamento/ListarUm?idTipoEquipamento={0}",idTipoEquipamento);
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        tipoEquipamentoModel = JsonConvert.DeserializeObject<TipoEquipamentoModel>(JsonString);
                    }
                    else
                    {
                        msgErro = "Não foi possível obter o tipo de equipamento : " + response.StatusCode;
                    }
                }
                client.Dispose();
            }
            return tipoEquipamentoModel;
        }

        public async Task<bool> CadastroTipoEquipamento(TipoEquipamentoModel tipoEquipamento)
        {
            bool retorno = false;

            string URI = urlApi + "v1/TipoEquipamento/Cadastrar";
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                var serializedTipoEquipamento = JsonConvert.SerializeObject(tipoEquipamento);
                var content = new StringContent(serializedTipoEquipamento, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<bool> AtualizarTipoEquipamento(TipoEquipamentoModel tipoEquipamento)
        {
            bool retorno = false;

            string URI = urlApi + "v1/TipoEquipamento/Atualizar";
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                var serializedTipoEquipamento = JsonConvert.SerializeObject(tipoEquipamento);
                var content = new StringContent(serializedTipoEquipamento, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }

        public async Task<bool> DeletarTipoEquipamento(TipoEquipamentoModel tipoEquipamento)
        {
            bool retorno = false;

            string URI = urlApi + "v1/TipoEquipamento/Deletar";
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                var serializedTipoEquipamento = JsonConvert.SerializeObject(tipoEquipamento);
                var content = new StringContent(serializedTipoEquipamento, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                client.Dispose();
            }

            return retorno;
        }
    }
}