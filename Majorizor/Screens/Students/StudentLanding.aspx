<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="StudentLanding.aspx.cs" Inherits="Majorizor.Screens.Students.StudentLanding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    <h1>Student Portal</h1>
    <h2 id="studentGreeting" runat="server"></h2>

    <div class="panel panel-primary">
        <div class="panel-heading">Student Information</div>
        <div class="panel-body">
            <input type="file" class="file" data-show-upload="false" data-show-preview="false" id="scheduleUpload" runat="server" />
            <br />
            <asp:Button ID="uploadBtn" runat="server" Text="Upload" OnClick="upload_Btn_Click" class="btn btn-primary"/>
        </div>
    </div>
</asp:Content>
