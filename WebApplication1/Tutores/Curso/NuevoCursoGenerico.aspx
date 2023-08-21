<%@ Page Title="Nuevo Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoCursoGenerico.aspx.cs" Inherits="WebApplication1.Tutores.Nuevo.NuevoCursoGenerico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mb-4">Crear Curso</h2>

        <asp:Label runat="server" AssociatedControlID="CourseName" CssClass="form-label">Nombre del Curso:</asp:Label>
        <asp:TextBox ID="CourseName" runat="server" CssClass="form-control"></asp:TextBox>
        
        <asp:Label runat="server" AssociatedControlID="CourseDescription" CssClass="form-label mt-3">Descripción del Curso:</asp:Label>
        <asp:TextBox ID="CourseDescription" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label runat="server" AssociatedControlID="CourseSpecialty" CssClass="form-label mt-3">Especialidad del Curso:</asp:Label>
        <asp:DropDownList ID="CourseSpecialty" runat="server" CssClass="form-control">
            <asp:ListItem Value="Especialidad 1">Especialidad 1</asp:ListItem>
            <asp:ListItem Value="Especialidad 2">Especialidad 2</asp:ListItem>
            <asp:ListItem Value="Especialidad 3">Especialidad 3</asp:ListItem>
        </asp:DropDownList>

        <h3 class="mt-4">Seleccionar Carrera</h3>
        <%--<div class="input-group mb-3">
            <asp:TextBox ID="SearchCareer" runat="server" CssClass="form-control" placeholder="Buscar carrera"></asp:TextBox>
            <button class="btn btn-outline-secondary" type="button" id="SearchButton">Buscar</button>
        </div>--%>

        <div>
                <h4>Carreras</h4>
                <div class="input-group mb-3">
                    <asp:TextBox ID="SearchTutorTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button class="btn btn-primary" type="button" ID="SearchTutorButton" Text="Buscar" runat="server" />
                </div>

                <asp:ListBox ID="AvailableTutorsList" runat="server" CssClass="form-control mb-3"></asp:ListBox>
                <asp:Button class="btn btn-outline-secondary mb-3" type="button" ID="AddTutorButton" Text="Asignar Carrera" runat="server" />

                <h4>Carreras Asignadas</h4>
                <asp:ListBox ID="AssignedTutorsList" runat="server" CssClass="form-control mb-3"></asp:ListBox>
                <asp:Button class="btn btn-outline-danger mb-3" type="button" ID="RemoveTutorButton" Text="Desasignar Carrera " runat="server" />
            </div>

        <%--<asp:GridView ID="careersGrid" CssClass="table" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Nombre de la Carrera" />
                <asp:ButtonField Text="Seleccionar" CommandName="Select" />
            </Columns>
        </asp:GridView>--%>

        <asp:Button ID="SubmitButton" runat="server" Text="Nuevo Curso" CssClass="btn btn-primary mt-3" OnClick="SubmitButton_Click" />
    </div>
</asp:Content>