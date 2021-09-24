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
    public class EquipamentosRequest
    {
        private readonly string urlApi = new Base().getAPIUrl();

        public async Task<List<EquipamentosModel>> ListarTodosEquipamento()
        {
            List<EquipamentosModel> equipamentoModel = new List<EquipamentosModel>();
            string URI = urlApi + "v1/Equipamentos/ListarTodos";
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        equipamentoModel = JsonConvert.DeserializeObject<List<EquipamentosModel>>(JsonString);
                    }
                    else
                    {
                        msgErro = "Não foi possível obter o tipo de equipamento : " + response.StatusCode;
                    }
                }
            }
            return equipamentoModel;
        }

        public async Task<EquipamentosModel> ListarUmEquipamento(int idEquipamento)
        {
            EquipamentosModel equipamentoModel = new EquipamentosModel();
            string URI = urlApi + string.Format("v1/Equipamento/ListarUm?idEquipamento={0}", idEquipamento);
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        equipamentoModel = JsonConvert.DeserializeObject<EquipamentosModel>(JsonString);
                    }
                    else
                    {
                        msgErro = "Não foi possível obter o equipamento : " + response.StatusCode;
                    }
                }
            }
            return equipamentoModel;
        }

        public async Task<bool> CadastroEquipamento(EquipamentosModel equipamento)
        {
            bool retorno = false;

            string URI = urlApi + "v1/Equipamentos/Cadastrar";
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                var serializedEquipamento = JsonConvert.SerializeObject(equipamento);
                var content = new StringContent(serializedEquipamento, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
            }
            return retorno;
        }

        public async Task<bool> AtualizarEquipamento(EquipamentosModel equipamento)
        {
            bool retorno = false;

            string URI = urlApi + "v1/Equipamentos/Atualizar";
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                var serializedEquipamento = JsonConvert.SerializeObject(equipamento);
                var content = new StringContent(serializedEquipamento, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
            }
            return retorno;
        }

        public async Task<bool> DeletarEquipamento(EquipamentosModel equipamento)
        {
            bool retorno = false;

            string URI = urlApi + "v1/Equipamentos/Deletar";
            string msgErro = string.Empty;
            using (var client = new HttpClient())
            {
                var serializedEquipamento = JsonConvert.SerializeObject(equipamento);
                var content = new StringContent(serializedEquipamento, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
            }

            return retorno;
        }
    }
}