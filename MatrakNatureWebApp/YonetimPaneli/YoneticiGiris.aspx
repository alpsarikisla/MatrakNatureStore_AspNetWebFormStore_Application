<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="MatrakNatureWebApp.YonetimPaneli.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetici Giriş</title>
    <link href="css\YoneticiGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="girisFormTasiyici">
            <div class="formBaslik">
                <h1>GİRİŞ YAP</h1>
            </div>
            <div class="iceriktasiyici">
                <div class="mesajTasiyici">
                    <asp:Label ID="lbl_mesaj" runat="server" CssClass="mesaj"></asp:Label>
                </div>
                <table>
                    <tr>
                        <td class="etiket">Mail Adresi</td>
                        <td>
                            <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu" placeholder="Mail Adresinizi Giriniz"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="etiket">Şifre</td>
                        <td>
                            <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" placeholder="Şifre Giriniz" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="girisbuton" OnClick="lbtn_giris_Click"> Giriş Yap</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
