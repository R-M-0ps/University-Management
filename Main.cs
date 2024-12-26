using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student St = new Student();
            St.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            courses cs = new courses();
            cs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            professor pr = new professor();
            pr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            enrollments en = new enrollments();
            en.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            schedule sc = new schedule();
            sc.Show();
        }
    }
}
