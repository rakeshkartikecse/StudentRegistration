﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentReg.aspx.cs" Inherits="DataListExample.StudentReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <asp:Label ID="label0" runat="server" Text="Student Registration" BackColor="Yellow" ForeColor="#FF66CC"></asp:Label>
        <br />
        <br />
        
        <asp:Label ID="label1" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="name" runat="server" Width="113px"></asp:TextBox>

        <asp:Label ID="label2" runat="server" Text="Mobile"></asp:Label>
    <asp:TextBox ID="mobile" runat="server"></asp:TextBox>
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
        <asp:DropDownList ID="DropDownList2" runat="server" Height="29px" Width="144px" style="margin-left: 16px">
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
        <asp:Button ID="Button1" runat="server" Text="Submit" style="margin-left: 103px" Width="81px" OnClick="Button1_Click" /> 
        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
        <asp:Button ID="Button2" runat="server" Text="Clear" style="margin-left: 0px" Width="73px" OnClick="Button2_Click" />

    <hr  color=red size=5 width='100%' />

    

    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
<div>
    <asp:GridView ID="GridView1" runat="server" BorderColor="Yellow" BackColor="#FFCCFF" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"   OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames ="ID" OnRowEditing ="GridView1_RowEditing"                 
        OnRowCancelingEdit ="GridView1_RowCancelingEdit"    OnRowDeleting ="GridView1_RowDeleting"    OnRowUpdating = "GridView1_RowUpdating" >
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
            <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
            <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
        </Columns>
    </asp:GridView>
         </div>
    

    </form>

    
</body>
</html>
