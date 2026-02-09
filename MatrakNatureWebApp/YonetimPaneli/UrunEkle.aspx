<%@ Page Title="" Language="C#" MasterPageFile="~/YonetimPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="MatrakNatureWebApp.YonetimPaneli.UrunEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Ürün Ekle</h3>
            <a href="UrunListele.aspx">Ürün listesine Dön</a>
            <div style="clear: right"></div>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                <label>Ürün Ekleme Başarılı</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_basarisizMesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="container">
                <div class="kolon">
                    <div class="satir">
                        <label style="line-height: 40px">Ürün Adı</label><br />
                        <asp:TextBox ID="tb_isim" runat="server" CssClass="formMetinKutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <label style="line-height: 40px">Kategori Seçiniz</label><br />
                        <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="formMetinKutu"></asp:DropDownList>
                    </div>
                    <div class="satir">
                        <label style="line-height: 40px">Tedarikçi Seçiniz</label><br />
                        <asp:DropDownList ID="ddl_tedarikci"  runat="server" CssClass="formMetinKutu"></asp:DropDownList>
                    </div>
                    <div class="satir">
                        <label style="line-height: 40px">Liste Fiyat:</label><br />
                        <asp:TextBox ID="tb_fiyat" runat="server" CssClass="formMetinKutu" placeholder="Fiyat Giriniz"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <label style="line-height: 40px">Stok:</label><br />
                        <asp:TextBox ID="tb_stok" runat="server" CssClass="formMetinKutu" placeholder="Stok Giriniz"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <label style="line-height:40px">Ürün Resmi:</label>
                        <asp:FileUpload ID="fu_resim" runat="server" CssClass="formMetinKutu" />
                    </div>
                </div>
                <div class="kolon">
                    <div class="satir">
                        <label style="line-height: 40px">Açıklama</label><br />
                        <asp:TextBox ID="tb_aciklama" runat="server" CssClass="formMetinKutu" TextMode="MultiLine" Height="300"></asp:TextBox>
                    </div>
                    <div class="satir" style="margin-top: 30px;">
                        <asp:CheckBox ID="cb_aktif" runat="server" Text=" Aktif Ürün"></asp:CheckBox>
                    </div>
                </div>
            </div>
            <div class="satir" style="margin-top: 10px;">
                <br />
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="formButon" OnClick="lbtn_ekle_Click">Ürün Ekle
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
