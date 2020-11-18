﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistrationUsingStored.aspx.cs" Inherits="DataListExample.StudentRegistrationUsingStored" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-3.5.1.intellisense.js">

      
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="label0" runat="server" Text="Student Registration" BackColor="Yellow" ForeColor="#FF66CC"></asp:Label>
            <br />
            <br />

            <asp:Label ID="label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="name" runat="server" Width="113px" MaxLength="25"></asp:TextBox>

            <asp:Label ID="label2" runat="server" Text="Mobile"></asp:Label>
            <asp:TextBox ID="mobile" runat="server" MaxLength="10"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="mobile" ErrorMessage="Please Enter Valid Mobile Number" BackColor="Red"
                ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="label3" runat="server" Text="Class"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="128px">
                <asp:ListItem>-----</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="label4" runat="server" Text="Year"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" Height="29px" Width="144px" Style="margin-left: 16px">
                <asp:ListItem>-----</asp:ListItem>
                <asp:ListItem>2000-2001</asp:ListItem>
                <asp:ListItem>2001-2002</asp:ListItem>
                <asp:ListItem>2002-2003</asp:ListItem>
                <asp:ListItem>2003-2004</asp:ListItem>
                <asp:ListItem>2020-2021</asp:ListItem>
            </asp:DropDownList>
            <br />

        </div>
        <br />
        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
        <asp:Button ID="Button1" runat="server" Text="Submit" Style="margin-left: 103px" Width="81px" OnClick="Button1_Click" />
        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
        <asp:Button ID="Button2" runat="server" Text="Clear" Style="margin-left: 0px" Width="73px" OnClick="Button2_Click" />

        <br />
        <asp:Label ID="id1" runat="server" Text="" Visible="false" />

        <asp:Label ID="showOnSuccess" runat="server" Text="" Visible="false" BackColor="GreenYellow"></asp:Label>
        <hr color="red" size="5" width='100%' />



        <p>
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>

        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <br />
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" BorderColor="Yellow" BackColor="#FFCCFF" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>


                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do You Want to delete?');" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField ButtonType="Link"
                        CommandName="Edit"
                        Text="Edit" />
                    <asp:BoundField DataField="ID" HeaderText="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Class" HeaderText="Class" />
                    <asp:BoundField DataField="Year" HeaderText="Year" />

                </Columns>
                <PagerSettings FirstPageText="First" PageButtonCount="5" LastPageText="Last" Mode="NumericFirstLast" />
            </asp:GridView>

        </div>
    </form>
</body>
</html>
