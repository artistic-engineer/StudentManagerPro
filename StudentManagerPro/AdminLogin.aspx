<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="StudentManagerPro.AdminLogin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/AdminLogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div id="sysTitle">
                <h1>Fancy Student Management System</h1>
            </div>
            <div class="signup-agileinfo">
			    <h3>Sign Up</h3>
			    <label class="bar-w3-agile"></label>
			    <p>Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...</p>
			    <h6>By creating an account, you agree to our <a href="#">Terms.</a></h6>
		    </div>
            <div class="signin-agile">
                <h2>Login</h2>
			    <label class="bar-w3-agile"></label>
                <asp:Literal ID="ltaInfo" runat="server"></asp:Literal>
                <div class="loginItem">
                    <p>Username</p>
                    <asp:TextBox ID="txtUserId" CssClass="loginItemText" runat="server"></asp:TextBox>
                </div>
                <div class="loginItem">
                    <p>Password</p>
                    <asp:TextBox ID="txtPwd" CssClass="loginItemText" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="loginItem">
                    <asp:ImageButton ID="ibtnLogin1" CssClass="submit"
                    runat="server" OnClick="ibtnLogin_Click" Height="91px" ImageUrl="~/Images/login.jpg" Width="305px"/>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtUserId" Display="None" ErrorMessage="请输入用户名!"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtPwd" Display="None" ErrorMessage="请输入密码!"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    ShowMessageBox="True" ShowSummary="False" Height="16px" />
            </div>
        </div>
    </form>
    <div class="footer-w3l">
        <p class="agileinfo"> &copy; Fancy Student Management System | Design by Sunny</p>
        <p class="agileinfo">Email: newzealandsunny@gmail.com</p>
	</div>
</body>
</html>
