<%@ Page Title="Tipo de Equipamento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCadastroTipoEquipamento.aspx.cs" Inherits="Crud_TreeTech_Web2.Views.frmCadastroTipoEquipamento" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <div class="container">
        <div runat="server" class="row justify-content-md-center" id="dvPanels">
            <div class="col col-lg-12 alert alert-success" style="text-align:center;" id="dvSucesso" runat="server"></div>
            <div class="col col-lg-12 alert alert-warning" style="text-align:center;" id="dvAlerta" runat="server"></div>
        </div>
    </div>
    <h1>Tipo de Equipamento</h1>
    <div class="form-group">
        <label for="txtNomeTipoEquipamento" >Nome</label>
        <input type="text" class="form-control" id="txtNomeTipoEquipamento" placeholder="Digite o Nome do Tipo de Equipamento" runat="server">
    </div>
    <div class="form-group">
        <label for="txtObservacao">Observação</label>
        <textarea class="form-control" id="txtObservacao" rows="3" runat="server"></textarea>
    </div>
    <asp:Button class="btn btn-primary" ID="btnConfirmar" runat="server" Text="Gravar" OnClick="btnConfirmar_Click"/>
    <br/>
    <br/>
    <div style="border-top-width: 1px; border-top-color: lightgray; border-top-style: solid;"></div>
    <br/>
    <asp:GridView ID="grdTipoEquipamento" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" AllowPaging="true" PageSize="5" OnPageIndexChanging="grdTipoEquipamento_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Ações" HeaderStyle-Width="50">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDeletar"  runat="server" Font-Size="18px" OnClick="btnDeletar_Click" CommandArgument='<%# Eval("IdTipoEquipamento") %>'><i class="glyphicon glyphicon-trash" title="Excluir" style="font-size:18px; color:#de2a2a;"></i></asp:LinkButton>
                    <asp:LinkButton ID="btnAlterar"  runat="server" Font-Size="18px" OnClick="btnAlterar_Click" CommandArgument='<%# Eval("IdTipoEquipamento") %>'><i class="glyphicon glyphicon-pencil" title="Editar" style="font-size:18px; margin-left:5px;"></i></asp:LinkButton>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NomeTipoEquipamento" HeaderText="Nome" HeaderStyle-Width="500"/>
            <asp:BoundField DataField="Observacao" HeaderText="Observação" HeaderStyle-Width="500"/>
        </Columns>
    </asp:GridView>
    <input id="HiddenAcao" type="hidden" runat="server" />
</asp:Content>
