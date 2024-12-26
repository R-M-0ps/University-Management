using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace University_Management
{
    public partial class schedule : Form
    {
        public schedule()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "HH:mm:SS";
            dateTimePicker1.ShowUpDown = true;
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "HH:mm:SS";
            dateTimePicker2.ShowUpDown = true;
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedcourse = comboBox2.SelectedItem as DataRowView;

            var courseId = selectedcourse != null ? selectedcourse["course_id"].ToString() : null;

            var selectedprof = comboBox1.SelectedItem as DataRowView;

            var profId = selectedprof != null ? selectedprof["Professor_id"].ToString() : null;


            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-PRKTE1Q;Initial Catalog=University;Integrated Security = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into schedule values(@Professor_id,@course_id,@start_time,@end_time,@day)", con);
            cnn.Parameters.AddWithValue("@course_id",courseId);
            cnn.Parameters.AddWithValue("@Professor_id",profId );
            cnn.Parameters.AddWithValue("@start_time", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@end_time", dateTimePicker2.Value);
            cnn.Parameters.AddWithValue("@day", textBox1.Text);
            
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void schedule_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-PRKTE1Q;Initial Catalog=University;Integrated Security = True");
            string sq = "select * from courses";
            SqlDataAdapter co = new SqlDataAdapter(sq, con);
            DataTable ca = new DataTable();
            co.Fill(ca);
            comboBox2.DataSource = ca;
            comboBox2.DisplayMember = "course_id ";
            comboBox2.ValueMember = "course_id";


            
            string sql = "select * from professor";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Professor_id ";
            comboBox1.ValueMember ="Professor_id";
        }
    }
}
