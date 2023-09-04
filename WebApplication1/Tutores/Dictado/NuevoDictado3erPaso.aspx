<%@ Page Title="Nuevo Dictado - Paso 3" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoDictado3erPaso.aspx.cs" Inherits="WebApplication1.Tutores.Dictado.NuevoDictador3erPaso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container mt-5">
        <div class="row">
            <!-- Tercera Columna - Tutores -->
            <div class="col-lg-12">
                <h2>Paso 3: Tutores</h2>
                <hr />
                <div class="input-group">
                    <asp:TextBox ID="SearchTutorTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="SearchTutorButton" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="SearchTutorButton_Click" />
                </div>
                <asp:GridView ID="TutorsGrid" runat="server" AutoGenerateColumns="false" CssClass="table mt-3" DataKeyNames="IdUsuario">
                    <Columns>
                        <asp:BoundField DataField="IdUsuario" HeaderText="Id" Visible="false" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnAdd" CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Agregar" runat="server" onclick="btnAdd_Click1" CausesValidation="false"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <h3 class="mt-3">Tutores Asignados</h3>
                <asp:GridView ID="AssignedTutorsGrid" runat="server" AutoGenerateColumns="false" CssClass="table mt-3" DataKeyNames="IdUsuario">
                    <Columns>
                        <asp:BoundField DataField="IdUsuario" HeaderText="Id" Visible="false" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnRemove" CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Eliminar" runat="server" onclick="btnRemove_Click" CausesValidation="false"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="ConfirmButton" runat="server" Text="Confirmar" CssClass="btn btn-primary mt-3" OnClick="ConfirmButton_Click" />
                <asp:Button ID="btnBack" CssClass="btn btn-secondary mt-3" Text="Atrás" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" />
                <asp:Button ID="CancelButton" runat="server" Text="Cancelar" CssClass="btn btn-danger mt-3" OnClick="CancelButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>