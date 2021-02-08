using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CountryStateCity
{
    public partial class Country : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ToString()))
            {
                if (!Page.IsPostBack)
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select * from CountryTab", cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                           
                            if(dr.HasRows)
                            {
                                DataTable dt = new DataTable();
                                dt.Load(dr);
                                DropDownList1.DataSource = dt;
                                DropDownList1.DataValueField = "cid";
                                DropDownList1.DataTextField = "CountryName";
                                DropDownList1.DataBind();
                                
                            }
                        }
                    }
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ToString()))
            {
                var a = DropDownList1.SelectedValue;  
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from StateTable where Countryid=" + a + "", cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            DropDownList2.DataSource = dt;
                            DropDownList2.DataValueField = "sid";
                            DropDownList2.DataTextField = "StateName";
                            DropDownList2.DataBind();
                        }
                    }
                }
                
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ToString()))
            {
               
                var a = DropDownList2.SelectedValue;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from CityTable where sid=" + a + "", cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            DropDownList3.DataSource = dt;
                            DropDownList3.DataValueField = "CityId";
                            DropDownList3.DataTextField = "CityName";
                            DropDownList3.DataBind();
                        }
                    }
                }
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
