<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="SelectAdvisees.aspx.cs" EnableViewState="true" Inherits="Majorizor.Screens.Advisors.SelectAdvisees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    
    <asp:PlaceHolder ID="error_box" runat="server"></asp:PlaceHolder>
    
    <h1>Select Advisees</h1>

    <div class="panel panel-primary">
        <div class="panel-heading">Select Advisees</div>
        <div class="panel-body">
            <p>Use this panel to select which students you would like to see on your landing page.</p>

            <h3>Current Advisees</h3>
            <table id="addTable" class="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Year</th>
                        <th>Graduation</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repeater_current" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label runat="server" Text='<%# Eval("firstName").ToString() + " " + Eval("lastName").ToString() %>'></asp:Label></td>
                                <td><asp:Label runat="server" Text='<%# Eval("year") %>'></asp:Label></td>
                                <td><asp:Label runat="server" Text='<%# Eval("graduation") %>'></asp:Label></td>
                                <td><asp:Button CssClass="btn btn-primary" ID="button_remove" runat="server" Text="Remove" OnClick="button_remove_Click"/></td>
                                <asp:HiddenField ID="curr_hiddenID" runat="server" Value='<%# Eval("userID") %>' />
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

            <h3>Add Advisees</h3>
            <table id="currTable" class="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Year</th>
                        <th>Graduation</th>
                        <th>Add</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repeater_add" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label runat="server" Text='<%# Eval("firstName").ToString() + " " + Eval("lastName").ToString() %>'></asp:Label></td>
                                <td><asp:Label runat="server" Text='<%# Eval("year") %>'></asp:Label></td>
                                <td><asp:Label runat="server" Text='<%# Eval("graduation") %>'></asp:Label></td>
                                <td><asp:Button CssClass="btn btn-primary" ID="button_add" runat="server" Text="Add" OnClick="button_add_Click"/></td>
                                <asp:HiddenField ID="add_hiddenID" runat="server" Value='<%# Eval("userID") %>' />
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainMaster_Scripts" runat="server">
    <!-- plugins -->
    <script src="/Scripts/jquery.dataTables.min.js"></script>
    <script src="/Scripts/dataTables.bootstrap.min.js"></script>
    <script src="/Scripts/fileinput.min.js"></script>
    <!-- setup tables -->
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $('#addTable').DataTable();

            $('[data-toggle="tooltip"]').tooltip();
        });
        $(document).ready(function () {
            $('#currTable').DataTable();

            $('[data-toggle="tooltip"]').tooltip();
        });
	</script>
</asp:Content>
