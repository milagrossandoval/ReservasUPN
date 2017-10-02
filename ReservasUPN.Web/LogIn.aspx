<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ReservasUPN.Web.LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio de Sesión</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:MultiView ID="MvLogin" runat="server" ActiveViewIndex=0 >
            <asp:View ID="ViewLoad" runat="server">
            </asp:View>
            <asp:View ID="ViewError" runat="server">
            <!-- Dar estilo para mostrar el error -->
            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
