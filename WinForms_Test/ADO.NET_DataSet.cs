using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace WinForms_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ADO.NET資料庫連線
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source=DESKTOP-71FRJMO;Initial Catalog=kkk;Integrated Security=True";
            Conn.Open();
            SqlDataAdapter daEmp = new SqlDataAdapter("Select * From Test Order By id Asc", Conn);
            daEmp.Fill(ds, "SQLQuery1");
            daEmp.Dispose();
            Conn.Close();
            Conn.Dispose();
            dataGridView1.DataSource = ds.Tables["SQLQuery1"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //當離開using{...}區塊時，cn物件馬上被釋放掉。 可替代Close方法
            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=DESKTOP-71FRJMO;Initial Catalog=kkk;Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Test",cn);
                SqlDataReader dr = cmd.ExecuteReader();
                textBox1.Text = "ID"+"\t"+"Field1"+"\t"+"Field2"+"\t\t"+"Field3" + "\r\n";
                while (dr.Read())
                {
                    textBox1.Text += dr["ID"] + "\t" + dr["Field1"] + "\t" + dr["Field2"] + "\t\t" + dr["Field3"] + "\r\n";
                }
            }
        }
    }
}
