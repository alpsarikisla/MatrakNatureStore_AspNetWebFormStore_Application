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
    public partial class KategoriEkle : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kategori aed = new Kategori();
                aed.Isim = tb_isim.Text;
                aed.Silinmis = false;
                aed.YayinDurum = cb_aktif.Checked;
                if (imm.KategoriEkle(aed))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisizMesaj.Text = "Kategori Eklenirken Bir Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisizMesaj.Text = "Kategori Adı boş bırakılamaz";
            }
        }
    }
}