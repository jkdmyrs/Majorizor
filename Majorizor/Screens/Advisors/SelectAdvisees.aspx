<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="SelectAdvisees.aspx.cs" Inherits="Majorizor.Screens.Advisors.SelectAdvisees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    <h1>Select Advisees</h1>
    
    <div class="panel panel-primary">
        <div class="panel-heading">Select Advisees</div>
        <div class="panel-body">
            <p>Use this panel to select students which you would like to appear on your landing page.</p>
            <asp:CheckBoxList ID="checkBoxList_advisees" runat="server"></asp:CheckBoxList>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Button CssClass="btn btn-primary" ID="button_save" runat="server" Text="Save" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainMaster_Scripts" runat="server">
</asp:Content>
