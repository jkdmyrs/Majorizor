<%@ Page Title="" Language="C#" MasterPageFile="~/Majorizor.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Majorizor.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
        <ul class="nav nav-tabs">
		    <li class="active"><a  href="#1" data-toggle="tab">Login</a></li>
		    <li><a href="#2" data-toggle="tab">Register</a></li>
	    </ul>

	    <div class="tab-content">
		    <div class="tab-pane active" id="1">
                <div class="container">
                    <h1>Login</h1>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email Address</label>
                            <div class="col-sm-4">
                                <input name="username_input" type="text" id="username_input" class="form-control" required="" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="password">Password</label>
                            <div class="col-sm-4">
                                <input name="password_input" type="password" id="password_input" class="form-control" required="" />
                            </div>
                        </div>

                        <div class="form-group"> 
                            <div class="col-sm-offset-2 col-sm-10">
                                <input type="submit" name="button_login" value="Login" id="button_login" class="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                    Not already a member? <a href="#2" data-toggle="tab">Register</a>
                </div>
		    </div>

		    <div class="tab-pane" id="2">
                <div class="container">
                    <h1>Register</h1>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="first name">First Name</label>
                            <div class="col-sm-4">
                                <input name="firstname_input" type="text" id="firstname_input" class="form-control" required="" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="last name">Last Name</label>
                            <div class="col-sm-4">
                                <input name="lastname_input" type="text" id="lastname_input" class="form-control" required="" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email Address</label>
                            <div class="col-sm-4">
                                <input name="email_input" type="text" id="email_input" class="form-control" required="" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="password">Password</label>
                            <div class="col-sm-4">
                                <input name="password1" type="password" id="password1" class="form-control" required="" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="password">Verify Password</label>
                            <div class="col-sm-4">
                                <input name="passwordVerify_input" type="password" id="passwordVerify_input" class="form-control" required="" />
                            </div>
                        </div>

                        <div class="form-group"> 
                            <div class="col-sm-offset-2 col-sm-10">
                                <input type="submit" name="button1" value="Register" id="button1" class="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
		    </div>
	    </div>

</asp:Content>
