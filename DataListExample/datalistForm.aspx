﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datalistForm.aspx.cs" Inherits="DataListExample.datalistForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DataList ID="DataList1" runat="server">  
            <ItemTemplate>  
                <table cellpadding="2" cellspacing="0" border="1" style="width: 300px; height: 100px;   
                border: dashed 2px #04AFEF; background-color: #FFFFFF">  
                    <tr>  
                        <td>  
                            <b>ID: </b><span class="city"><%# Eval("ID") %></span><br />  
                            <b>Name: </b><span class="postal"><%# Eval("Name") %></span><br />  
                            <b>Email: </b><span class="country"><%# Eval("Email")%></span><br />  
                        </td>  
                    </tr>  
                </table>  
            </ItemTemplate>  
        </asp:DataList>  

    </div>
    </form>
</body>
</html>
