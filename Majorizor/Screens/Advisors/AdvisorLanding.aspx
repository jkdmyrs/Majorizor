<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="AdvisorLanding.aspx.cs" Inherits="Majorizor.Screens.Advisors.AdvisorLanding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    <asp:PlaceHolder ID="error_box" runat="server"></asp:PlaceHolder>
    <h1>Advisor Portal</h1>
    <asp:PlaceHolder ID="AdviseeInfo_PlcHldr" runat="server"></asp:PlaceHolder>
</asp:Content>
