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
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">Select Minors</div>
        <div class="panel-body">
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainMaster_Scripts" runat="server">
</asp:Content>
