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
    public partial class addfaculty : Form
    {
        string connectionString = string.Format(
                "server={0};uid={1};pwd={2};database={3}",
                "localhost",
                "root",
                "1813059642",
                "frapp"
                );

        public addfaculty()
        {
            InitializeComponent();

            label3.Text = Login.name;

            if (Login.typ == "1")
            {
                label2.Text = "Administrator";
            }
            else
            {
                label2.Text = "Student";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lin = new Login();
            lin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            cgpacalc cg = new cgpacalc();
            cg.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.textBox3.Text) || string.IsNullOrEmpty(this.textBox4.Text))
            {
                MessageBox.Show("Fill all of the point.");
            }
            else
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("INSERT into frapp.faculty(initial,name,dep,pro_link) values ('" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "', '" + this.textBox4.Text + "')", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            
                        }
                    }

                    if (Login.typ == "3")
                    {
                        using (var cmd = new MySqlCommand("INSERT into frapp.notification(sname,initial,fname,dep,prolink) values ('" + Login.name + "','" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "', '" + this.textBox4.Text + "')", conn))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {

                            }
                        }
                    }

                    MessageBox.Show("Faculty Inserted");

                    this.Hide();
                    Search search = new Search();
                    search.Show();

                }
            }
        }
    }
}
