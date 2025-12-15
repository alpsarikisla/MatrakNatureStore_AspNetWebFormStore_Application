using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MatrakNatureWebApp.YonetimPaneli
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategoriler.DataSource = imm.KategoriListele(false);
            lv_kategoriler.DataBind();
        }
    }
}