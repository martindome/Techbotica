<%@ Page Title="Confirmacion Inscripcion Carrera" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionInscripcionCarrera.aspx.cs" Inherits="WebApplication1.Carreras.ConfirmacionInscripcionCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Confirmación de Inscripción</h2>
        <div class="row">
            <div class="col-md-12">
                <!-- Mensaje de confirmación -->
                <div style="background-color: #b8daff; padding: 20px; margin-bottom: 20px; border-radius: 5px;">
                    <h3>Felicidades!</h3>
                    <p>Has sido inscrito exitosamente en la carrera: <asp:Label ID="lblCareerName" runat="server" Text=""></asp:Label>. Tu número de inscripción es: <asp:Label ID="lblInscriptionNumber" runat="server" Text=""></asp:Label></p>
                </div>
                
                <!-- Botón para seguir buscando carreras -->
                <div class="form-group mt-4">
                    <asp:Button ID="btnKeepSearching" CssClass="btn btn-primary" Text="Seguir Buscando Carreras" runat="server" onclick="btnKeepSearching_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
