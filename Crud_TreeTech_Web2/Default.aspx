<%@ Page Title="Página Inicial" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Crud_TreeTech_Web2._Default" Async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div runat="server" class="row justify-content-md-center" id="dvPanels">
            <br/>
            <div class="col col-lg-12 alert alert-success" style="text-align:center;" id="dvSucesso" runat="server"></div>
            <div class="col col-lg-12 alert alert-warning" style="text-align:center;" id="dvAlerta" runat="server"></div>
            <br/>
        </div>
    </div>
    <h1>Controle de Alarmes</h1>
    <div class="col" style="margin-left:-15px;">
        <div class="input-group mb-3">
            <input type="text" class="form-control" placeholder="Pequisar alarme" aria-label="Recipient's username" aria-describedby="basic-addon2" id="txtPesquisa" runat="server">
            <div class="input-group-append">
                <asp:Button ID="btnPesquisar" runat="server" Text="🔍" OnClick="btnPesquisar_Click"/>
            </div>
        </div>
        <div class="input-group mb-3">
            <asp:Button ID="btnRanking" runat="server" Text="Mostrar Top 3" OnClick="btnRanking_Click"/>
        </div>
    </div>
    <asp:GridView ID="grdAlarmes" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdAlarmes_PageIndexChanging" AllowSorting="true" OnRowDataBound="grdAlarmes_RowDataBound" OnSorting="grdAlarmes_Sorting" CurrentSortField="ID_Alarme" CurrentSortDirection="ASC">
        <Columns>
            <asp:TemplateField HeaderText="Ações" HeaderStyle-Width="100">
                <ItemTemplate>
                    <asp:LinkButton ID="btnAtivar" Visible='<%# Convert.ToBoolean(Eval("Status")) ? false : true %>'  runat="server" Font-Size="18px" OnClick="btnAtivar_Click" CommandArgument='<%# Eval("IdAlarme") %>'><i class="glyphicon glyphicon-off" title="Acionar o Alarme" style="font-size:18px; color:red;" ></i></asp:LinkButton>
                    <asp:LinkButton ID="btnDesativar" Visible='<%# Convert.ToBoolean(Eval("Status")) %>' runat="server" Font-Size="18px" OnClick="btnDesativar_Click" CommandArgument='<%# Eval("IdAlarme") %>'><i class="glyphicon glyphicon-off" title="Desativar Alarme" style="font-size:18px; margin-left:-1px; color: forestgreen; "></i></asp:LinkButton>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NomeAlarme" HeaderText="Nome" HeaderStyle-Width="500" SortExpression="NM_Alarme"/>
            <asp:BoundField DataField="NomeClassificacaoAlarme" HeaderText="Classificação" HeaderStyle-Width="100" SortExpression="NM_Classificacao_Alarme"/>
            <asp:BoundField DataField="NomeEquipamento" HeaderText="Equipamento" HeaderStyle-Width="500" SortExpression="NM_Equipamento"/>
            <asp:BoundField DataField="Status" HeaderText="Status"/>
        </Columns>
    </asp:GridView>
</asp:Content>
