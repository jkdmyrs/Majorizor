<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="AdminLanding.aspx.cs" Inherits="Majorizor.UserGroups.Admins.AdminLanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
    <!-- plugins -->
    <link rel="stylesheet" type="text/css" href="/Content/dataTables.bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/Content/fileinput.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">

    <h1>Admin Portal</h1>

    <!-- Panels -->
    <div class="panel panel-primary">
        <div class="panel-heading">Master Schedule Import</div>
        <div class="panel-body">
            <input type="file" class="file" data-show-upload="false" data-show-preview="false" id="scheduleUpload" runat="server" />
            <br />
            <asp:Button ID="uploadBtn" runat="server" Text="Upload" OnClick="upload_Btn_Click" class="btn btn-primary"/>
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">User Management</div>
        <div class="panel-body">
            <h3>User Management</h3>
            Search for users by Name or Email

            <!--TODO:
                - Fill this table with all users. 
                - Fill UserGroup dropdown list with 3 user groups. Select correct user group
                - Setup delete button to delete user.
                -->

            <table id="userTable" class="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Email</th>
                        <th>User Group</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Jackson DeMeyers</td>
                        <td>demeyejg@clarkson.edu</td>
                        <td><asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>
                        <td><a href="#"><span class="glyphicon glyphicon-remove" data-toggle="tooltip" title="Delete User"></span></a></td>
                    </tr>
                    <tr>
                        <td>Frank Ocean</td>
                        <td>frank@ocean.com</td>
                        <td><asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList></td>
                        <td><a href="#"><span class="glyphicon glyphicon-remove" data-toggle="tooltip" title="Delete User" ></span></a></td>
                    </tr>
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
