<%@ Page Title="Confirmacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionInscripcion.aspx.cs" Inherits="WebApplication1.Cursos.ConfirmacionInscripcionCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Confirmación de Inscripción</h2>
        <div class="row">
            <div class="col-md-12">
                <!-- Mensaje de confirmación -->
                <div style="background-color: #b8daff; padding: 20px; margin-bottom: 20px; border-radius: 5px;">
                    <h3>Felicidades!</h3>
                    <p>Has sido inscrito exitosamente. Tu número de inscripción es: <asp:Label ID="lblInscriptionNumber" runat="server" Text=""></asp:Label></p>
                </div>
                
                <!-- Botón para seguir buscando cursos -->
                <div class="form-group mt-4">
                    <asp:Button ID="btnKeepSearching" CssClass="btn btn-primary" Text="Seguir Buscando" runat="server" OnClick="btnCursos_Click"/>
                    <asp:Button ID="Button1" CssClass="btn btn-primary" Text="Mis Inscripciones" runat="server" OnClick="btnInscripciones_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>