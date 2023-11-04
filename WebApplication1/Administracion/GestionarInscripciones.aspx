<%@ Page Title="Gestionar Inscripciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarInscripciones.aspx.cs" Inherits="WebApplication1.Administracion.GestionarInscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<style>
        /* CSS personalizado para tu GridView */
        .table-responsive {
            width: 100%;
            margin-bottom: 15px;
            overflow-y: hidden; /* O "scroll" si prefieres tener un scroll cuando sea necesario */
            -ms-overflow-style: -ms-autohiding-scrollbar;
            border: 1px solid #ddd;
        }
    </style>--%>
    <div class="container">
        <h2>Gestión de Usuarios e Inscripciones</h2>
        
        <!-- Sección de búsqueda de usuarios -->
        <asp:TextBox ID="SearchUserByNameTextBox" runat="server" CssClass="form-control" Placeholder="Buscar usuarios por nombre"></asp:TextBox>
        <asp:TextBox ID="SearchUserByEmailTextBox" runat="server" CssClass="form-control mt-2" Placeholder="Buscar usuarios por nombre de usuario"></asp:TextBox>
        <asp:Button ID="SearchUserButton" runat="server" Text="Buscar" CssClass="btn btn-primary mt-2 mb-2" OnClick="SearchUserButton_Click" />
        

        <!-- GridView para usuarios -->
        <div class="table-responsive mt-4">
            <asp:GridView ID="UsersGrid" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="IdUsuario">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelectUser" runat="server" Text="Seleccionar" CommandName="Select" CssClass="btn btn-primary" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' onclick="btnSelectUser_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            Usuario seleccionado: <asp:TextBox ID="TextBoxUsuarioSeleccioado" runat="server" CssClass="form-control mt-2" enabled="false"></asp:TextBox>
        </div>
        
        
        <hr />

        <!-- Sección de inscripciones a cursos -->
        <h3>Inscripciones a Cursos del Usuario</h3>
        <div class="table-responsive mt-4"> 
            <asp:GridView ID="UserCoursesGrid" runat="server"  CssClass="table" AutoGenerateColumns="false" DataKeyNames="IdInscripcion" >
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="FechaInscripcion" HeaderText="Fecha de Inscripción" DataFormatString="{0:d}" HtmlEncode="false" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" DataFormatString="{0:d}" HtmlEncode="false" />
                    <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Finalizacion" DataFormatString="{0:d}" HtmlEncode="false" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnUnsubscribeCourse" runat="server" Text="Desinscribir" CssClass="btn btn-danger" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnUnsubscribeCourse_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        

        <hr />

        <!-- Sección de inscripciones a carreras -->
        <h3>Inscripciones a Carreras del Usuario</h3>
        <div class="table-responsive mt-4">
            <asp:GridView ID="UserCareersGrid" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="IdInscripcion">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="FechaInscripcion" HeaderText="Fecha de Inscripción" DataFormatString="{0:d}" HtmlEncode="false" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnUnsubscribeCareer" runat="server" Text="Desinscribir" CssClass="btn btn-danger" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnUnsubscribeCareer_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
