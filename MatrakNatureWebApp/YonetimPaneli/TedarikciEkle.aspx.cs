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
    public partial class TedarikciEkle : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_sehir.DataSource = imm.SehirleriListele();
                ddl_sehir.DataValueField = "ID";
                ddl_sehir.DataTextField = "Isim";
                ddl_sehir.DataBind();

                ddl_ilce.DataSource = imm.SehireGoreIlceler(1);
                ddl_ilce.DataValueField = "ID";
                ddl_ilce.DataTextField = "Isim";
                ddl_ilce.DataBind();
            }
        }
        protected void ddl_sehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sehirId = Convert.ToInt32(ddl_sehir.SelectedValue);
            ddl_ilce.DataSource = imm.SehireGoreIlceler(sehirId);
            ddl_ilce.DataValueField = "ID";
            ddl_ilce.DataTextField = "Isim";
            ddl_ilce.DataBind();
        }
        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tb_isim.Text))
            {
                Tedarikci tt = new Tedarikci();
                tt.FirmaIsim = tb_isim.Text;
                tt.YetkiliIsim = tb_yetkili.Text;
                tt.YetkiliUnvan = tb_unvan.Text;
                tt.Durum = cb_aktif.Checked;
                tt.Silinmis = false;
                tt.IlID = Convert.ToInt32(ddl_sehir.SelectedItem.Value);
                tt.IlceID = Convert.ToInt32(ddl_ilce.SelectedItem.Value);
                tt.Adres = tb_adres.Text;
                tt.TelefonNumarasi = tb_telefon.Text;
                if(imm.TedarikciEkle(tt))
                {
                    pnl_basarisiz.Visible = false;
                    pnl_basarili.Visible = true;
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_basarisizMesaj.Text = "Tedarikçi ekleme işlemi başarısız";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_basarisizMesaj.Text = "Firma adı boş bırakılamaz";
            }
        }

        
    }
}