<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrace.aspx.cs" Inherits="WebovaAplikace.Registrace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zaregistrovat se</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="header-text">
                Restaurace
            </div>
        </div>
        <div class="sekce-registrace-udaje">
            Přístup k účtu
            <br />
            <asp:Label ID="Label5" runat="server" Text="Email: "></asp:Label><div class="registrace-input"><asp:TextBox ID="emailTB" runat="server" Width="165px"></asp:TextBox></div>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Heslo: "></asp:Label><div class="registrace-input"><asp:TextBox ID="hesloTB" runat="server" TextMode ="Password"></asp:TextBox></div>
            <br />
            <br />
            Osobní údaje
            <br />
            <asp:Label ID="Label1" runat="server" Text="Jméno: "></asp:Label><div class="registrace-input"><asp:TextBox ID="jmenoTB" runat="server"></asp:TextBox></div>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Příjmení: "></asp:Label><div class="registrace-input"><asp:TextBox ID="prijmeniTB" runat="server"></asp:TextBox></div>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Adresa: "></asp:Label><div class="registrace-input"><asp:TextBox ID="adresaTB" runat="server" Width="208px"></asp:TextBox></div>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Telefonní číslo: "></asp:Label><div class="registrace-input"><asp:TextBox ID="telefonniCisloTB" runat="server"></asp:TextBox></div>
            <br />
            <asp:Button class="button-style" style="margin-left: 120px;" ID="vytvoritUcetButton" runat="server" Text="Vytvořit účet" OnClick="vytvoritUcetButton_Click" />
        </div>
        <br />
        <div class="registrace-info"><asp:Label ID="infoText" runat="server" Text=""></asp:Label></div>
    </form>
</body>
</html>
