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
                int id = Convert.ToInt32(Request.QueryString["kid"]);
               
            }
            else
            {
                Response.Redirect("TumKategoriler.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {

        }
    }
}