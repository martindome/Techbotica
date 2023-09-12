<%@ Page Title="Nuevo Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoCursoGenerico.aspx.cs" Inherits="WebApplication1.Tutores.Curso.NuevoCursoGenerico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Nuevo Curso</h2>

        <div class="form-group">
            <label for="CourseName">Nombre del Curso</label>
            <asp:TextBox ID="CourseName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CourseDescription">Descripción del Curso</label>
            <asp:TextBox ID="CourseDescription" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddlEspecialidad">Especialidad</label>
            <asp:DropDownList ID="ddlEspecialidad" CssClass="form-control" runat="server">
            </asp:DropDownList>
        </div>

        <div class="row">
            <div class="col-md-6">
                <h3>Carreras Disponibles</h3>
                <asp:ListBox ID="AvailableCareers" CssClass="form-control" runat="server">
                </asp:ListBox>
                <asp:Button ID="btnAssignCareer" CssClass="btn btn-primary mt-2" Text="Asignar Carrera" runat="server" OnClick="btnAssignCareer_Click" CausesValidation="false" />
            </div>

            <div class="col-md-6">
                <h3>Carreras Asignadas</h3>
                <asp:ListBox ID="AssignedCareers" CssClass="form-control" runat="server">
                </asp:ListBox>
                <asp:Button ID="btnRemoveCareer" CssClass="btn btn-danger mt-2" Text="Desasignar Carrera" runat="server" OnClick="btnRemoveCareer_Click" CausesValidation="false" />
            </div>
        </div>

        <div class="form-group mt-4">
            <asp:Button ID="btnCreateCourse" CssClass="btn btn-success" Text="Crear Curso" runat="server" OnClick="btnCreateCourse_Click" />
            <asp:Button ID="btnBackToCourses" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClick="btnBackToCourses_Click" CausesValidation="false" />
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseName" Display="None" runat="server" ControlToValidate="CourseName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCourseName" Display="None" runat="server" ControlToValidate="CourseName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre válido" ValidationExpression="^(?=.*[a-zA-Z0-9\-])[a-zA-Z0-9\- ]{1,50}$"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseDescription" Display="None" runat="server" ControlToValidate="CourseDescription" CssClass="text-danger" ErrorMessage="Debe ingresar una descripción para continuar"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCourseDescription" Display="None" runat="server" ControlToValidate="CourseDescription" CssClass="text-danger" ErrorMessage="Debe ingresar una descripción válida" ValidationExpression="^(?=.*[a-zA-Z0-9\-])[a-zA-Z0-9\- ]{1,50}$"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="valSummaryCourse" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
    </div>
</asp:Content>