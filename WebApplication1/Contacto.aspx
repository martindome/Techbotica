<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebApplication1.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css">

    <div>
        <h1 class="mb-4">Contacto</h1>

        <!-- Datos de Contacto -->
        <div>
            <h4>Teléfono:</h4>
            <p>+54 11 1234-5678</p>
            <h4>Dirección:</h4>
            <p>Av. de la Robotica 123, Buenos Aires, Argentina</p>
            <h4>Email:</h4>
            <p>contacto@techbotica.com.ar</p>
        </div>

        <!-- Redes Sociales -->
        <div>
            <h4>Síguenos en nuestras redes:</h4>
            <a href="https://www.facebook.com/techboticaficticio" target="_blank" class="mr-3"><i class="fab fa-facebook-f"></i></a>
            <a href="https://www.twitter.com/techboticaficticio" target="_blank" class="mr-3"><i class="fab fa-twitter"></i></a>
            <a href="https://www.instagram.com/techboticaficticio" target="_blank"><i class="fab fa-instagram"></i></a>
            <a href="https://www.instagram.com/techboticaficticio" target="_blank"><i class="fab fa-linkedin"></i></a>
        </div>
    </div>

    <!-- FontAwesome para íconos de redes sociales -->
</asp:Content>
