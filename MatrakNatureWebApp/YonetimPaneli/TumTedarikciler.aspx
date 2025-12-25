<%@ Page Title="" Language="C#" MasterPageFile="~/YonetimPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="TumTedarikciler.aspx.cs" Inherits="MatrakNatureWebApp.YonetimPaneli.TumTedarikciler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Tüm Tedarikci Listesi</h3>
            <a href="TedarikciListele.aspx"> Tedarikçiler </a>
            <div style="clear: right"></div>
        </div>
        <div class="formIcerik">
            <asp:ListView ID="lv_tedarikciler" runat="server" OnItemCommand="lv_tedarikciler_ItemCommand">
                <LayoutTemplate>
                    <table class="tablo" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Yetkili</th>
                            <th>Şehir</th>
                            <th>Telefon</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("FirmaIsim") %></td>
                        <td><%# Eval("YetkiliIsim") %></td>
                        <td><%# Eval("Il") %></td>
                        <td><%# Eval("TelefonNumarasi") %></td>
                        <td><%# Eval("DurumStr") %></td>
                        <td>
                            <a href='Tedarikci.aspx?tid=<%# Eval("ID") %>' class="tabloButonDuzenle">Düzenle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tabloButonSil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
