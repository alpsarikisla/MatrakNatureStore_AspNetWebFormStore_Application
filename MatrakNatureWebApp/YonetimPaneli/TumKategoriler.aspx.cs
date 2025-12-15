using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MatrakNatureWebApp.YonetimPaneli
{
    public partial class TumKategoriler : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategoriler.DataSource = imm.KategoriListele();
            lv_kategoriler.DataBind();
        }

        protected void lv_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                imm.KategoriSil(id);
            }
            lv_kategoriler.DataSource = imm.KategoriListele();
            lv_kategoriler.DataBind();
        }
    }
}