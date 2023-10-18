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
        <asp:GridView ID="careersGrid" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="IdInscripcion">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="FechaInscripcion" HeaderText="Fecha de Inscripción" DataFormatString="{0:d}" HtmlEncode="false" />
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
            <label for="searchStartDate">Fecha de Inicio</label>
            <asp:TextBox ID="searchStartDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="searchEndDate">Fecha de Fin</label>
            <asp:TextBox ID="searchEndDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnSearchCourse" CssClass="btn btn-primary" Text="Buscar Cursos" runat="server" onclick="btnSearchCourse_Click"/>
        <asp:GridView ID="coursesGrid" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="IdInscripcion">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="FechaInscripcion" HeaderText="Fecha de Inscripción" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Finalizacion" DataFormatString="{0:d}" HtmlEncode="false" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnSelectCurso" CssClass="btn btn-secondary" runat="server" Text="Seleccionar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnSelectCurso_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

