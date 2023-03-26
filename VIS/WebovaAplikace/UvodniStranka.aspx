<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UvodniStranka.aspx.cs" Inherits="WebovaAplikace.UvodniStranka" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Přihlásit se</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="header-text">
                Restaurace
            </div>
        </div>
        <div class="sekce-prihlaseni">
            Email: <asp:TextBox ID="emailTB" runat="server" Width="197px"></asp:TextBox>
            <br />
            Heslo: <asp:TextBox ID="hesloTB" runat="server" TextMode ="Password"></asp:TextBox>
            <br />
            <asp:Button class="button-style" ID="login" runat="server" Text="Přihlásit se" OnClick="login_Click" />
        </div>
        <div class="sekce-registrace">
            Nemáte účet?
            <br />
            <asp:Button class="button-style" ID="registraceButton" runat="server" Text="Zaregistrovat se" OnClick="registraceButton_Click" />
         </div>
        <div class="uvodni-info"><asp:Label ID="infoText" runat="server" Text=""></asp:Label></div>
    </form>
</body>
</html>
