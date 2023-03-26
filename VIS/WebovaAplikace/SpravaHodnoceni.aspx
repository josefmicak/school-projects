<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpravaHodnoceni.aspx.cs" Inherits="WebovaAplikace.SpravaHodnoceni" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vytvoření hodnocení</title>
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
        <div class="vytvoreni-hodnoceni-panel">
            <div style="margin-left:-50%;">
            Podávate hodnocení na zaměstnance <asp:Label ID="jmenoZamestnance" runat="server" Text=""></asp:Label> týkající se objednávky vytvořené v
            <asp:Label ID="datumVytvoreni" runat="server" Text=""></asp:Label> s hodnotou <asp:Label ID="cenaObjednavky" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Vytvoření hodnocení" Font-Bold="True"></asp:Label>
            <br />
            Hodnocení (1 - 10): <asp:TextBox ID="hodnoceniTB" runat="server" TextMode="Number" value="10" min="0" max="10" step="1" Font-Size="25px"></asp:TextBox>
            <br />
            <asp:Button class="button-style" ID="odeslatHodnoceni" runat="server" Text="Odeslat hodnocení" OnClick="odeslatHodnoceni_Click" />
        </div>
        <div class="seznam-hodnoceni">
            <asp:Label ID="Label2" runat="server" Text="Seznam hodnocení" Font-Bold="True"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="datumVytvoreni" HeaderText="Datum vytvoření" ReadOnly="True" SortExpression="datumVytvoreni" />
                    <asp:BoundField DataField="zamestnanec" HeaderText="Zaměstnanec" ReadOnly="True" SortExpression="zamestnanec" />
                    <asp:BoundField DataField="hodnoceni" HeaderText="Hodnocení" ReadOnly="True" SortExpression="hodnoceni" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="hodnoceniNenalezena" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
