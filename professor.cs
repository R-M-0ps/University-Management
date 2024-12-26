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
    public partial class professor : Form
    {
        public professor()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void professor_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

            var selectedProgram = comboBox1.SelectedItem as DataRowView;
            var programId = selectedProgram != null ? selectedProgram["Program_id"].ToString() : null;

            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-PRKTE1Q;Initial Catalog=University;Integrated Security = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Professor values(@F_name,@L_name,@professor_birth_of_date,@program_id,@Phone,@email)", con);
            cnn.Parameters.AddWithValue("@F_name", textBox1.Text);
            cnn.Parameters.AddWithValue("@L_name", textBox2.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@email", textBox3.Text);
            cnn.Parameters.AddWithValue("@professor_birth_of_date", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@program_id", programId);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
