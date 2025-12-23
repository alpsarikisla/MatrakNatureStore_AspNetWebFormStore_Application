using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

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

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {

        }

        protected void ddl_sehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sehirId = Convert.ToInt32(ddl_sehir.SelectedValue);
            ddl_ilce.DataSource = imm.SehireGoreIlceler(sehirId);
            ddl_ilce.DataValueField = "ID";
            ddl_ilce.DataTextField = "Isim";
            ddl_ilce.DataBind();
        }
    }
}