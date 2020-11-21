using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("http");

                DataSet ds = client.GetData("", "");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

                DataSet ds1 = client.GetClients();
                DropDownList1.DataSource = ds1;
                DropDownList1.DataTextField = "ini_cli";
                DropDownList1.DataValueField = "id_cli";
                DropDownList1.DataBind();

                DataSet ds2 = client.GetServices();
                DropDownList2.DataSource = ds2;
                DropDownList2.DataTextField = "name_ser";
                DropDownList2.DataValueField = "id_ser";
                DropDownList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text;
            string cli = DropDownList1.Text;
            string ser = DropDownList2.Text;
            string data = TextBox2.Text;
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("http");
            client.NewRec(id, cli, ser, data);
            Response.Redirect("http://localhost:58486/WebForm1.aspx");
        }
    }
}