<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpravaProfilu.aspx.cs" Inherits="WebovaAplikace.SpravaProfilu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upravit profil</title>
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
        <div class="sprava-profilu-udaje">
            Přístup k účtu
            <br />
            <asp:Label ID="Label5" runat="server" Text="Email: "></asp:Label><asp:TextBox ID="emailTB" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Současné heslo: "></asp:Label><asp:TextBox ID="soucasneHesloTB" runat="server" TextMode ="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Nové heslo: "></asp:Label><asp:TextBox ID="noveHesloTB" runat="server" TextMode ="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Nové heslo (potvrzení): "></asp:Label><asp:TextBox ID="noveHesloPotvrzeniTB" runat="server" TextMode ="Password"></asp:TextBox>
            <br />
            Pro změnu hesla je nutné zadat současné heslo a pak pro potvrzení dvakrát nové heslo. Nové heslo musí obsahovat alespoň 5 znaků.
            <br />
            <br />
            Osobní údaje
            <br />
            <asp:Label ID="Label1" runat="server" Text="Jméno: "></asp:Label><asp:TextBox ID="jmenoTB" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Příjmení: "></asp:Label><asp:TextBox ID="prijmeniTB" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Adresa: "></asp:Label><asp:TextBox ID="adresaTB" runat="server" Width="208px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Telefonní číslo: "></asp:Label><asp:TextBox ID="telefonniCisloTB" runat="server"></asp:TextBox>
            <br />
            <asp:Button class="button-style" ID="ulozitZmeny" runat="server" Text="Uložit změny" OnClick="ulozitZmeny_Click" />
        </div>
        <div class="vymazat-button">
             <asp:Button class="button-style" ID="vymazatUcet" runat="server" Text="Vymazat účet" OnClick="vymazatUcet_Click"/>
        </div>
        <div class="sprava-profilu-info">
            <asp:Label ID="infoText" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
