<%@ Page Title="" Language="C#" MasterPageFile="~/YonetimPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="MatrakNatureWebApp.YonetimPaneli.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategori Listesi</h3>
        </div>
        <div class="formIcerik">
            <asp:ListView ID="lv_kategoriler" runat="server">
                <LayoutTemplate>
                    <table class="tablo" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("YayinDurumStr") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="tabloButonDuzenle">Düzenle</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tabloButonSil">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
