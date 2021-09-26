using Crud_TreeTech_Web2.Model;
using Crud_TreeTech_Web2.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crud_TreeTech_Web2.Views
{
    public partial class frmCadastroEquipamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                msgEsconder();
                atualizarGrid();
                carregarTipoEquipamento();
                HiddenAcao.Value = "Cadastrar";
            }
        }

        protected async void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            string msg = string.Empty;
            string acao = HiddenAcao.Value;
            string nome = txtNomeEquipamento.Value;
            string numeroSerie = txtNumeroSerie.Value;
            string idTipoEquipamento = cbTipoEquipamento.SelectedValue;

            msgEsconder();
            habilitarBotao(false);

            try
            {
                if (nome.Equals(""))
                    msg += "Informe o nome do equipamento!\n";
                
                if (numeroSerie.Equals(""))
                    msg += "Informe o número de série do equipamento!\n";

                if (idTipoEquipamento.Equals(""))
                    msg += "Selecion o tipo de equipamento";

                if (!msg.Equals(""))
                {
                    throw new Exception("Falta de parâmetros");
                }

                if (acao.Equals("Cadastrar"))
                {
                    EquipamentosModel equipamento = new EquipamentosModel()
                    {
                        NomeEquipamento = nome,
                        NumeroSerie = Int32.Parse(numeroSerie),
                        IdTipoEquipamento = Int32.Parse(idTipoEquipamento),
                        DataCadastro = DateTime.Now
                    };

                    EquipamentosRequest equipamentoRequest = new EquipamentosRequest();
                    aux = await equipamentoRequest.CadastroEquipamento(equipamento);

                    limparCampos();
                    atualizarGrid();
                    AlertaSucesso("Registro cadastrado com sucesso!");
                }
                else if (acao.Equals("Atualizar"))
                {
                    EquipamentosModel equipamento = new EquipamentosModel()
                    {
                        IdEquipamento = Int32.Parse(ViewState["IdEquipamento"].ToString()),
                        NomeEquipamento = nome,
                        NumeroSerie = Int32.Parse(numeroSerie),
                        IdTipoEquipamento = Int32.Parse(idTipoEquipamento)
                    };

                    EquipamentosRequest equipamentoRequest = new EquipamentosRequest();
                    aux = await equipamentoRequest.AtualizarEquipamento(equipamento);

                    limparCampos();
                    atualizarGrid();
                    AlertaSucesso("Registro atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                alerta("Problema ao adicionar/atualizar o registro!\n" + msg, ex.Message);
            }
            finally
            {
                habilitarBotao(true);
            }
        }

        protected void grdEquipamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEquipamento.PageIndex = e.NewPageIndex;
            atualizarGrid();
        }

        protected async void btnDeletar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            int idEquipamento = Convert.ToInt32((sender as LinkButton).CommandArgument);

            msgEsconder();
            habilitarBotao(false);

            try
            {
                EquipamentosModel equipamento = new EquipamentosModel()
                {
                    IdEquipamento = idEquipamento
                };

                EquipamentosRequest equipamentoRequest = new EquipamentosRequest();
                aux = await equipamentoRequest.DeletarEquipamento(equipamento);

                atualizarGrid();
                AlertaSucesso("Registro deletado com sucesso!");
            }
            catch (Exception ex)
            {
                alerta("Problema ao deletar o registro.", ex.Message);
            }
            finally
            {
                habilitarBotao(true);
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {

            msgEsconder();
            habilitarBotao(false);

            try
            {
                //Recuperando o ID.
                int idEquipamento = Convert.ToInt32((sender as LinkButton).CommandArgument);
                ViewState.Add("IdEquipamento", idEquipamento);
                //Declarando Modelo para receber resultado da consulta da API
                EquipamentosModel equipamentoModel = new EquipamentosModel();

                //Recebendo Lista de Equipamento
                Task<EquipamentosModel> t1 = Task<EquipamentosModel>.Factory.StartNew((() =>
                    new EquipamentosRequest().ListarUmEquipamento(idEquipamento).Result));

                equipamentoModel = t1.Result;

                txtNomeEquipamento.Value = equipamentoModel.NomeEquipamento;
                txtNumeroSerie.Value = equipamentoModel.NumeroSerie.ToString();
                cbTipoEquipamento.SelectedValue = equipamentoModel.IdTipoEquipamento.ToString();
                HiddenAcao.Value = "Atualizar";
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregar os registros!", ex.Message);
            }
            finally
            {
                habilitarBotao(true);
            }
        }

        private void carregarTipoEquipamento()
        {
            try
            {
                cbTipoEquipamento.Items.Add(new ListItem("Selecione o Tipo de Equipamento", ""));

                //Declarando Modelo para receber resultado da consulta da API
                List<TipoEquipamentoModel> tipoEquipamentosModel;

                //Recebendo Lista de Tipos de Equipamento
                Task<List<TipoEquipamentoModel>> t1 = Task<List<TipoEquipamentoModel>>.Factory.StartNew((() =>
                    new TipoEquipamentoRequest().ListarTodosTipoEquipamento().Result));

                tipoEquipamentosModel = t1.Result;

                for (int i = 0; i < tipoEquipamentosModel.Count; i++)
                {
                    cbTipoEquipamento.Items.Add(new ListItem(tipoEquipamentosModel[i].NomeTipoEquipamento, tipoEquipamentosModel[i].IdTipoEquipamento.ToString()));
                }
            }
            catch (Exception ex)
            {
                alerta("Problema em carregar os tipos de Equipamento!",ex.Message);
            }
        }

        private void atualizarGrid()
        {
            try
            {
                //Declarando Modelo para receber resultado da consulta da API
                List<EquipamentosModel> equipamentoModel;

                //Recebendo Lista Equipamentos
                Task<List<EquipamentosModel>> t1 = Task<List<EquipamentosModel>>.Factory.StartNew((() =>
                    new EquipamentosRequest().ListarTodosEquipamento().Result));

                equipamentoModel = t1.Result;

                for(int i = 0; i < equipamentoModel.Count; i++)
                {
                    Task<TipoEquipamentoModel> t2 = Task<TipoEquipamentoModel>.Factory.StartNew((() =>
                    new TipoEquipamentoRequest().ListarUmTipoEquipamento(equipamentoModel[i].IdTipoEquipamento).Result));

                    equipamentoModel[i].NomeTipoEquipamento = t2.Result.NomeTipoEquipamento;
                }

                //Setando na Grid os valores recebidos
                grdEquipamento.DataSource = equipamentoModel;
                grdEquipamento.DataBind();
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregar registros da grade!",ex.Message);
            }
        }

        protected void alerta(string mensagem)
        {
            if (!mensagem.Equals(""))
            {
                dvAlerta.InnerText = mensagem;
                dvAlerta.Visible = true;
                dvPanels.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "function", string.Format("esconderMsg();"), true);
            }
        }

        protected void alerta(string mensagem, string erro)
        {
            if (!mensagem.Equals(""))
            {
                dvAlerta.InnerText = mensagem;
                dvAlerta.Visible = true;
                dvPanels.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "consoleLog", string.Format("console.log('Erro: {0}')", erro), true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "function", string.Format("esconderMsg();"), true);
            }
        }

        protected void AlertaSucesso(string mensagem)
        {
            if (!mensagem.Equals(""))
            {
                dvSucesso.InnerText = mensagem;
                dvSucesso.Visible = true;
                dvPanels.Visible = true;
            }
        }

        private void limparCampos()
        {
            txtNomeEquipamento.Value = "";
            txtNumeroSerie.Value = "";
            cbTipoEquipamento.SelectedValue = "";
        }

        private void msgEsconder()
        {
            dvPanels.Visible = false;
            dvAlerta.Visible = false;
            dvSucesso.Visible = false;

            dvAlerta.InnerText = "";
            dvSucesso.InnerText = "";
        }

        private void habilitarBotao(bool ativo)
        {
            btnConfirmar.Enabled = ativo;
        }
    }
}