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
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0) 
            {
                if(!IsPostBack)//Sayfa ilk kez açılıyorsa
                {
                    int id = Convert.ToInt32(Request.QueryString["kid"]);
                    Kategori kat = imm.KategoriGetir(id);
                    tb_isim.Text = kat.Isim;
                    cb_aktif.Checked = kat.YayinDurum;
                }
            }
            else
            {
                Response.Redirect("TumKategoriler.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["kid"]);
            Kategori kat = imm.KategoriGetir(id);
            kat.Isim = tb_isim.Text;
            kat.YayinDurum = cb_aktif.Checked;
            if (imm.KategoriGuncelle(kat))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisizMesaj.Text = "Kategori düzenlenirken bir hata oluştu";
            }
        }
    }
}