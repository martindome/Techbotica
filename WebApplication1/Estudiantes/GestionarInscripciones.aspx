<%@ Page Title="Mis Inscripciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarInscripciones.aspx.cs" Inherits="WebApplication1.Estudiantes.GestionarInscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Gestión de Inscripciones</h2>

        <!-- Sección de Carreras -->
        <h3>Carreras</h3>
        <div class="form-group">
            <label for="searchCareerName">Nombre de la Carrera</label>
            <asp:TextBox ID="searchCareerName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnSearchCareer" CssClass="btn btn-primary" Text="Buscar Carreras" runat="server" />
        <asp:GridView ID="careersGrid" CssClass="table" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnSelectCarrera" CssClass="btn btn-secondary" runat="server" Text="Seleccionar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnSelectCarrera_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <hr> <!-- Linea divisoria -->

        <!-- Sección de Cursos -->
        <h3>Cursos</h3>
        <div class="form-group">
            <label for="searchCourseName">Nombre del Curso</label>
            <asp:TextBox ID="searchCourseName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="searchStartDate">Fecha de Inicio</label>
            <asp:TextBox ID="searchStartDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="searchEndDate">Fecha de Fin</label>
            <asp:TextBox ID="searchEndDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="searchSpeciality">Especialidad</label>
            <asp:DropDownList ID="searchSpeciality" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="searchStatus">Estado</label>
            <asp:DropDownList ID="searchStatus" CssClass="form-control" runat="server">
                <asp:ListItem Text="Activa" Value="Activa" />
                <asp:ListItem Text="Inactiva" Value="Inactiva" />
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnSearchCourse" CssClass="btn btn-primary" Text="Buscar Cursos" runat="server" />
        <asp:GridView ID="coursesGrid" CssClass="table" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" />
                <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Fin" />
                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnSelectCurso" CssClass="btn btn-secondary" runat="server" Text="Seleccionar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' onclick="btnSelectCurso_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

