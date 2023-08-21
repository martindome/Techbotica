<%@ Page Title="Nuevo Dictado - Paso 1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoDictado1erPaso.aspx.cs" Inherits="WebApplication1.Tutores.Dictado.NuevoDictadoInteractivo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container mt-5">
        <div class="row">
            <!-- Primera Columna - Curso -->
            <div class="col-lg-12">
                <h2>Paso 1: Seleccionar Curso</h2>
                <hr />
                <div class="input-group">
                    <asp:TextBox ID="SearchCourseTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="SearchCourseButton" runat="server" Text="Buscar" CssClass="btn btn-primary" />
                </div>
                <asp:GridView ID="CoursesGrid" runat="server" AutoGenerateColumns="false" CssClass="table mt-3">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre del Curso" DataField="CourseName" />
                        <asp:BoundField HeaderText="Especialidad" DataField="Specialty" />
                        <asp:ButtonField Text="Seleccionar" CommandName="Select" />
                    </Columns>
                </asp:GridView>
                <asp:TextBox ID="SelectedCourseTextBox" runat="server" CssClass="form-control mt-3" Enabled="false"></asp:TextBox>
                <hr />
                <asp:Label Font-Bold="True" runat="server">Enlace del Curso</asp:Label>
                <hr />
                <asp:TextBox ID="CourseLinkTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label Font-Bold="True" runat="server">Cupo</asp:Label>
                <hr />
                <asp:TextBox ID="CapacityTexBox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label runat="server" Font-Bold="True">Tipo de dictado</asp:Label>
                <hr />
                <asp:DropDownList ID="CourseTypeDropDown" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Interactivo">Interactivo</asp:ListItem>
                    <asp:ListItem Value="Autodirigido">Autodirigido</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="NextPageButton" runat="server" Text="Siguiente" CssClass="btn btn-primary mt-3" OnClick="NextPageButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>