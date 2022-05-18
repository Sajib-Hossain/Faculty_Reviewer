using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Faculty_review
{

    public partial class Evaluate : Form
    {
        string connectionString = string.Format(
               "server={0};uid={1};pwd={2};database={3}",
               "localhost",
               "root",
               "1813059642",
               "frapp"
               );

        public Evaluate()
        {
            InitializeComponent();

            label3.Text = Login.name;
            label6.Text = Search.fac_ini;
            label8.Text = Search.fac_name;

            if (Login.typ == "1")
            {
                label2.Text = "Administrator";
            }
            else if (Login.typ == "2")
            {
                label2.Text = "Faculty";
            }
            else
            {
                label2.Text = "Student";
            }
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int t = 0;
            foreach(var item in checkedListBox1.CheckedItems)
            {
                t = t+2;
            }

            int f = 0;
            foreach (var item in checkedListBox2.CheckedItems)
            {
                f = f + 2;
            }

            int g = 0;
            foreach (var item in checkedListBox3.CheckedItems)
            {
                g = g + 2;
            }

            int ov =0, tc=0, gr=0, fr=0;

            using (var conn = new MySqlConnection(connectionString))
            {

                conn.Open();

                using (var cmd = new MySqlCommand("SELECT over_all, teaching, grading, friendly FROM faculty WHERE initial ='" + Search.fac_ini + "'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        var oar = reader.GetString(0);
                        if(oar == "0")
                        {
                            tc = t;
                            gr = g;
                            fr = f;
                            ov = ((tc + gr + fr) * 10) / 30;
                        }
                        else
                        {
                            tc = ((Convert.ToInt32(reader.GetString(1)) + t) * 10) / 20;
                            gr = ((Convert.ToInt32(reader.GetString(2)) + g) * 10) / 20;
                            fr = ((Convert.ToInt32(reader.GetString(3)) + f) * 10) / 20;
                            ov = ((tc + gr + fr) * 10) / 30;

                            ov = ((Convert.ToInt32(reader.GetString(0)) + ov) * 10) / 20;
                        }
                    }
                }

                /*rating update*/

                using (var cmd = new MySqlCommand("UPDATE faculty SET teaching='" + tc + "', grading= '" + gr + "', friendly= '" + fr + "', over_all= '"+ ov +"' WHERE initial ='"+ Search.fac_ini + "' ", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        MessageBox.Show("Your rating is collected");
                    }
                }

                /*comment adding*/

                using (var cmd = new MySqlCommand("INSERT into frapp.comment(sname,initial,cmnt) values ('" + Login.name + "', '" + Search.fac_ini + "', '" + this.textBox1.Text + "')", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        
                    }
                }

                /*user review increase*/

                int rv = Convert.ToInt32(Login.review) + 1;
                using (var cmd = new MySqlCommand("UPDATE user SET reviewed='" + rv + "' WHERE User_id ='" + Login.uid + "' ", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        
                    }
                }

            }
            this.Hide();
            Evaluate ev = new Evaluate();
            ev.Show();
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lin = new Login();
            lin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }

        private void Evaluate_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            cgpacalc calc = new cgpacalc();
            calc.Show();
        }
    }
}

