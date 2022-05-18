using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Faculty_review
{
    public partial class cgpacalc : Form
    {

        public static double credit = 0.0, grade = 0.0, total=0.0;
        public cgpacalc()
        {
            InitializeComponent();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            Hide();
            Search src = new Search();
            src.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label5.Text = String.Format("{0:F2}", (total / credit));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double c = Convert.ToDouble(this.textBox1.Text);
            credit = credit + c;
            grade = Convert.ToDouble(this.textBox2.Text);
            total = total + (c*grade);

            this.Hide();
            cgpacalc cg = new cgpacalc();
            cg.Show();

        }
    }
}
