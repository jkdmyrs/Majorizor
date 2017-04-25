<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="SetStudentInformation.aspx.cs" Inherits="Majorizor.Screens.Students.SetStudentInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
    <asp:PlaceHolder ID="error_box" runat="server"></asp:PlaceHolder>

    <h1>First Time Student Setup</h1>
    <div class="panel panel-primary">
        <div class="panel-heading">Basic Information</div>
        <div class="panel-body">
            <h2> Welcome to Majorizor</h2>
            <p>Please fill in the information below to begin setting up your Student Profile. </p>
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="year">Current Year</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="year_ddl" CssClass="form-control" runat="server">
                            <asp:ListItem Selected="True">Freshman</asp:ListItem>
                            <asp:ListItem>Sophomore</asp:ListItem>
                            <asp:ListItem>Junior</asp:ListItem>
                            <asp:ListItem>Senior</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-sm-2" for="graduation">Expected Graduation</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="graduation_ddl" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group"> 
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button CssClass="btn btn-primary" ID="button_update" runat="server" Text="Next" OnClick="button_update_Click" />
                    </div>     
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainMaster_Scripts" runat="server">
</asp:Content>
