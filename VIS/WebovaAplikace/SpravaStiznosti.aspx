<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpravaStiznosti.aspx.cs" Inherits="WebovaAplikace.SpravaStiznosti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vytvoření stížnosti</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
        <div class="header">
            <div class="header-text">
                <asp:LinkButton ID="menuLink" runat="server" ForeColor="White" OnClick="menuLink_Click">Restaurace</asp:LinkButton>
            </div>
        </div>
        </div>
        <div class="profil-panel">
            <asp:Label ID="welcomeText" runat="server" Text=""></asp:Label>
            <br />
            <asp:LinkButton ID="profilLink" runat="server" ForeColor="White" OnClick="profilLink_Click">Upravit profil</asp:LinkButton>
        </div>
        <div class="vytvoreni-stiznosti-panel">
            <div style="margin-left:-45%;">
            Podávate stížnost na zaměstnance <asp:Label ID="jmenoZamestnance" runat="server" Text=""></asp:Label> týkající se objednávky vytvořené v
            <asp:Label ID="datumVytvoreni" runat="server" Text=""></asp:Label> s hodnotou <asp:Label ID="cenaObjednavky" runat="server" Text=""> Kč</asp:Label>
            </div>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Vytvoření stížnosti" Font-Bold="True"></asp:Label>
            <br />
            Typ stížnosti : <asp:DropDownList ID="typStiznostiDDL" runat="server" Font-Size="25px"></asp:DropDownList>
            <br />
            <asp:Button class="button-style" ID="odeslatStiznost" runat="server" Text="Odeslat stížnost" OnClick="odeslatStiznost_Click" />
        </div>
        <div class="seznam-stiznosti">
            <asp:Label ID="Label2" runat="server" Text="Seznam stížností" Font-Bold="True"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="datumVytvoreni" HeaderText="Datum vytvoření" ReadOnly="True" SortExpression="datumVytvoreni" />
                    <asp:BoundField DataField="zamestnanec" HeaderText="Zaměstnanec" ReadOnly="True" SortExpression="zamestnanec" />
                    <asp:BoundField DataField="typStiznosti" HeaderText="Typ stížnosti" ReadOnly="True" SortExpression="typStiznosti" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="stiznosti-info">
            <asp:Label ID="stiznostiNenalezeny" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
