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
    public partial class notify : Form
    {
        string connectionString = string.Format(
               "server={0};uid={1};pwd={2};database={3}",
               "localhost",
               "root",
               "1813059642",
               "frapp"
               );

        public static string sel;
        public notify()
        {
            InitializeComponent();

            using (var conn = new MySqlConnection(connectionString))
            {


                conn.Open();

                using (var cmd = new MySqlCommand("SELECT sname, initial, fname, dep, prolink FROM notification ", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear();
                        while (reader.Read())
                        {

                            DataGridViewRow newrow = new DataGridViewRow();
                            newrow.CreateCells(dataGridView1);
                            newrow.Cells[0].Value = reader.GetString(0);
                            newrow.Cells[1].Value = reader.GetString(1);
                            newrow.Cells[2].Value = reader.GetString(2);
                            newrow.Cells[3].Value = reader.GetString(3);
                            newrow.Cells[4].Value = reader.GetString(4);
                            dataGridView1.Rows.Add(newrow);
                        }

                    }
                }

            }


        }

        private void datagridview1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                sel = Convert.ToString(selectedRow.Cells["Column2"].Value);
            }


            if (e.ColumnIndex== 5)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("DELETE FROM notification WHERE initial='" + sel + "'", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            MessageBox.Show("Approved this Faculty Info");
                        }
                    }
                }
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }
            else if(e.ColumnIndex == 6)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("DELETE FROM faculty WHERE initial='"+ sel +"'", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            MessageBox.Show("Deleted this faculty info");
                        }
                    }

                    using (var cmd = new MySqlCommand("DELETE FROM notification WHERE initial='" + sel + "'", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                        }
                    }

                }
            }
        }
    }
}
