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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace University_Management
{
    public partial class courses : Form
    {
        public courses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedProgram = comboBox1.SelectedItem as DataRowView;
            var programId = selectedProgram != null ? selectedProgram["Program_id"].ToString() : null;

            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-PRKTE1Q;Initial Catalog=University;Integrated Security = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into courses values(@course_name,@Program_id)", con);
            cnn.Parameters.AddWithValue("@course_name", textBox1.Text);
            cnn.Parameters.AddWithValue("@Program_id", programId);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);





        }

        private void courses_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-PRKTE1Q;Initial Catalog=University;Integrated Security = True");
            string sql = "select * from Departments";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Program_id";
            comboBox1.ValueMember = "Program_id";
        }
    }
}
