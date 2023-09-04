<%@ Page Title="Nuevo Dictado - Paso 1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoDictado1erPaso.aspx.cs" Inherits="WebApplication1.Tutores.Dictado.NuevoDictadoInteractivo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <div class="container mt-5">
        <div class="row">
            <!-- Primera Columna - Curso -->
            <div class="col-lg-12">
                <h2>Paso 1: Seleccionar Curso</h2>
                <hr />
                <div class="input-group">
                    <asp:TextBox ID="SearchCourseTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="SearchCourseButton" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="SearchCourseButton_Click" CausesValidation="false" />
                </div>
                <asp:GridView ID="coursesGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:TemplateField HeaderText="Especialidad">
                            <ItemTemplate>
                                <%# Eval("Especialidad.Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" CssClass="btn btn-secondary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Seleccionar" runat="server" onclick="btnSelect_Click" CausesValidation="false"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <hr />
                <asp:Label Font-Bold="True" runat="server">Curso Seleccionado</asp:Label>
                <asp:TextBox ID="SelectedCourseTextBox" runat="server" CssClass="form-control mt-3" Enabled="false"></asp:TextBox>
                <hr />
                <asp:Label Font-Bold="True" runat="server">Enlace de la cursada</asp:Label>
                <asp:TextBox ID="CourseLinkTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <hr />
                <asp:Label Font-Bold="True" runat="server">Cupo</asp:Label>
                <asp:TextBox ID="CapacityTexBox" runat="server" CssClass="form-control"></asp:TextBox>
                <hr />
                <asp:Label runat="server" Font-Bold="True">Tipo de dictado</asp:Label>
                <asp:DropDownList ID="CourseTypeDropDown" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Interactivo">Interactivo</asp:ListItem>
                    <asp:ListItem Value="Autodirigido">Autodirigido</asp:ListItem>
                </asp:DropDownList>
                <hr />
                <asp:Label runat="server" Font-Bold="True">Fecha de Inicio</asp:Label>
                <asp:TextBox ID="StartDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                <hr />
                <asp:Label runat="server" Font-Bold="True">Fecha de Fin</asp:Label>
                <asp:TextBox ID="EndDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                <hr />
                <asp:Button ID="NextPageButton" runat="server" Text="Siguiente" CssClass="btn btn-primary mt-3" OnClick="NextPageButton_Click1" />

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseName" Display="None" runat="server" ControlToValidate="SelectedCourseTextBox" CssClass="text-danger" ErrorMessage="Debe seleccionar un curso"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseLink" Display="None" runat="server" ControlToValidate="CourseLinkTextBox" CssClass="text-danger" ErrorMessage="Debe ingresar un link para continuar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCourseLink" Display="None" runat="server" ControlToValidate="CourseLinkTextBox" CssClass="text-danger" ErrorMessage="Debe ingresar un link valido" ValidationExpression="^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ControlToValidate="CapacityTexBox" CssClass="text-danger" ErrorMessage="Debe ingresar la capacidad"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" runat="server" ControlToValidate="CapacityTexBox" CssClass="text-danger" ErrorMessage="La capacidad es de entre 1 y 50" ValidationExpression="^(?:[1-9]|[1-4][0-9]|50)$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaInicio" Display="None" runat="server" ControlToValidate="StartDateTextBox" CssClass="text-danger" ErrorMessage="Debe ingresar fecha de inicio"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaFin" Display="None" runat="server" ControlToValidate="EndDateTextBox" CssClass="text-danger" ErrorMessage="Debe ingresar fecha de fin"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" HeaderText="Errores:"/>
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