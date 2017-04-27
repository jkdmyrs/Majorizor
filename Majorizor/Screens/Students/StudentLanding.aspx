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
        <div class="panel-body">
            <div class="row">
                <div class="col-md-8">

                </div>
                <div class="col-md-4">
                    <h4>View Scheudle History: </h4>
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="button_viewSemesterSchedule" runat="server" Text="View Semester Schedule" OnClick="button_viewSchedule_Click" />
                    <h4>View Curriculum Outline: </h4>
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="button_viewCurriculum" runat="server" Text="View Curriculum Outline" OnClick="button_viewCurriculum_Click"  />
                </div>
            </div>
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
            <h3>Select Majors</h3>
            <div class="row">
                <div class="col-md-8">
                    <div class ="row">
                        <label class="control-label col-md-2">Major 1:</label>
                        <div class="col-md-10"><asp:TextBox ID="TextBox1" runat="server" Width="100%" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                    </div>
                </div>
                <div class="col-md-4">
                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-secondary">
                                <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Drop Major"></span>
                            </asp:LinkButton>
                    <input type="button" class="btn btn-primary btn-sm" value="Add" />
                </div>
            </div>

            <br />
            <div class="row">
                <div class="col-md-8">
                    <div class ="row">
                        <label class="control-label col-md-2">Major 2:</label>
                        <div class="col-md-10"><asp:TextBox ID="TextBox2" runat="server" Width="100%" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                    </div>
                </div>
                <div class="col-md-4">
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-secondary">
                                <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Drop Major"></span>
                            </asp:LinkButton>
                    <input type="button" class="btn btn-primary btn-sm" value="Add" />
                </div>
            </div>
                
            <hr />
                    <h3>Select Minors</h3>
                    <div class="row">
                        <div class="col-md-8">
                            <div class ="row">
                                <label class="control-label col-md-2">Minor 1:</label>
                                <div class="col-md-10"><asp:TextBox ID="TextBox3" runat="server" Width="100%" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-secondary">
                                <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Drop Minor"></span>
                            </asp:LinkButton>
                            <input type="button" class="btn btn-primary btn-sm" value="Add" />
                        </div>
                    </div>

                    <br />
                    <div class="row">
                        <div class="col-md-8">
                            <div class ="row">
                                <label class="control-label col-md-2">Minor 2:</label>
                                <div class="col-md-10"><asp:TextBox ID="TextBox4" runat="server" Width="100%" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-secondary">
                                <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Drop Minor"></span>
                            </asp:LinkButton>
                            <input type="button" class="btn btn-primary btn-sm" value="Add" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
