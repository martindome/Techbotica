<%@ Page Title="Editar Dominios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dominios.aspx.cs" Inherits="WebApplication1.Administracion.Empresas.Dominios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Dominios de la Empresa</h2>

        <asp:GridView ID="DomainsGrid" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="IdDominio">
            <Columns>
                 <asp:BoundField DataField="IdDominio" HeaderText="Dominio" Visible="false" />
                <asp:BoundField DataField="Sufijo" HeaderText="Sufijo del Dominio" />
                <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button runat="server" ID="botoneliminardominio" ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' onclick="botoneliminardominio_Click" CausesValidation="false"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="form-group mt-4">
            <label for="NewDomain">Nuevo Dominio</label>
            <asp:TextBox ID="NewDomain" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group mt-4">
            <asp:Button ID="btnCreateDomain" CssClass="btn btn-success" Text="Crear Dominio" runat="server" OnClick="btnCreateDomain_Click" />
            <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClick="btnBack_Click" />
        </div>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorDominio" Display="None" runat="server" ControlToValidate="NewDomain" CssClass="text-danger" ErrorMessage="Debe ingresar un dominio valido" ValidationExpression="^(?!-)(?!.*--)([A-Za-z0-9-]{1,63}\.)+[A-Za-z]{2,6}$"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
    </div>
</asp:Content>
