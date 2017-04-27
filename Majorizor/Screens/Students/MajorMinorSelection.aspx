<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="MajorMinorSelection.aspx.cs" Inherits="Majorizor.Screens.Students.MajorMinorSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    <asp:PlaceHolder ID="error_box" runat="server"></asp:PlaceHolder>
    <h1>Major and Minor Selection</h1>
    
    <div class="panel panel-primary">
        <div class="panel-heading">Select Majors</div>
        <div class="panel-body">
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
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">Select Minors</div>
        <div class="panel-body">
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

    <asp:Button CssClass="btn btn-primary" ID="btn_next" runat="server" Text="Next" OnClick="next_Click" />
    
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
<asp:Content ID="Content3" ContentPlaceHolderID="MainMaster_Scripts" runat="server">
</asp:Content>
