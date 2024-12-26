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
using System.Data.SqlClient;

namespace University_Management
{
    public partial class enrollments : Form
    {
        public enrollments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedstudent = comboBox1.SelectedItem as DataRowView;
            var studentId = selectedstudent != null ? selectedstudent["student_id"].ToString() : null;
            var selectedcourse = comboBox2.SelectedItem as DataRowView;

            var courseId = selectedcourse != null ? selectedcourse["course_id"].ToString() : null;


            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-PRKTE1Q;Initial Catalog=University;Integrated Security = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Professor values(@year,@semester,@grade,@student_id,@course_id)", con);
            cnn.Parameters.AddWithValue("@year", textBox1.Text);
            cnn.Parameters.AddWithValue("@semester", textBox2.Text);
            cnn.Parameters.AddWithValue("@grade", textBox3.Text);
         
            cnn.Parameters.AddWithValue("@course_id",courseId);
            cnn.Parameters.AddWithValue("student_id", studentId);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void enrollments_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-PRKTE1Q;Initial Catalog=University;Integrated Security = True");
            string sql = "select * from Students";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "student_id ";
            comboBox1.ValueMember = "student_id";




            string sq = "select * from courses";
            SqlDataAdapter co = new SqlDataAdapter(sq, con);
            DataTable ca = new DataTable();
            co.Fill(ca);
            comboBox2.DataSource = ca;
            comboBox2.DisplayMember = " course_id ";
            comboBox2.ValueMember = "course_id";




        }
    }
}
