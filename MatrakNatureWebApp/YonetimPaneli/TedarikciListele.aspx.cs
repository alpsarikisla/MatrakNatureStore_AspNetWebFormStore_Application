using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MatrakNatureWebApp.YonetimPaneli
{
    public partial class TedarikciListele : System.Web.UI.Page
    {
        IslemMerkezMudurlugu imm = new IslemMerkezMudurlugu();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_tedarikciler.DataSource = imm.TedarikciListele(false);
            lv_tedarikciler.DataBind();
        }

        protected void lv_tedarikciler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}