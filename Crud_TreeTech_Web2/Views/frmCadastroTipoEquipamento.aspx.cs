using Crud_TreeTech_Web2.Model;
using Crud_TreeTech_Web2.Request;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crud_TreeTech_Web2.Views
{
    public partial class frmCadastroTipoEquipamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                msgEsconder();
                HiddenAcao.Value = "Cadastrar";
                atualizarGrid();
            }
        }

        private void atualizarGrid() 
        {
            try
            {
                //Declarando Modelo para receber resultado da consulta da API
                List<TipoEquipamentoModel> tipoEquipamentoModel;

                //Recebendo Lista de Tipos de Equipamento
                Task<List<TipoEquipamentoModel>> t1 = Task<List<TipoEquipamentoModel>>.Factory.StartNew((() =>
                    new TipoEquipamentoRequest().ListarTodosTipoEquipamento().Result));

                tipoEquipamentoModel = t1.Result;

                //Setando na Grid os valores recebidos
                grdTipoEquipamento.DataSource = tipoEquipamentoModel;
                grdTipoEquipamento.DataBind();
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregador dados da grade.",ex.Message);
            }
        }

        protected async void btnDeletar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            int idTipoEquipamento = Convert.ToInt32((sender as LinkButton).CommandArgument);

            msgEsconder();
            habilitarBotao(false);
            

            try
            {
                TipoEquipamentoModel tipoEquipamento = new TipoEquipamentoModel()
                {
                    IdTipoEquipamento = idTipoEquipamento
                };

                TipoEquipamentoRequest tipoEquipamentoRequest = new TipoEquipamentoRequest();
                aux = await tipoEquipamentoRequest.DeletarTipoEquipamento(tipoEquipamento);

                atualizarGrid();
                alerta("Registro deletado com sucesso!");
            }
            catch (Exception ex)
            {
                alerta("Problema ao deletar o registro.",ex.Message);
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
                int idTipoEquipamento = Convert.ToInt32((sender as LinkButton).CommandArgument);
                ViewState.Add("IdTipoEquipamento", idTipoEquipamento);
                //Declarando Modelo para receber resultado da consulta da API
                TipoEquipamentoModel tipoEquipamentoModel = new TipoEquipamentoModel();

                //Recebendo Lista de Tipos de Equipamento
                Task<TipoEquipamentoModel> t1 = Task<TipoEquipamentoModel>.Factory.StartNew((() =>
                    new TipoEquipamentoRequest().ListarUmTipoEquipamento(idTipoEquipamento).Result));

                tipoEquipamentoModel = t1.Result;

                txtNomeTipoEquipamento.Value = tipoEquipamentoModel.NomeTipoEquipamento;
                txtObservacao.Value = tipoEquipamentoModel.Observacao;
                HiddenAcao.Value = "Atualizar";
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregar os registros!",ex.Message);
            }
            finally
            {
                habilitarBotao(true);
            }
        }

        protected async void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            string msg = string.Empty;
            string acao = HiddenAcao.Value;
            string nome = txtNomeTipoEquipamento.Value;
            string observacao = txtObservacao.Value;

            msgEsconder();
            habilitarBotao(false);

            try
            {
                if (nome.Equals(""))
                {
                    msg = "Informe o nome do tipo de equipamento.";
                    throw new Exception("Informe o nome do tipo de equipamento!");
                }

                if (acao.Equals("Cadastrar"))
                {
                    TipoEquipamentoModel tipoEquipamento = new TipoEquipamentoModel()
                    {
                        NomeTipoEquipamento = nome,
                        Observacao = observacao
                    };

                    TipoEquipamentoRequest tipoEquipamentoRequest = new TipoEquipamentoRequest();
                    aux = await tipoEquipamentoRequest.CadastroTipoEquipamento(tipoEquipamento);

                    limparCampos();
                    atualizarGrid();
                    AlertaSucesso("Registro cadastrado com sucesso!");
                }
                else if (acao.Equals("Atualizar"))
                {
                    TipoEquipamentoModel tipoEquipamento = new TipoEquipamentoModel()
                    {
                        IdTipoEquipamento = Int32.Parse(ViewState["IdTipoEquipamento"].ToString()),
                        NomeTipoEquipamento = nome,
                        Observacao = observacao
                    };

                    TipoEquipamentoRequest tipoEquipamentoRequest = new TipoEquipamentoRequest();
                    aux = await tipoEquipamentoRequest.AtualizarTipoEquipamento(tipoEquipamento);

                    limparCampos();
                    atualizarGrid();
                    AlertaSucesso("Registro atualizado com sucesso!");
                }
            }
            catch (Exception ex) 
            {
                alerta("Problema ao adicionar/atualizar o registro! \n" + msg,ex.Message);
            }
            finally
            {
                habilitarBotao(true);
            }
        }

        protected void limparCampos()
        {
            txtNomeTipoEquipamento.Value = "";
            txtObservacao.Value = "";
            HiddenAcao.Value = "Cadastrar";
            ViewState.Remove("IdTipoEquipamento");
        }

        protected void grdTipoEquipamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTipoEquipamento.PageIndex = e.NewPageIndex;
            atualizarGrid();
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