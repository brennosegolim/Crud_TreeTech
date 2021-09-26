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
    public partial class frmCadastroClassificacaoAlarme : System.Web.UI.Page
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

        protected async void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            string msg = string.Empty;
            string acao = HiddenAcao.Value;
            string nome = txtNomeClassificacaoAlarme.Value;
            bool enviarEmail = chxEnviarEmail.Checked;
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
                    ClassificacaoAlarmesModel classificacaoAlarmes = new ClassificacaoAlarmesModel()
                    {
                        NomeClassificacaoAlarme = nome,
                        EnviarEmail = enviarEmail,
                        Observacao = observacao
                    };

                    ClassificacaoAlarmesRequest classificacaoRequest = new ClassificacaoAlarmesRequest();
                    aux = await classificacaoRequest.CadastroClassificacaoAlarme(classificacaoAlarmes);

                    limparCampos();
                    atualizarGrid();
                    AlertaSucesso("Registro cadastrado com sucesso!");
                }
                else if (acao.Equals("Atualizar"))
                {
                    ClassificacaoAlarmesModel classificacaoAlarmes = new ClassificacaoAlarmesModel()
                    {
                        IdClassificacaoAlarme = Int32.Parse(ViewState["IdClassificacaoAlarme"].ToString()),
                        NomeClassificacaoAlarme = nome,
                        EnviarEmail = enviarEmail,
                        Observacao = observacao
                    };

                    ClassificacaoAlarmesRequest classificacaoRequest = new ClassificacaoAlarmesRequest();
                    aux = await classificacaoRequest.AtualizarClassificacaoAlarme(classificacaoAlarmes);

                    limparCampos();
                    atualizarGrid();
                    AlertaSucesso("Registro atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                alerta("Problema ao adicionar/atualizar o registro! \n" + msg, ex.Message);
            }
            finally
            {
                habilitarBotao(true);
            }
        }

        protected async void btnDeletar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            int idClassificacaoAlarme = Convert.ToInt32((sender as LinkButton).CommandArgument);

            msgEsconder();
            habilitarBotao(false);

            try
            {
                ClassificacaoAlarmesModel classificacaoAlarmes = new ClassificacaoAlarmesModel()
                {
                    IdClassificacaoAlarme = idClassificacaoAlarme
                };

                ClassificacaoAlarmesRequest classificacaoAlarmesRequest = new ClassificacaoAlarmesRequest();
                aux = await classificacaoAlarmesRequest.DeletarClassificacaoAlarme(classificacaoAlarmes);

                atualizarGrid();
                alerta("Registro deletado com sucesso!");
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
                int idClassificacaoAlarme = Convert.ToInt32((sender as LinkButton).CommandArgument);
                ViewState.Add("IdClassificacaoAlarme", idClassificacaoAlarme);
                //Declarando Modelo para receber resultado da consulta da API
                ClassificacaoAlarmesModel classificacaoAlarmesModel = new ClassificacaoAlarmesModel();

                //Recebendo Lista de Tipos de Equipamento
                Task<ClassificacaoAlarmesModel> t1 = Task<ClassificacaoAlarmesModel>.Factory.StartNew((() =>
                    new ClassificacaoAlarmesRequest().ListarUmClassificacaoAlarme(idClassificacaoAlarme).Result));

                classificacaoAlarmesModel = t1.Result;

                txtNomeClassificacaoAlarme.Value = classificacaoAlarmesModel.NomeClassificacaoAlarme;
                chxEnviarEmail.Checked = classificacaoAlarmesModel.EnviarEmail;
                txtObservacao.Value = classificacaoAlarmesModel.Observacao;
                HiddenAcao.Value = "Atualizar";
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregar os registros!", ex.Message);
            }
            finally
            {
                habilitarBotao(false);
            }
        }

        protected void grdClassificacaoAlarme_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClassificacaoAlarme.PageIndex = e.NewPageIndex;
            atualizarGrid();
        }

        protected void limparCampos()
        {
            txtNomeClassificacaoAlarme.Value = "";
            chxEnviarEmail.Checked = false;
            txtObservacao.Value = "";
            HiddenAcao.Value = "Cadastrar";
            ViewState.Remove("IdClassificacaoAlarme");
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

        private void atualizarGrid()
        {
            try
            {
                //Declarando Modelo para receber resultado da consulta da API
                List<ClassificacaoAlarmesModel> classificacaoAlarmesModel;

                //Recebendo Lista de Tipos de Equipamento
                Task<List<ClassificacaoAlarmesModel>> t1 = Task<List<ClassificacaoAlarmesModel>>.Factory.StartNew((() =>
                    new ClassificacaoAlarmesRequest().ListarTodosClassificacaoAlarme().Result));

                classificacaoAlarmesModel = t1.Result;

                //Setando na Grid os valores recebidos
                grdClassificacaoAlarme.DataSource = classificacaoAlarmesModel;
                grdClassificacaoAlarme.DataBind();
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregador dados da grade.", ex.Message);
            }
        }

        private void habilitarBotao(bool ativo)
        {
            btnConfirmar.Enabled = ativo;
        }

        protected void grdClassificacaoAlarme_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text.Equals("True"))
                    e.Row.Cells[2].Text = "Sim";
                else
                    e.Row.Cells[2].Text = "Não";
            }
        }
    }
}