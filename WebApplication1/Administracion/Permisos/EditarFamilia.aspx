<%@ Page Title="Editar Permiso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarFamilia.aspx.cs" Inherits="WebApplication1.Administracion.Permisos.EditarFamilia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <!-- Tercera Columna - Tutores -->
            <div class="col-lg-12">
                <h2>Patentes</h2>
                <hr />
                <asp:GridView ID="patentesGrid" runat="server" AutoGenerateColumns="false" CssClass="table mt-3" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                        <asp:BoundField HeaderText="Detalle" DataField="detalle" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnAdd" CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Agregar" runat="server" onclick="btnAdd_Click" CausesValidation="false"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <h3 class="mt-3">Patentes asignadas</h3>
                <asp:GridView ID="AssignedPatentesGrid" runat="server" AutoGenerateColumns="false" CssClass="table mt-3" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                        <asp:BoundField HeaderText="Detalle" DataField="detalle" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnRemove" CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Eliminar" runat="server" onclick="btnRemove_Click" CausesValidation="false"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="ConfirmButton" runat="server" Text="Confirmar" CssClass="btn btn-primary mt-3" OnClick="ConfirmButton_Click" />
                <asp:Button ID="btnBack" CssClass="btn btn-secondary mt-3" Text="Atrás" runat="server" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
</asp:Content>
