using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace EmpPayrollWebForms.EmpPayrollWebForms
{
    public partial class EmpPayroll : System.Web.UI.Page
    {
        //string cs = ConfigurationManager.ConnectionStrings["DBEP"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetEmployeeList();
                GVbind();
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NSUENJK\SQLEXPRESS;Initial Catalog=EmployeePayrollWebForms;Integrated Security=True");
        protected void Button1_Click(object sender, EventArgs e)
        {
            //int empid = int.Parse(TextBox1.Text);
            //string empname = TextBox2.Text;
            //string gender = RadioButtonList1.SelectedValue;
            //string department = DropDownList1.SelectedValue;
            //int salary = int.Parse(TextBox4.Text);
            //DateTime joindate = DateTime.Parse(TextBox3.Text);
            //con.Open();
            //SqlCommand cmd = new SqlCommand("exec uspAddEmployee '"+empid+ "','"+empname+"','"+gender+"','"+department+"','"+salary+"','"+ joindate + "'", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted...');", true);
            //GetEmployeeList();


            SqlCommand cmd = new SqlCommand("uspAddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", int.Parse(TextBox1.Text));
            cmd.Parameters.AddWithValue("@EmpName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", RadioButtonList1.SelectedValue);
            cmd.Parameters.AddWithValue("@Department", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@Salary", int.Parse(TextBox4.Text));
            cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(TextBox3.Text));

            con.Open();
            int t =cmd.ExecuteNonQuery();
            if (t > 0)
            {
                Response.Write("<script>alert('Data has been submitted successfully')</script>");
            }
            Clear();
            con.Close();
            //GetEmployeeList();
            GVbind();
        }

        void Clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            // RadioButtonList1.SelectedValue = "";
            //DropDownList1.SelectedValue = "";
            TextBox4.Text = "";
            TextBox3.Text = "";
        }

        void GetEmployeeList()
        {
            SqlCommand cmd = new SqlCommand("exec uspEmployeesList", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            //int empid = int.Parse(TextBox1.Text);
            //string empname = TextBox2.Text;
            //string gender = RadioButtonList1.SelectedValue;
            //string department = DropDownList1.SelectedValue;
            //int salary = int.Parse(TextBox4.Text);
            //DateTime joindate = DateTime.Parse(TextBox3.Text);
            //con.Open();
            //SqlCommand cmd = new SqlCommand("exec uspUpdateEmployee '" + empid + "','" + empname + "','" + gender + "','" + department + "','" + salary + "','" + joindate + "'", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated...');", true);
            //GetEmployeeList();


            SqlCommand cmd = new SqlCommand("uspUpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", int.Parse(TextBox1.Text));
            cmd.Parameters.AddWithValue("@EmpName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", RadioButtonList1.SelectedValue);
            cmd.Parameters.AddWithValue("@Department", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@Salary", int.Parse(TextBox4.Text));
            cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(TextBox3.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GetEmployeeList();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(TextBox1.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec uspDeleteEmployee '" + empid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted...');", true);
            GetEmployeeList();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(TextBox1.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec uspGetEmployeeById '" + empid + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            GetEmployeeList();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            //RadioButtonList1.SelectedValue = "";
            //DropDownList1.SelectedValue = "";
            TextBox4.Text = "";
            TextBox3.Text = "";
        }

        protected void GVbind()
        {
            SqlCommand cmd = new SqlCommand("exec uspEmployeesList", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GVbind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string gender = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string dept = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            int sal = Convert.ToInt32(((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            DateTime joinDate = Convert.ToDateTime(((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text);


            using (con)
            {
                SqlCommand cmd = new SqlCommand("uspUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", id);
                cmd.Parameters.AddWithValue("@EmpName", name);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Department", dept);
                cmd.Parameters.AddWithValue("@Salary", sal);
                cmd.Parameters.AddWithValue("@StartDate", joinDate);

                con.Open();
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("<script>alert('Data has been updated successfully')</script>");
                    GridView1.EditIndex = -1;
                    GVbind();
                }
                con.Close();
                //GetEmployeeList();
                
            }


        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GVbind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (con)
            {
                SqlCommand cmd = new SqlCommand("uspDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", id);
                

                con.Open();
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("<script>alert('Data has been Deleted successfully')</script>");
                    GridView1.EditIndex = -1;
                    GVbind();
                }
                con.Close();
                //GetEmployeeList();

            }
        }
    }
}