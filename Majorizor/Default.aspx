<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Majorizor.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">

    <div class="jumbotron text-center">
        <img src="img/logo.png" style="height: 130px" />
        <br /><br />
        <p class="lead">Designed for Students and Advisors to easily manage multiple Majors and Minors</p>
        <a class="btn btn-lg btn-primary" href="Login.aspx" role="button">Login or Register!</a>
    </div>

          <div class="row marketing">
        <div class="col-lg-6">
          <h3>Manage Majors and Minors</h3>
          <p>Majorizor allows you to select up to 2 majors and 2 minors at a time, and provides a simple UI to manage them.</p>

          <h3>Track Progress</h3>
          <p>Easily track your progress through your different degrees while seeing your completed and required courses for each.</p>
        </div>

        <div class="col-lg-6">
          <h3>Create Schedules</h3>
          <p>Majorizor can help you create and manage your schedule for the upcoming semesters.</p>

          <h3>Advising</h3>
          <p>Majorizor allows Advisors to add you to their groups, making it easy for them to track your progress and help you manage your degrees.</p>
        </div>
      </div>

</asp:Content>
