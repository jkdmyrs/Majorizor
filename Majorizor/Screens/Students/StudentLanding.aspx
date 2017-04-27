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
                        <div class="col-md-10"><asp:TextBox ID="text_major1" runat="server" Width="100%" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                    </div>
                </div>
                <div class="col-md-4">
                        <asp:LinkButton ID="btn_dropMajor1" runat="server" CssClass="btn btn-secondary" OnClick="btn_dropMajor1_Click">
                            <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Drop Major"></span>
                        </asp:LinkButton>
                    <button type="button" runat="server" id="btn_addMajor1" class="btn btn-primary btn-sm" value="Add" data-toggle="modal" data-target="#addMajorModal">Add</button>
                </div>
            </div>

            <br />
            <div class="row">
                <div class="col-md-8">
                    <div class ="row">
                        <label class="control-label col-md-2">Major 2:</label>
                        <div class="col-md-10"><asp:TextBox ID="text_major2" runat="server" Width="100%" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                    </div>
                </div>
                <div class="col-md-4">
                        <asp:LinkButton ID="btn_dropMajor2" runat="server" CssClass="btn btn-secondary" OnClick="btn_dropMajor2_Click">
                            <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Drop Major"></span>
                        </asp:LinkButton>
                    <button type="button" runat="server" id="btn_addMajor2"  class="btn btn-primary btn-sm" value="Add" data-toggle="modal" data-target="#addMajorModal">Add</button>
                </div>
            </div>
                
            <hr />

            <h3>Select Minors</h3>
            <div class="row">
                <div class="col-md-8">
                    <div class ="row">
                        <label class="control-label col-md-2">Minor 1:</label>
                        <div class="col-md-10"><asp:TextBox ID="text_minor1" runat="server" Width="100%" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                    </div>
                </div>
                <div class="col-md-4">
                    <asp:LinkButton ID="btn_dropMinor1" runat="server" CssClass="btn btn-secondary" OnClick="btn_dropMinor1_Click">
                        <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Drop Minor"></span>
                    </asp:LinkButton>
                    <button type="button" runat="server" id="btn_addMinor1"  class="btn btn-primary btn-sm" value="Add" data-toggle="modal" data-target="#addMinorModal">Add</button>
                </div>
            </div>

            <br />
            <div class="row">
                <div class="col-md-8">
                    <div class ="row">
                        <label class="control-label col-md-2">Minor 2:</label>
                        <div class="col-md-10"><asp:TextBox ID="text_minor2" runat="server" Width="100%" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                    </div>
                </div>
                <div class="col-md-4">
                    <asp:LinkButton ID="btn_dropMinor2" runat="server" CssClass="btn btn-secondary" OnClick="btn_dropMinor2_Click">
                        <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Drop Minor"></span>
                    </asp:LinkButton>
                    <button type="button" runat="server" id="btn_addMinor2"  class="btn btn-primary btn-sm" data-toggle="modal" data-target="#addMinorModal">Add</button>
                </div>
            </div>
        </div>
    </div>
    
    <!-- Modal - Add Major -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="modal fade" id="addMajorModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header"><h2>Add Major</h2></div>
                <div class="modal-body">
                    <h3>Select New Major: </h3>
                    <asp:DropDownList ID="ddl_majors" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl_majors_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal - Add Minor -->

    <div class="modal fade" id="addMinorModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header"><h2>Add Major</h2></div>
                <div class="modal-body">
                    <h3>Select New Minor: </h3>
                    <asp:DropDownList ID="ddl_minors" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl_minors_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
