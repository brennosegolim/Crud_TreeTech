<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCadastroEquipamento.aspx.cs" Inherits="Crud_TreeTech_Web2.Views.frmCadastroEquipamento" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <div class="container">
        <div runat="server" class="row justify-content-md-center" id="dvPanels">
            <div class="col col-lg-2 alert alert-success" style="text-align:center;" id="dvSucesso" runat="server"></div>
            <div class="col col-lg-2 alert alert-warning" style="text-align:center;" id="dvAlerta" runat="server"></div>
        </div>
    </div>
    <br/>
    <h1>Equipamento</h1>
    <div class="form-group">
        <label for="txtNomeTipoEquipamento" >Nome</label>
        <input type="text" class="form-control" id="txtNomeEquipamento" placeholder="Digite o Nome do Equipamento" runat="server">
    </div>
    <div class="form-group">
        <label for="txtNumeroSerie">Número de série</label>
        <input type="text" class="form-control" id="txtNumeroSerie" placeholder="Digite o Número de Série do Equipamento" runat="server">
    </div>
    <div class="form-group">
        <label for="cbTipoEquipamento">Tipo de Equipamento</label>
        <asp:DropDownList ID="cbTipoEquipamento" runat="server">
        </asp:DropDownList>
    </div>
    <asp:Button class="btn btn-primary" ID="btnConfirmar" runat="server" Text="Gravar" OnClick="btnConfirmar_Click"/>
    <br/>
    <br/>
    <div style="border-top-width: 1px; border-top-color: lightgray; border-top-style: solid;"></div>
    <br/>
    <asp:GridView ID="grdEquipamento" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" AllowPaging="true" PageSize="5" OnPageIndexChanging="grdEquipamento_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Ações" HeaderStyle-Width="50">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDeletar"  runat="server" Font-Size="18px" OnClick="btnDeletar_Click" CommandArgument='<%# Eval("IdEquipamento") %>'><i class="glyphicon glyphicon-trash" title="Excluir" style="font-size:18px; color:#de2a2a;"></i></asp:LinkButton>
                    <asp:LinkButton ID="btnAlterar"  runat="server" Font-Size="18px" OnClick="btnAlterar_Click" CommandArgument='<%# Eval("IdEquipamento") %>'><i class="glyphicon glyphicon-pencil" title="Editar" style="font-size:18px; margin-left:5px;"></i></asp:LinkButton>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NomeEquipamento" HeaderText="Nome" HeaderStyle-Width="500"/>
            <asp:BoundField DataField="NumeroSerie" HeaderText="Número de Série" HeaderStyle-Width="300"/>
            <asp:BoundField DataField="NomeTipoEquipamento" HeaderText="Tipo de equipamento" HeaderStyle-Width="500"/>
            <asp:BoundField DataField="DataCadastro" HeaderText="Data de Cadastro" HeaderStyle-Width="200"/>
        </Columns>
    </asp:GridView>
    <input id="HiddenAcao" type="hidden" runat="server" />
</asp:Content>
