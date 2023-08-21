<%@ Page Title="Busqueda Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCursos.aspx.cs" Inherits="WebApplication1.BuscarCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Buscar Cursos</h2>
        <div class="row">
            <div class="col-md-4">
                <!-- Filtros -->
                <div class="form-group">
                    <label for="searchName">Nombre</label>
                    <asp:TextBox ID="searchName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="searchSpeciality">Especialidad</label>
                    <asp:DropDownList ID="searchSpeciality" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <!-- Botón de búsqueda -->
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" />
                </div>
            </div>
            <div class="col-md-8">
                <!-- Lista de cursos -->
                <asp:GridView ID="coursesGrid" CssClass="table" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" CssClass="btn btn-secondary" runat="server" Text="Seleccionar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnSelect_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
