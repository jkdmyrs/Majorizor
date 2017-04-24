<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Majorizor.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainMaster_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMaster_MainContent" runat="server">
      <div class="container">
        <ul class="nav nav-tabs">
		    <li class="active"><a  href="#i1" data-toggle="tab">Login</a></li>
		    <li><a href="#i2" data-toggle="tab">Register</a></li>
	    </ul>
        
	    <div class="tab-content">
		    <div class="tab-pane active" id="i1">
            <asp:Panel runat="server" DefaultButton="button_login">
                <div class="container">
                    <h1>Login</h1>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email Address</label>
                            <div class="col-sm-4">
                                <input name="username_input" type="text" id="username_input" class="form-control"  runat="server"/>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="password">Password</label>
                            <div class="col-sm-4">
                                <input name="password_input" type="password" id="password_input" class="form-control"  runat="server"/>
                            </div>
                        </div>

                        <div class="form-group"> 
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button CssClass="btn btn-primary" ID="button_login" runat="server" Text="Login" OnClick="button_login_Click"  />
                            </div>
                            
                        </div>
                    </div>
                    Not already a member? <a href="#i2" data-toggle="tab">Register</a>
                </div>
            </asp:Panel>
		    </div>

		    <div class="tab-pane" id="i2">
                <asp:Panel runat="server" DefaultButton="button_register">
                <div class="container">
                    <h1>Register</h1>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="first name">First Name</label>
                            <div class="col-sm-4">
                                <input name="firstname_input" type="text" id="firstname_input" class="form-control" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="last name">Last Name</label>
                            <div class="col-sm-4">
                                <input name="lastname_input" type="text" id="lastname_input" class="form-control"   runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email Address</label>
                            <div class="col-sm-4">
                                <input name="email_input" type="text" id="email_input" class="form-control"  runat="server"  />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="password">Password</label>
                            <div class="col-sm-4">
                                <input name="password1" type="password" id="passwordRegister_input" class="form-control" runat="server"   />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="password">Verify Password</label>
                            <div class="col-sm-4">
                                <input name="passwordVerify_input" type="password" id="passwordVerify_input" class="form-control" runat="server"   />
                            </div>
                        </div>

                        <div class="form-group"> 
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button CssClass="btn btn-primary" ID="button_register" runat="server" Text="Register" OnClick="button_register_Click"/>
                            </div>
                        </div>
                    </div>
                    Already a member? <a href="#i1" data-toggle="tab">Login</a>
                </div>
                </asp:Panel>
		    </div>
	    </div>
      </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainMaster_Scripts" runat="server">
    <script type="text/javascript">
        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            var target = this.href.split('#');
            $('.nav a').filter('a[href="#' + target[1] + '"]').tab('show');
        //})
    </script>
</asp:Content>