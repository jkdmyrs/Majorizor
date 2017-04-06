<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="AdvisorLanding.aspx.cs" Inherits="Majorizor.Screens.Advisors.AdvisorLanding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">

    <h1>Advisor Portal</h1>
    <!-- Panels for each student that is an advisee -->
    <!-- TODO - Acutally make this in the backend - USE HtmlTextWriter class -->

    <asp:PlaceHolder ID="AdviseeInfo_PlcHldr" runat="server"></asp:PlaceHolder>

</asp:Content>
