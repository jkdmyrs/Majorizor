<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="ScheduleCreation.aspx.cs" Inherits="Majorizor.Screens.Students.ViewSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    <h1>Schedule for Current Semester</h1>

    <div class="panel panel-primary" style="width: 50%">
        <div class="panel-heading">Fall Semester - Freshman Year</div>

        <div class="panel-body">
            <asp:Literal ID="course1" runat="server" Text="test" />
        </div>
        <div class="panel-body">
            <asp:Literal ID="course2" runat="server" Text="test" />
        </div>
        <div class="panel-body" id="enrolledClass3">
            <asp:Literal ID="course3" runat="server" Text="test" />
        </div>
        <div class="panel-body" id="enrolledClass4">
            <asp:Literal ID="course4" runat="server" Text="test" />
        </div>
        <div class="panel-body" id="enrolledClass5">
            <asp:Literal ID="course5" runat="server" Text="test" />
        </div>
        <br />
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainMaster_Scripts" runat="server">
</asp:Content>
