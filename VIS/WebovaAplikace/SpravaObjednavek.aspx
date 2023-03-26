<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpravaObjednavek.aspx.cs" Inherits="WebovaAplikace.SpravaObjednavek" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vytvoření objednávky</title>
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

        <div class="sprava-objednavek-info">
            <asp:Label ID="infoText" runat="server" Text=""></asp:Label>
        </div>

        <div class="menu-panel"> 
          <asp:Label ID="hlavniJidlaLabel" runat="server" Text="Hlavní jídla"></asp:Label>
          <div class="row">
              <div class="column">
                   <div class="polozka">
                       <asp:Image ID="menuPizza" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/pizza.jpg" Width="109px" /><br />
                       Pizza, 400 g<br />
                       149 Kč<br />
                       <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton1" runat="server" Text="Přidat" CommandName="1" OnClick="pridaniPolozky" />
                   </div>
               </div>
               <div class="column">
                  <div class="polozka">
                        <asp:Image ID="menuKureciKridla" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/kureci-kridla.jpg" Width="109px" /><br />
                        Kuřecí křídla, 150 g<br />
                        139 Kč<br />
                        <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton2" runat="server" Text="Přidat" CommandName="2" OnClick="pridaniPolozky"  />
                  </div>
               </div>
               <div class="column">
                  <div class="polozka">
                        <asp:Image ID="menuHamburger" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/hamburger.jpg" Width="109px" /><br />
                        Hovězí hamburger, 150 g<br />
                        169 Kč<br />
                        <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton3" runat="server" Text="Přidat" CommandName="3" OnClick="pridaniPolozky"  />
                  </div>
               </div>
            </div>

          <asp:Label ID="Label3" runat="server" Text="Přílohy"></asp:Label>
          <div class="row">
              <div class="column">
                   <div class="polozka">
                       <asp:Image ID="Image1" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/hranolky.jpg" Width="109px" /><br />
                       Hranolky, 200 g<br />
                       55 Kč<br />
                       <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton4" runat="server" Text="Přidat" CommandName="4" OnClick="pridaniPolozky" />
                   </div>
               </div>
               <div class="column">
                  <div class="polozka">
                        <asp:Image ID="Image2" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/krokety.jpg" Width="109px" /><br />
                        Krokety, 200 g<br />
                        55 Kč<br />
                        <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton5" runat="server" Text="Přidat" CommandName="5" OnClick="pridaniPolozky"  />
                  </div>
               </div>
               <div class="column">
                  <div class="polozka">
                        <asp:Image ID="Image3" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/salat.jpg" Width="109px" /><br />
                        Zeleninový salát, 100 g<br />
                        55 Kč<br />
                        <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton6" runat="server" Text="Přidat" CommandName="6" OnClick="pridaniPolozky"  />
                  </div>
               </div>
            </div>

          <asp:Label ID="Label4" runat="server" Text="Nápoje"></asp:Label>
          <div class="row">
              <div class="column">
                   <div class="polozka">
                       <asp:Image ID="Image7" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/pepsi.jpg" Width="109px" /><br />
                       Pepsi plechovka, 0,55l<br />
                       30 Kč<br />
                       <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton7" runat="server" Text="Přidat" CommandName="7" OnClick="pridaniPolozky" />
                   </div>
               </div>
               <div class="column">
                  <div class="polozka">
                        <asp:Image ID="Image8" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/sprite.jpg" Width="109px" /><br />
                        Sprite plechovka, 0,55l<br />
                        30 Kč<br />
                        <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton8" runat="server" Text="Přidat" CommandName="8" OnClick="pridaniPolozky"  />
                  </div>
               </div>
               <div class="column">
                  <div class="polozka">
                        <asp:Image ID="Image9" runat="server" BorderStyle="Solid" Height="110px" ImageUrl="~/Resources/radegast.jpg" Width="109px" /><br />
                        Radegast plechovka, 0,55l<br />
                        30 Kč<br />
                        <asp:Button class="button-style" style="font-size: 15px;margin-top: -2px;" ID="pridatButton9" runat="server" Text="Přidat" CommandName="9" OnClick="pridaniPolozky"  />
                  </div>
               </div>
            </div>
         </div>

        <div class="soucasna-objednavka">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnDataBound="GridView2_DataBound" OnRowCommand="GridView2_RowCommand">
                <Columns>
                    <asp:BoundField DataField="polozka" HeaderText="Položka" SortExpression="polozka" />
                    <asp:BoundField DataField="cena" HeaderText="Cena" SortExpression="cena" />
                    <asp:ButtonField CommandName="odebrat" HeaderText="Odebrat" ShowHeader="True" Text="Odebrat položku"/>
                </Columns>
            </asp:GridView>
        </div>

        <div class="vytvoreni-objednavky-panel"> 
            <asp:Label ID="Label1" runat="server" Text="Vytvoření objednávky" Font-Bold="True"></asp:Label>
            <br />
            <asp:Label ID="cenaObjednavkyLabel" runat="server" Text="Cena objednávky: 0 Kč"></asp:Label>
            <br />
            <asp:Button class="button-style" ID="vytvoritObjednavkuButton" runat="server" Text="Vytvořit objednávku" Height="45px" OnClick="vytvoritObjednavkuButton_Click" Width="326px" />
        </div>

        <div class="seznam-objednavek">
            <asp:Label ID="Label2" runat="server" Text="Seznam objednávek" Font-Bold="True"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" DataKeyNames = "idObjednavky, idZamestnanceKuchar, idZamestnanceRidic">
                <Columns>
                    <asp:BoundField DataField="datumVytvoreni" HeaderText="Datum vytvoření" ReadOnly="True" SortExpression="datumVytvoreni" />
                    <asp:BoundField DataField="cena" HeaderText="Cena" ReadOnly="True" SortExpression="cena" />
                    <asp:BoundField DataField="zamestnanecKuchar" HeaderText="Objednávku navařil" SortExpression="zamestnanecKuchar" />
                    <asp:ButtonField CommandName="hodnoceniKuchar" HeaderText="Ohodnotit" ShowHeader="True" Text="Ohodnotit zaměstnance" />
                    <asp:ButtonField CommandName="stiznostKuchar" HeaderText="Podat stížnost" ShowHeader="True" Text="Podat stížnost na zaměstnance" />
                    <asp:BoundField DataField="zamestnanecRidic" HeaderText="Objednávku dovezl" SortExpression="zamestnanecRidic" />
                    <asp:ButtonField CommandName="hodnoceniRidic" HeaderText="Ohodnotit" ShowHeader="True" Text="Ohodnotit zaměstnance" />
                    <asp:ButtonField CommandName="stiznostRidic" HeaderText="Podat stížnost" ShowHeader="True" Text="Podat stížnost na zaměstnance"/>
                    <asp:ButtonField CommandName="storno" HeaderText="Storno" ShowHeader="True" Text="Stornovat objednávku"/>

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
