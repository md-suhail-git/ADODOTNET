using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONET
{
    public partial class Sqlcomm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                
                
                //Execute NonQuery used to insert ,delete and update from the table
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into EmpTable values(8,'RAm','Male','250000')";
                cmd.Connection = con;
                con.Open();
                int totalrows=cmd.ExecuteNonQuery();
                Response.Write("The insert the rows are "+totalrows);
            }
            using (SqlConnection conn = new SqlConnection(cs))
            {
                //Execute Reader used to select the column from the table of database schema 
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id,Name,Gender,Salary from EmpTable";
                cmd.Connection = conn;
                conn.Open();
                GridView3.DataSource = cmd.ExecuteReader();
                GridView3.DataBind();
            }
            using (SqlConnection con1 = new SqlConnection(cs))
            {

                //Execute Scalar used to select single value from the table of database schema
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from EmpTable";
                cmd.Connection = con1;
                con1.Open();
                int i = (int)cmd.ExecuteScalar();
                Response.Write("The Count of row is "+i);
            }
        }
    }
}