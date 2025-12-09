<%@ Page Title="" Language="C#" MasterPageFile="~/YonetimPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="MatrakNatureWebApp.YonetimPaneli.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategori Ekle</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                <label>Kategori Ekleme Başarılı</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_basarisizMesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label style="line-height:40px">Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="formMetinKutu"></asp:TextBox>
            </div>
            <div class="satir" style="padding-top:15px">
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="formButon">Kategori Ekle
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
