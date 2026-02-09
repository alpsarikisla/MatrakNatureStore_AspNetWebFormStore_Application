using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;
using VeriErisimKatmani.TabloSiniflari;

namespace MatrakNatureWebApp.YonetimPaneli
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_kategoriler.DataSource = imm.KategoriListele(false);
            ddl_kategoriler.DataValueField = "ID";
            ddl_kategoriler.DataTextField = "Isim";
            ddl_kategoriler.DataBind();

            ddl_tedarikci.DataSource = imm.TedarikciListele();
            ddl_tedarikci.DataValueField = "ID";
            ddl_tedarikci.DataTextField = "FirmaIsim";
            ddl_tedarikci.DataBind();
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (!string.IsNullOrEmpty(tb_fiyat.Text))
                {
                    Urun u = new Urun();
                    u.Isim = tb_isim.Text;
                    u.Aciklama = tb_aciklama.Text;
                    u.Stok = Convert.ToInt16(tb_stok.Text);
                    u.ListeFiyat = Convert.ToDecimal(tb_fiyat.Text);
                    u.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                    u.TedarikciID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                    u.Durum = cb_aktif.Checked;
                    u.Silinmis = false;
                    bool resimOnay = true;
                    if (fu_resim.HasFile)//Resim Dosyası Seçilmiş mi
                    {
                        //Resim dosyasına uniqe bir isim vermem gerekiyor
                        FileInfo fi = new FileInfo(fu_resim.FileName);
                        string uzanti = fi.Extension;
                        if (uzanti == ".jpg" || uzanti == ".png")
                        {
                            string isim = Guid.NewGuid().ToString();
                            string tamisim = isim + uzanti;
                            fu_resim.SaveAs(Server.MapPath("../UrunResimleri/" + tamisim));
                            u.UrunResim = tamisim;
                        }
                        else
                        {
                            resimOnay = false;
                        }
                    }
                    else
                    {
                        u.UrunResim = "none.jpg";
                    }
                    if (resimOnay)
                    {
                        if (imm.UrunEkle(u))
                        {
                            pnl_basarisiz.Visible = false;
                            pnl_basarili.Visible = true;

                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            pnl_basarili.Visible = false;
                            lbl_basarisizMesaj.Text = "Ürün Eklenirken Bir Hata Oluştu";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        lbl_basarisizMesaj.Text = "Resim Formatı Geçersiz";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_basarisizMesaj.Text = "Fiyat Boş Bırakılamaz";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_basarisizMesaj.Text = "Ürün Adı Boş Bırakılamaz";
            }
        }
    }
}