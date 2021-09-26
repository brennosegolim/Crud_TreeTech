using Crud_TreeTech_Web2.Model;
using Crud_TreeTech_Web2.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crud_TreeTech_Web2
{
    public partial class _Default : Page
    {

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                atualizarGrid();
                msgEsconder();
            }
        }

        #endregion

        #region Controle dos botões
        protected void grdAlarmes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAlarmes.PageIndex = e.NewPageIndex;
            atualizarGrid();
        }

        protected async void btnAtivar_Click(object sender, EventArgs e)
        {
            try
            {
                int idAlarme = Convert.ToInt32((sender as LinkButton).CommandArgument);
                bool aux = false;

                AlarmesModel alarme = new AlarmesModel();

                //Recebendo Lista de Equipamento
                Task<AlarmesModel> t1 = Task<AlarmesModel>.Factory.StartNew((() =>
                    new AlarmesRequest().ListarUmAlarme(idAlarme).Result));

                alarme = t1.Result;
                alarme.Status = true;

                AlarmesRequest alarmesRequest = new AlarmesRequest();
                aux = await alarmesRequest.AtualizarAlarme(alarme);

                ClassificacaoAlarmesModel classificacaoAlarmesModel = new ClassificacaoAlarmesModel();

                //Recebendo Lista de Tipos de Equipamento
                Task<ClassificacaoAlarmesModel> t2 = Task<ClassificacaoAlarmesModel>.Factory.StartNew((() =>
                    new ClassificacaoAlarmesRequest().ListarUmClassificacaoAlarme(alarme.IdClassificacaoAlarme).Result));

                classificacaoAlarmesModel = t2.Result;

                AlarmesAtuadosModel alarmeAtuado = new AlarmesAtuadosModel()
                {
                    IdAlarme = idAlarme,
                    DataEntrada = DateTime.Now
                };

                AlarmesAtuadosRequest alarmesAtuadosRequest = new AlarmesAtuadosRequest();
                aux = await alarmesAtuadosRequest.CadastroAlarmeAtuado(alarmeAtuado);

                controlarGrade();

                if (classificacaoAlarmesModel.EnviarEmail)
                {
                    bool retorno = new EnviarEmail().sendEmailAviso(alarme.NomeAlarme);
                    if(retorno)
                        AlertaSucesso(string.Format("Alarme acionado com sucesso Email enviado para {0}",new Base().getEmailEnvioAlerta()) );
                }
                else
                {
                    AlertaSucesso("Alarme Acionado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                alerta("Ocorreu um problema ao acionar o alarme!",ex.Message);
            }
        }

        protected async void btnDesativar_Click(object sender, EventArgs e)
        {
            try
            {
                int idAlarme = Convert.ToInt32((sender as LinkButton).CommandArgument);
                bool aux = false;

                AlarmesModel alarme = new AlarmesModel();

                //Recebendo Lista de Equipamento
                Task<AlarmesModel> t1 = Task<AlarmesModel>.Factory.StartNew((() =>
                    new AlarmesRequest().ListarUmAlarme(idAlarme).Result));

                alarme = t1.Result;
                alarme.Status = false;

                AlarmesRequest alarmesRequest = new AlarmesRequest();
                aux = await alarmesRequest.AtualizarAlarme(alarme);

                AlarmesAtuadosModel alarmeAtuado = new AlarmesAtuadosModel()
                {
                    IdAlarme = idAlarme,
                    DataSaida = DateTime.Now
                };

                AlarmesAtuadosRequest alarmesAtuadosRequest = new AlarmesAtuadosRequest();
                aux = await alarmesAtuadosRequest.AtualizarAlarmeAtuado(alarmeAtuado);

                controlarGrade();

                AlertaSucesso("Sucesso em desativar o alarme!");
            }
            catch (Exception ex)
            {
                alerta("Ocorreu um problema ao desativar o alarme",ex.Message);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            controlarGrade();
        }

        protected void btnRanking_Click(object sender, EventArgs e)
        {
            try
            {
                //Declarando Modelo para receber resultado da consulta da API
                List<AlarmesAtuadosModel> alarmesAtuadosModel;
                string msg = "Top 3 Alarmes:<br/>";

                //Recebendo Lista Equipamentos
                Task<List<AlarmesAtuadosModel>> t1 = Task<List<AlarmesAtuadosModel>>.Factory.StartNew((() =>
                    new AlarmesAtuadosRequest().RankingAlarmeAtuados().Result));

                alarmesAtuadosModel = t1.Result;

                for (int i = 0; i < alarmesAtuadosModel.Count; i++)
                {
                    Task<AlarmesModel> t2 = Task<AlarmesModel>.Factory.StartNew((() =>
                    new AlarmesRequest().ListarUmAlarme(alarmesAtuadosModel[i].IdAlarme).Result));

                    alarmesAtuadosModel[i].NomeAlarme = t2.Result.NomeAlarme;
                }

                for (int i = 0; i < alarmesAtuadosModel.Count; i++)
                {
                    msg += string.Format("{0}º - {1}<br/>", (i + 1), alarmesAtuadosModel[i].NomeAlarme);
                }
                AlertaSucesso(msg);
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregar ranking de alarmes!", ex.Message);
            }
        }
        #endregion

        #region Controles de mensagem alerta
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "consoleLog", string.Format("console.log('Erro: {0}');", erro), true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "function", string.Format("esconderMsg();"), true);
            }
        }

        protected void AlertaSucesso(string mensagem)
        {
            if (!mensagem.Equals(""))
            {
                dvSucesso.InnerHtml = mensagem;
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
        #endregion

        #region Controles da grade
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
                grdAlarmes.DataSource = alarmesModel;
                grdAlarmes.DataBind();
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregar registros da grade!", ex.Message);
            }
        }

        private void atualizarGrid(string coluna,string filtro)
        {
            try
            {
                //Declarando Modelo para receber resultado da consulta da API
                List<AlarmesModel> alarmesModel;

                //Recebendo Lista Equipamentos
                Task<List<AlarmesModel>> t1 = Task<List<AlarmesModel>>.Factory.StartNew((() =>
                    new AlarmesRequest().ListarTodosAlarmeOrdenado(coluna,filtro).Result));

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
                grdAlarmes.DataSource = alarmesModel;
                grdAlarmes.DataBind();
            }
            catch (Exception ex)
            {
                alerta("Problema ao carregar registros da grade!", ex.Message);
            }
        }

        protected void grdAlarmes_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string filtro = txtPesquisa.Value;
                List<AlarmesModel> alarmesModel;

                SortDirection sortDirection = SortDirection.Ascending;
                string sortField = string.Empty;

                SortGridview((GridView)sender, e, out sortDirection, out sortField);
                string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";

               //Recebendo Lista de alarmes apenas ordenados
               Task<List<AlarmesModel>> t1 = Task<List<AlarmesModel>>.Factory.StartNew((() =>
                   new AlarmesRequest().ListarTodosAlarmeOrdenado(string.IsNullOrEmpty(filtro) ? e.SortExpression + " " + strSortDirection : e.SortExpression + " " + strSortDirection, filtro).Result));

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

                grdAlarmes.DataSource = alarmesModel;
                grdAlarmes.DataBind();
            }
            catch (Exception ex)
            {
                alerta("Problema ao ordernar registro da grade!", ex.Message);
            }
        }

        private void SortGridview(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        {
            sortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null && gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (sortField == gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"] == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }

                gridView.Attributes["CurrentSortField"] = sortField;
                gridView.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }
        }

        protected void grdAlarmes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text.Equals("True"))
                    e.Row.Cells[4].Text = "Ativo";
                else
                    e.Row.Cells[4].Text = "Inativo";
            }
        }

        private void controlarGrade()
        {
            string texto = txtPesquisa.Value;

            if (!string.IsNullOrEmpty(texto))
            {
                atualizarGrid(string.Empty, texto);
            }
            else
            {
                atualizarGrid();
            }
        }
        #endregion
    }
}