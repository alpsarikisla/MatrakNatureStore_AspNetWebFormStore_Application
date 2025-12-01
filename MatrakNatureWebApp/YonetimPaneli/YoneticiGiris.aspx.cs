using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;
using VeriErisimKatmani.TabloSiniflari;

namespace MatrakNatureWebApp.YonetimPaneli
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    Yonetici yon = imm.YoneticiGiris(tb_mail.Text, tb_sifre.Text);
                    if (yon != null) 
                    {
                        if (yon.Durum)
                        {
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lbl_mesaj.Text = "*   Hesabınız askıya alınmıştır";
                        }
                    }
                    else
                    {
                        lbl_mesaj.Text = "*   Girdiğiniz bilgilerde kullanıcı bulunamadı";
                    }
                }
                else
                {
                    lbl_mesaj.Text = "*   Şifre girilmesi zorunludur";
                }
            }
            else
            {
                lbl_mesaj.Text = "*    Kullanıcı Adı girilmesi zorunludur";
            }
        }
    }
}