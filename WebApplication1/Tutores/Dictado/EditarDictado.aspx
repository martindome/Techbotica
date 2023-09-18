<%@ Page Title="Editar Dictado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarDictado.aspx.cs" Inherits="WebApplication1.Tutores.Dictado.EditarDictado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <div class="container">
        <h2 class="mb-4">Editar Dictado</h2>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Font-Bold="True">Fecha de Inicio</asp:Label>
                <asp:TextBox ID="StartDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                <hr />
                <asp:Label runat="server" Font-Bold="True">Fecha de Fin</asp:Label>
                <asp:TextBox ID="EndDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                <hr />
                <asp:Label runat="server" Font-Bold="True">Enlace</asp:Label>
                <asp:TextBox ID="LinkTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                <hr />
                <asp:Label runat="server" AssociatedControlID="TextBoxcupo" CssClass="form-label">Cupo:</asp:Label>
                <asp:TextBox ID="TextBoxcupo"  runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <asp:Button class="btn btn-secondary mt-3" type="button" ID="ButtonEditarHorarios" Text="Editar Horarios" runat="server" OnClick="ButtonEditarHorarios_Click" />
                <asp:Button class="btn btn-secondary mt-3" type="button" ID="ButtonEditarTutores" Text="Editar Tutores" runat="server" onclick="ButtonEditarTutores_Click"/>
            </div>
            <div>
                <asp:Button class="btn btn-primary mt-3" type="button" ID="Button1" Text="Actualizar Dictado" runat="server" OnClick="UpdateDictationButton_Click" />
                <asp:Button class="btn btn-danger mt-3" type="button" ID="Button2" Text="Eliminar Dictado" runat="server" OnClick="DeleteDictationButton_Click" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseLink" Display="None" runat="server" ControlToValidate="LinkTextBox" CssClass="text-danger" ErrorMessage="Debe ingresar un link para continuar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCourseLink" Display="None" runat="server" ControlToValidate="LinkTextBox" CssClass="text-danger" ErrorMessage="Debe ingresar un link valido" ValidationExpression="^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ControlToValidate="TextBoxcupo" CssClass="text-danger" ErrorMessage="Debe ingresar la capacidad"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" runat="server" ControlToValidate="TextBoxcupo" CssClass="text-danger" ErrorMessage="La capacidad es de entre 1 y 50" ValidationExpression="^(?:[1-9]|[1-4][0-9]|50)$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaInicio" Display="None" runat="server" ControlToValidate="StartDateTextBox" CssClass="text-danger" ErrorMessage="Debe ingresar fecha de inicio"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaFin" Display="None" runat="server" ControlToValidate="EndDateTextBox" CssClass="text-danger" ErrorMessage="Debe ingresar fecha de fin"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
            </div>
            <div>
                <asp:Button ID="btnBack" CssClass="btn btn-secondary mt-3" Text="Atrás" runat="server" OnClick="btnBack_Click" />
            </div>
        </div>            
    </div>
        
        <script>
        $(document).ready(function () {
            $("#<%= StartDateTextBox.ClientID %>").datepicker({
                dateFormat: "dd/mm/yy"
            });
            $("#<%= EndDateTextBox.ClientID %>").datepicker({
                dateFormat: "dd/mm/yy"
            });
        });
        </script>
</asp:Content>