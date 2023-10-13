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
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" ValidationGroup="SearchValidation" Display="None" runat="server" ControlToValidate="searchName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="searchCourse">Buscar por Curso</label>
                    <asp:TextBox ID="searchCourse" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="SearchValidation" Display="None" runat="server" ControlToValidate="searchCourse" CssClass="text-danger" ErrorMessage="Debe ingresar un curso valido" ValidationExpression="^(?i)[a-zA-ZáéíóúñÁÉÍÓÚÑ]+(?:[-\s][a-zA-ZáéíóúñÁÉÍÓÚÑ]+)*(?:-\d{2})?$"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Buscar" runat="server" OnClick="btnSearch_Click"  ValidationGroup="SearchValidation"/>
                </div>
                <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" ValidationGroup="SearchValidation" HeaderText="Errores:"/>

                <!-- Tutor Seleccionado -->
                <div class="form-group">
                    <label for="txtSelectedTutor">Tutor Seleccionado</label>
                    <asp:TextBox ID="txtSelectedTutor" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                </div>

                <!-- Resultados de la búsqueda -->
                <asp:GridView ID="tutorsGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False" DataKeyNames="IdUsuario">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="IdUsuario" HeaderText="Id" Visible="false" />
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" ValidationGroup="EmailQueryValidation" Display="None" runat="server" ControlToValidate="txtName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="EmailQueryValidation" Display="None" runat="server" ControlToValidate="txtName" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
                    <label for="txtSurname">Apellido</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="EmailQueryValidation" Display="None" runat="server" ControlToValidate="txtSurname" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="EmailQueryValidation" Display="None" runat="server" ControlToValidate="txtSurname" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre valido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ-]+)*$"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtSurname" CssClass="form-control" runat="server"></asp:TextBox>                   
                    <label for="txtEmail">Correo Electrónico</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCorreo" ValidationGroup="EmailQueryValidation" runat="server" Display="None" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="Debe ingresar un correo para continuar"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCorreo" ValidationGroup="EmailQueryValidation" Display="None" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="Debe ingresar una casilla de email valida" ValidationExpression="^[a-zA-Z0-9+_.-]{1,50}@[a-zA-Z0-9.-]{1,49}$"></asp:RegularExpressionValidator>
                    <label for="txtComment">Comentario</label>
                    <asp:TextBox ID="txtComment" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="EmailQueryValidation" runat="server" Display="None" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="Debe ingresar un comentario para continuar"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationGroup="EmailQueryValidation" Display="None" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="Ingrese un comentario valido (hasta 300 caracteres)" ValidationExpression="^.{1,300}$"></asp:RegularExpressionValidator>
                    <asp:Button ID="btnSendQuery" CssClass="btn btn-primary" Text="Enviar Consulta" runat="server" OnClick="btnSendQuery_Click" ValidationGroup="EmailQueryValidation" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" cssclass="text-bg-danger" ValidationGroup="EmailQueryValidation" HeaderText="Errores:"/>
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>
