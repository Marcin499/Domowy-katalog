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

namespace Katalog
{
    public partial class FilmyWypozyczenie : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BPE4OM3;Initial Catalog=BazaKsiążki;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public FilmyWypozyczenie()
        {
            InitializeComponent();
            con.Close();
            con.Open();
            DateTime time = DateTime.Now;
            label8.Text = time.ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from  BazaFilmówWypozyczenie Where Data_zwrotu = '" + label8.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlDataReader read = cmd.ExecuteReader();
            if (!read.HasRows)
            {

            }
            else
            {
                MessageBox.Show("Książka jest do zwrotu!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Uzupełnij dane!");
            }
            else
            {

                try
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into  BazaFilmówWypozyczenie (ID,Imię, Nazwisko, Tytuł, Data_wypożyczenia, Data_zwrotu) values (@ID,@Imię, @Nazwisko, @Tytuł, @Data_wypożyczenia, @Data_zwrotu)";
                    cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Imię", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Nazwisko", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Tytuł", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Data_wypożyczenia", this.dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Data_zwrotu", this.dateTimePicker2.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Dane zostały dodane.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();

                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from  BazaFilmówWypozyczenie";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy napewno chcesz usunąć dane?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                MessageBox.Show("Anulowano operacje");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from BazaFilmówWypozyczenie Where ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                MessageBox.Show("Usunięto dane!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();

            }
        }
    }
}
