<%@ Page Title="Editar Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCurso.aspx.cs" Inherits="WebApplication1.Tutores.Curso.EditarCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mb-4">Editar Curso</h2>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" AssociatedControlID="CourseName" CssClass="form-label">Nombre del Curso:</asp:Label>
                <asp:TextBox ID="CourseName" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label runat="server" AssociatedControlID="CourseDescription" CssClass="form-label">Descripción del Curso:</asp:Label>
                <asp:TextBox ID="CourseDescription" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label runat="server" AssociatedControlID="CourseSpeciality" CssClass="form-label">Especialidad:</asp:Label>
                <asp:DropDownList ID="CourseSpeciality" runat="server" CssClass="form-control"></asp:DropDownList>
                
                <asp:Button ID="ButtonEditCareers" CssClass="btn btn-primary ml-2" Text="Editar Carreras" runat="server" OnClick="ButtonEditCareers_Click" CausesValidation="false"/>
                <asp:Button class="btn btn-primary" type="button" ID="UpdateCourseButton" Text="Actualizar" runat="server" OnClick="UpdateCourseButton_Click"/>
                <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClick="btnBack_Click" CausesValidation="false" />


                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseName" Display="None" runat="server" ControlToValidate="CourseName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCourseName" Display="None" runat="server" ControlToValidate="CourseName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre válido" ValidationExpression="^(?=.*[a-zA-Z0-9\-])[a-zA-Z0-9\- ]{1,50}$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseDescription" Display="None" runat="server" ControlToValidate="CourseDescription" CssClass="text-danger" ErrorMessage="Debe ingresar una descripción para continuar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCourseDescription" Display="None" runat="server" ControlToValidate="CourseDescription" CssClass="text-danger" ErrorMessage="Debe ingresar una descripción válida" ValidationExpression="^(?=.*[a-zA-Z0-9\-])[a-zA-Z0-9\- ]{1,50}$"></asp:RegularExpressionValidator>
            </div>
        </div>
    </div>
</asp:Content>




