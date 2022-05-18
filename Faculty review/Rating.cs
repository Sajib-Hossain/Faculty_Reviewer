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
    public partial class Rating : Form
    {

        string connectionString = string.Format(
                "server={0};uid={1};pwd={2};database={3}",
                "localhost",
                "root",
                "1813059642",
                "frapp"
                );

        public Rating()
        {
            InitializeComponent();

            label3.Text = Login.name;
            label10.Text = Search.fac_ini;
            label11.Text = Search.oa;
            label12.Text = Search.tc;
            label13.Text = Search.gr;
            label14.Text = Search.fr;

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


            using (var conn = new MySqlConnection(connectionString))
            {


                conn.Open();

                using (var cmd = new MySqlCommand("SELECT sname, initial, cmnt FROM comment WHERE initial='" + Search.fac_ini + "'", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while(reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader.GetString(0));
                            item.SubItems.Add(reader.GetString(2));
                            listView1.Items.Add(item);
                        }

                    }
                }

            }

        }

        private void Rating_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
