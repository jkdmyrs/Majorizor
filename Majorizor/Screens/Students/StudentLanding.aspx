<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="StudentLanding.aspx.cs" Inherits="Majorizor.Screens.Students.StudentLanding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    <asp:PlaceHolder ID="error_box" runat="server"></asp:PlaceHolder>

    <h1>Student Portal</h1>
    <h2 id="studentGreeting" runat="server"></h2>

    <div class="panel panel-primary">
        <div class="panel-heading">Student Profile</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <h4>Name: </h4><asp:Label ID="label_name" runat="server"></asp:Label>
                    <h4>Advisor Name: </h4><asp:Label ID="label_advisor" runat="server"></asp:Label>
                </div>
                <div class="col-md-4">
                    <h4>Year: </h4><asp:Label ID="label_year" runat="server"></asp:Label>
                    <h4>Expected Graduation: </h4><asp:Label ID="label_graduation" runat="server"></asp:Label>
                </div>
                <div class="col-md-4">
                    <h4>Majors: </h4><asp:Label ID="label_majors" runat="server"></asp:Label>
                    <h4>Minors: </h4><asp:Label ID="label_minors" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    
    <div class="panel panel-primary">
        <div class="panel-heading">Schedule Information</div>
            <asp:Button CssClass="btn btn-primary" ID="button_viewSemesterSchedule" runat="server" Text="View Semester Schedule" OnClick="button_viewSchedule_Click"  />
            <asp:Button CssClass="btn btn-primary" ID="button_viewCurriculum" runat="server" Text="View Curriculum Outline" OnClick="button_viewCurriculum_Click"  />
        <div class="panel-body">
        </div>
    </div>
    
    <div class="panel panel-primary">
        <div class="panel-heading">Progress</div>
        
        <div class="panel-body">
        </div>
    </div>
    
    <div class="panel panel-primary">
        <div class="panel-heading">Change Major/Minor</div>
        <div class="panel-body">
            <!-- Just have a button that redirects to selection page -->
        </div>
    </div>

</asp:Content>
