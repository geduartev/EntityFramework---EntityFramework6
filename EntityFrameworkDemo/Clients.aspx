<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="IngenieriaGD.IGDDemo.Library.DAL.View.Clients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td>ID Cliente</td>
                <td>
                    <asp:TextBox ID="TextBoxIDClient" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Teléfono</td>
                <td>
                    <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Última lectura</td>
                <td>
                    <asp:TextBox ID="TextBoxReadLast" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Leído</td>
                <td>
                    <asp:CheckBox ID="CheckBoxReaded" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Guardar" />
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:GridView ID="GridViewClients" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
