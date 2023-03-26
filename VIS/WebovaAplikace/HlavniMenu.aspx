<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HlavniMenu.aspx.cs" Inherits="WebovaAplikace.HlavniMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hlavní menu</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="header">
            <div class="header-text">
                <asp:LinkButton ID="menuLink" runat="server" ForeColor="White" OnClick="menuLink_Click">Restaurace</asp:LinkButton>
            </div>
        </div>
        <div class="profil-panel">
            <asp:Label ID="welcomeText" runat="server" Text=""></asp:Label>
            <br />
            <asp:LinkButton ID="profilLink" runat="server" ForeColor="White" OnClick="profilLink_Click">Upravit profil</asp:LinkButton>
        </div>
            
        <div class="sprava-objednavek-button">
            <asp:Button class="button-style" ID="objednavkyButton" runat="server" Text="Správa objednávek" OnClick="objednavkyButton_Click" />
        </div>
        <div class="hlavni-menu-info">
            <asp:Label ID="infoText" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
