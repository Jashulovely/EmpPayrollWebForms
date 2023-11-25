﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpPayrollWebForms.EmpPayrollWebForms
{
    public partial class EmpPayroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeList();
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
            cmd.ExecuteNonQuery();
            con.Close();
            GetEmployeeList();
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

    }
}