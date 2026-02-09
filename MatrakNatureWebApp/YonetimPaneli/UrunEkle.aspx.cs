using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MatrakNatureWebApp.YonetimPaneli
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_kategoriler.DataSource = imm.KategoriListele();
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

        }
    }
}