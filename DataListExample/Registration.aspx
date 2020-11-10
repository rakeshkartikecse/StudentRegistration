<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DataListExample.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="RegI" runat="server" Text="Registration Form"></asp:Label>
        <table>
            <tr>
                <td>First Name:</td>
            <td><asp:TextBox ID="fname" runat="server" Text="First Name"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="validfname" runat="server" ControlToValidate="fname" ErrorMessage="Please Enter" ForeColor="#ff0066"></asp:RequiredFieldValidator></td>

            </tr>
            <tr>
                <td>Last Name:</td>
            <td><asp:TextBox ID="lname" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredField1" runat="server" ControlToValidate="lname" ErrorMessage="Please Enter" ForeColor="#ff0066"></asp:RequiredFieldValidator></td>

            </tr>
            

<tr>
                <td>Mobile:</td>
            <td><asp:TextBox ID="mobile" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="mobile" ErrorMessage="Please Enter" ForeColor="#ff0066"></asp:RequiredFieldValidator></td>

            </tr>        

            <tr>
                <td>Email:</td>
            <td><asp:TextBox ID="email" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="email" ErrorMessage="Please Enter" ForeColor="#ff0066"></asp:RequiredFieldValidator></td>

            </tr>
            <tr>
                <td>Password:</td>
            <td><asp:TextBox ID="password" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password" ErrorMessage="Please Enter" ForeColor="#ff0066"></asp:RequiredFieldValidator></td>

            </tr>
            <tr>
                <td>Confirm Password:</td>
            <td><asp:TextBox ID="passwordConf" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="passwordConf" ErrorMessage="Please Enter" ForeColor="#ff0066"></asp:RequiredFieldValidator></td>

            </tr>

        </table>
        
        
    </div>
        <asp:Button ID="btn" runat="server" Text="Submit" OnClick="btn_Click"/>
    
    <br />
    <br />
    <asp:Label ID="loginLabel" runat="server" Text="Registered User, Then Login Here" BackColor="YellowGreen"></asp:Label>
    <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click"/>
        </form>
</body>
</html>
