<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="AdminLanding.aspx.cs" EnableViewState="true" Inherits="Majorizor.Screens.Admins.AdminLanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
    <!-- plugins -->
    <link rel="stylesheet" type="text/css" href="/Content/dataTables.bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/Content/fileinput.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    <asp:PlaceHolder ID="error_box" runat="server"></asp:PlaceHolder>

    <h1>Admin Portal</h1>

    <!-- Panels -->
    <div class="panel panel-primary">
        <div class="panel-heading">Master Schedule Import</div>
        <div class="panel-body">
            <input type="file" class="file" data-show-upload="false" data-show-preview="false" id="scheduleUpload" runat="server" />
            <br />
            <asp:Button ID="uploadBtn" runat="server" Text="Upload" OnClick="upload_Btn_Click" CssClass="btn btn-primary"/>
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">User Management</div>
        <div class="panel-body">
            <h3>User Management</h3>
            
            <table id="userTable" class="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Email</th>
                        <th>User Group</th>
                        <th>Change</th>
                        <th>Delete User</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater_Table" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label runat="server" Text='<%# Eval("firstName").ToString() + " " + Eval("lastName").ToString() %>'></asp:Label></td>
                                <td><asp:Label runat="server" Text='<%# Eval("email") %>'></asp:Label></td>
                                <td><asp:Label runat="server" Text='<%# Eval("userGroup") %>'></asp:Label></td>
                                <td>
                                    <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="userGroup_ItemChanged" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0"> <-UserGroup-> </asp:ListItem>
                                        <asp:ListItem Value="USER"> User </asp:ListItem>
                                        <asp:ListItem Value="ADVISOR"> Advisor </asp:ListItem>
                                        <asp:ListItem Value="ADMIN"> Admin </asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="deleteUser" runat="server" CssClass="btn btn-secondary" OnClick="deleteUser_Click">
                                        <span class ="glyphicon glyphicon-remove" data-toggle="tooltip" title="Delete User"></span>
                                    </asp:LinkButton>
                                </td>
                                <asp:HiddenField ID="hiddenID" runat="server" Value='<%# Eval("userID") %>' />
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainMaster_Scripts" runat="server">
    <!-- plugins -->
    <script src="/Scripts/jquery.dataTables.min.js"></script>
    <script src="/Scripts/dataTables.bootstrap.min.js"></script>
    <script src="/Scripts/fileinput.min.js"></script>

    <script type="text/javascript" charset="utf-8">
	    $(document).ready(function() {
	        $('#userTable').DataTable();

	        $('[data-toggle="tooltip"]').tooltip();
	    });
	</script>
</asp:Content>
