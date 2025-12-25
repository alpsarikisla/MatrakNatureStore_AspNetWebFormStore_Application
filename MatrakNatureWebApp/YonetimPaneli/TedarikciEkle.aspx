<%@ Page Title="" Language="C#" MasterPageFile="~/YonetimPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="TedarikciEkle.aspx.cs" Inherits="MatrakNatureWebApp.YonetimPaneli.TedarikciEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategori Ekle</h3>
              <div style="clear:right"></div>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                <label>Tedarikçi Ekleme Başarılı</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_basarisizMesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="sol">
                <div class="satir">
                    <label style="line-height: 40px">Tedarikçi Firma Adı</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="formMetinKutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label style="line-height: 40px">Yetkili Adı</label><br />
                    <asp:TextBox ID="tb_yetkili" runat="server" CssClass="formMetinKutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label style="line-height: 40px">Yetkili Ünvan</label><br />
                    <asp:TextBox ID="tb_unvan" runat="server" CssClass="formMetinKutu"></asp:TextBox>
                </div>
                <div class="satir" style="margin-top: 30px;">
                    <asp:CheckBox ID="cb_aktif" runat="server" Text=" Aktif Tedarikçi"></asp:CheckBox>
                </div>
            </div>
            <div class="sag">
                <div class="satir">
                    <label style="line-height: 40px">Telefon Numarası</label><br />
                    <asp:TextBox ID="tb_telefon" runat="server" CssClass="formMetinKutu" placeholder="530XXXXXXX"></asp:TextBox>
                </div>
                <div class="satir">
                    <label style="line-height: 40px">Şehir</label><br />
                    <asp:DropDownList ID="ddl_sehir" runat="server" CssClass="formMetinKutu" OnSelectedIndexChanged="ddl_sehir_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="satir">
                    <label style="line-height: 40px">İlçe</label><br />
                    <asp:DropDownList ID="ddl_ilce" runat="server" CssClass="formMetinKutu"></asp:DropDownList>
                </div>
                <div class="satir">
                    <label style="line-height: 40px">Adres</label><br />
                    <asp:TextBox ID="tb_adres" runat="server" CssClass="formMetinKutu"></asp:TextBox>
                </div>
            </div>

            <div class="satir">
                <br />
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="formButon" OnClick="lbtn_ekle_Click">Tedarikçi Ekle
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
