using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeRegistrationWithCruDStoredProcedure
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }
        protected void BindGridview()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CollegeDB;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CrudOperationsInGridView", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SELECT");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDetailsForCurdOperation.DataSource = ds;
                    gvDetailsForCurdOperation.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvDetailsForCurdOperation.DataSource = ds;
                    gvDetailsForCurdOperation.DataBind();
                    int columncount = gvDetailsForCurdOperation.Rows[0].Cells.Count;
                    gvDetailsForCurdOperation.Rows[0].Cells.Clear();
                    gvDetailsForCurdOperation.Rows[0].Cells.Add(new TableCell());
                    gvDetailsForCurdOperation.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvDetailsForCurdOperation.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
        protected void gvDetailsForCurdOperation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtpname = (TextBox)gvDetailsForCurdOperation.FooterRow.FindControl("txtpname");
                TextBox txtprice = (TextBox)gvDetailsForCurdOperation.FooterRow.FindControl("txtprice");
                crudoperationsForGrid("INSERT", txtpname.Text, txtprice.Text, 0);
            }
        }
        protected void gvDetailsForCurdOperation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetailsForCurdOperation.EditIndex = e.NewEditIndex;
            BindGridview();
        }
        protected void gvDetailsForCurdOperation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetailsForCurdOperation.EditIndex = -1;
            BindGridview();
        }
        protected void gvDetailsForCurdOperation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetailsForCurdOperation.PageIndex = e.NewPageIndex;
            BindGridview();
        }
        protected void gvDetailsForCurdOperation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int CollageId = Convert.ToInt32(gvDetailsForCurdOperation.DataKeys[e.RowIndex].Values["CollageId"].ToString());
            TextBox txtname = (TextBox)gvDetailsForCurdOperation.Rows[e.RowIndex].FindControl("txtCollagename");
            TextBox txtCollageRank = (TextBox)gvDetailsForCurdOperation.Rows[e.RowIndex].FindControl("txtCollageRank");
            crudoperationsForGrid("UPDATE", txtname.Text, txtCollageRank.Text, CollageId);
        }
        protected void gvDetailsForCurdOperation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CollageId = Convert.ToInt32(gvDetailsForCurdOperation.DataKeys[e.RowIndex].Values["CollageId"].ToString());
            string Collagename = gvDetailsForCurdOperation.DataKeys[e.RowIndex].Values["Collagename"].ToString();
            crudoperationsForGrid("DELETE", Collagename, "", CollageId);
        }
        protected void crudoperationsForGrid(string status, string Collagename, string price, int CollageId)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CollegeDB;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CrudOperationsInGridView", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "INSERT")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@Collagename", Collagename);
                    cmd.Parameters.AddWithValue("@CollageRank", price);
                }
                else if (status == "UPDATE")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@Collagename", Collagename);
                    cmd.Parameters.AddWithValue("@CollageRank", price);
                    cmd.Parameters.AddWithValue("@CollageId", CollageId);
                }
                else if (status == "DELETE")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@CollageId", CollageId);
                }
                cmd.ExecuteNonQuery();
                lblresult.ForeColor = Color.Green;
                lblresult.Text = Collagename + " details " + status.ToLower() + "d successfully";
                gvDetailsForCurdOperation.EditIndex = -1;
                BindGridview();
            }
        }
    }
}