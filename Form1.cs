using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace University_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-PRKTE1Q;Initial Catalog=University;Integrated Security = True");
            con.Open();
            string Username = textBox1.Text;
            string Password = textBox2.Text;
            SqlCommand cnn = new SqlCommand("select Username,Password from Loginn where Username= '" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                MessageBox.Show("invalid user name or password");
            }
            con.Close();
        }
    }
}
