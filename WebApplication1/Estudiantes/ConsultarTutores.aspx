<%@ Page Title="Consultar Tutores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarTutores.aspx.cs" Inherits="WebApplication1.ConsultarTutores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Consulta a Tutores</h2>
        <div class="row">
            <div class="col-md-6">
                <!-- Búsqueda de tutores -->
                <div class="form-group">
                    <label for="searchName">Buscar por Nombre</label>
                    <asp:TextBox ID="searchName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="searchCourse">Buscar por Curso</label>
                    <asp:TextBox ID="searchCourse" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" />
                </div>

                <!-- Tutor Seleccionado -->
                <div class="form-group">
                    <label for="txtSelectedTutor">Tutor Seleccionado</label>
                    <asp:TextBox ID="txtSelectedTutor" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                </div>

                <!-- Resultados de la búsqueda -->
                <asp:GridView ID="tutorsGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Curso" HeaderText="Curso" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" CssClass="btn btn-secondary" runat="server" Text="Seleccionar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnSelect_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <div class="col-md-6">
                <!-- Formulario de consulta -->
                <div class="form-group mt-4" style="background-color: #F0F0F0; padding: 15px;">
                    <label for="txtName">Nombre</label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtSurname">Apellido</label>
                    <asp:TextBox ID="txtSurname" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtEmail">Correo Electrónico</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtComment">Comentario</label>
                    <asp:TextBox ID="txtComment" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSendQuery" CssClass="btn btn-primary" Text="Enviar Consulta" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
