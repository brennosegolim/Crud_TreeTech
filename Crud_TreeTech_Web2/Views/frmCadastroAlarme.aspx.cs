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
    public partial class frmCadastroAlarme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                msgEsconder();
                HiddenAcao.Value = "Cadastrar";
                carregarDropdown();
                atualizarGrid();
            }
        }

        protected async void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            string msg = string.Empty;
            string acao = HiddenAcao.Value;
            string nome = txtNomeAlarme.Value;
            string idClassificacaoAlarme = cbClassificacaoAlarme.SelectedValue;
            string idEquipamento = cbEquipamento.SelectedValue;

            msgEsconder();
            habilitarBotao(false);

            try
            {
                if (nome.Equals(""))
                    msg += "Informe o nome do alarme.\n";

                if (idClassificacaoAlarme.Equals(""))
                    msg += "Selecione a classificação do alarme.\n";

                if (idEquipamento.Equals(""))
                    msg += "Selecion o equipamento";

                if (!msg.Equals(""))
                {
                    throw new Exception("Falta de parâmetros");
                }

                if (acao.Equals("Cadastrar"))
                {
                    AlarmesModel alarmes = new AlarmesModel()
                    {
                        NomeAlarme = nome,
                        IdClassificacaoAlarme = Int32.Parse(idClassificacaoAlarme),
                        IdEquipamento = Int32.Parse(idEquipamento),
                        DataCadastro = DateTime.Now,
                        Status = false,
                    };

                    AlarmesRequest alarmesRequest = new AlarmesRequest();
                    aux = await alarmesRequest.CadastroAlarme(alarmes);

                    limparCampos();
                    atualizarGrid();
                    AlertaSucesso("Registro cadastrado com sucesso!");
                }
                else if (acao.Equals("Atualizar"))
                {
                    AlarmesModel alarmes = new AlarmesModel()
                    {
                        IdAlarme = Int32.Parse(ViewState["IdAlarme"].ToString()),
                        NomeAlarme = nome,
                        IdClassificacaoAlarme = Int32.Parse(idClassificacaoAlarme),
                        IdEquipamento = Int32.Parse(idEquipamento),
                        Status = Convert.ToBoolean(ViewState["Status"].ToString())
                    };

                    AlarmesRequest alarmesRequest = new AlarmesRequest();
                    aux = await alarmesRequest.AtualizarAlarme(alarmes);

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
            int idAlarme = Convert.ToInt32((sender as LinkButton).CommandArgument);

            msgEsconder();
            habilitarBotao(false);

            try
            {
                AlarmesModel alarmes = new AlarmesModel()
                {
                    IdAlarme = idAlarme
                };

                AlarmesRequest alarmesRequest = new AlarmesRequest();
                aux = await alarmesRequest.DeletarAlarme(alarmes);

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
                int idAlarme = Convert.ToInt32((sender as LinkButton).CommandArgument);
                ViewState.Add("IdAlarme", idAlarme);
                //Declarando Modelo para receber resultado da consulta da API
                AlarmesModel alarme = new AlarmesModel();

                //Recebendo Lista de Equipamento
                Task<AlarmesModel> t1 = Task<AlarmesModel>.Factory.StartNew((() =>
                    new AlarmesRequest().ListarUmAlarme(idAlarme).Result));

                alarme = t1.Result;

                txtNomeAlarme.Value = alarme.NomeAlarme;
                cbClassificacaoAlarme.SelectedValue = alarme.IdClassificacaoAlarme.ToString();
                cbEquipamento.SelectedValue = alarme.IdEquipamento.ToString();
                ViewState.Add("Status", alarme.Status);
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

        protected void limparCampos()
        {
            txtNomeAlarme.Value = "";
            cbClassificacaoAlarme.SelectedValue = "";
            cbEquipamento.SelectedValue = "";
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
                List<AlarmesModel> alarmesModel;

                //Recebendo Lista Equipamentos
                Task<List<AlarmesModel>> t1 = Task<List<AlarmesModel>>.Factory.StartNew((() =>
                    new AlarmesRequest().ListarTodosAlarme().Result));

                alarmesModel = t1.Result;

                for (int i = 0; i < alarmesModel.Count; i++)
                {
                    Task<EquipamentosModel> t2 = Task<EquipamentosModel>.Factory.StartNew((() =>
                    new EquipamentosRequest().ListarUmEquipamento(alarmesModel[i].IdEquipamento).Result));

                    Task<ClassificacaoAlarmesModel> t3 = Task<ClassificacaoAlarmesModel>.Factory.StartNew((() =>
                    new ClassificacaoAlarmesRequest().ListarUmClassificacaoAlarme(alarmesModel[i].IdClassificacaoAlarme).Result));

                    alarmesModel[i].NomeEquipamento = t2.Result.NomeEquipamento;
                    alarmesModel[i].NomeClassificacaoAlarme = t3.Result.NomeClassificacaoAlarme;
                }

                //Setando na Grid os valores recebidos
                grdAlarme.DataSource = alarmesModel;
                grdAlarme.DataBind();
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregar registros da grade!", ex.Message);
            }
        }

        private void habilitarBotao(bool ativo)
        {
            btnConfirmar.Enabled = ativo;
        }

        protected void grdAlarme_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAlarme.PageIndex = e.NewPageIndex;
            atualizarGrid();
        }

        private void carregarDropdown()
        {
            try
            {
                cbClassificacaoAlarme.Items.Add(new ListItem("Selecione a Classificação", ""));
                cbEquipamento.Items.Add(new ListItem("Selecione o Equipamento", ""));

                //Declarando Modelo para receber resultado da consulta da API
                List<ClassificacaoAlarmesModel> classificacaoAlarmesModel;
                List<EquipamentosModel> equipamentosModel;

                //Recebendo Lista de Equipamentos
                Task<List<ClassificacaoAlarmesModel>> t1 = Task<List<ClassificacaoAlarmesModel>>.Factory.StartNew((() =>
                    new ClassificacaoAlarmesRequest().ListarTodosClassificacaoAlarme().Result));

                Task<List<EquipamentosModel>> t2 = Task<List<EquipamentosModel>>.Factory.StartNew((() =>
                    new EquipamentosRequest().ListarTodosEquipamento().Result));

                classificacaoAlarmesModel = t1.Result;
                equipamentosModel = t2.Result;

                for (int i = 0; i < classificacaoAlarmesModel.Count; i++)
                {
                    cbClassificacaoAlarme.Items.Add(new ListItem(classificacaoAlarmesModel[i].NomeClassificacaoAlarme, classificacaoAlarmesModel[i].IdClassificacaoAlarme.ToString()));
                }

                for (int i = 0; i < equipamentosModel.Count; i++)
                {
                    cbEquipamento.Items.Add(new ListItem(equipamentosModel[i].NomeEquipamento, equipamentosModel[i].IdEquipamento.ToString()));
                }
            }
            catch (Exception ex)
            {
                alerta("Problema em carregar as caixas de seleção!", ex.Message);
            }
        }
    }
}