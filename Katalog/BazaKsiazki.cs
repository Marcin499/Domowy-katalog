using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Katalog
{
    public partial class BazaKsiazki : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BPE4OM3;Initial Catalog=BazaKsiążki;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        public BazaKsiazki()
        {
            InitializeComponent();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OknoDodaj od = new OknoDodaj();
            od.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Click na baze danych
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //button usuń
            if (MessageBox.Show("Czy napewno chcesz usunąć dane?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                MessageBox.Show("Anulowano operacje");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from BazaKsiazki Where ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                MessageBox.Show("Usunięto dane!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //button odswież
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
            Process.Start("https://www.google.com/search?q=" + textBox2.Text);
        }
        //Wyszukaj
        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki Where ID = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki Where Tytuł = '" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki Where Autor = '" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;            
            textBox3.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki Where Wydawnictwo = '" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;            
            textBox4.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki Where Data_Wydania = '" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;           
            textBox5.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki Where Gatunek = '" + textBox6.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;            
            textBox6.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaKsiazki Where Słowa_Klucze = '" + textBox7.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;            
            textBox7.Clear();
        }
        //Aktualizacja
        private void button15_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update BazaKsiazki set ID = @ID Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@ID", textBox14.Text);
                cmd.ExecuteNonQuery();               
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox14.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update BazaKsiazki set Tytuł = @Tytuł Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@Tytuł", textBox13.Text);
                cmd.ExecuteNonQuery();                
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox13.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update BazaKsiazki set Autor = @Autor Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@Autor", textBox12.Text);
                cmd.ExecuteNonQuery();               
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox12.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update BazaKsiazki set Wydawnictwo = @Wydawnictwo Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@Wydawnictwo", textBox11.Text);
                cmd.ExecuteNonQuery();                
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox11.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update BazaKsiazki set Data_Wydania = @Data_Wydania Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@Data_Wydania", textBox10.Text);
                cmd.ExecuteNonQuery();                
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox10.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update BazaKsiazki set Gatunek = @Gatunek Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@Gatunek", textBox9.Text);
                cmd.ExecuteNonQuery();               
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox9.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update BazaKsiazki set Słowa_Klucze = @Słowa_Klucze Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@Słowa_Klucze", textBox8.Text);
                cmd.ExecuteNonQuery();                
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        //Sortowanie
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            con.Close();
            if (checkBox1.CheckState == CheckState.Checked)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki Order by Tytuł";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            con.Close();
            if (checkBox2.CheckState == CheckState.Checked)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki Order by Autor";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            con.Close();
            if (checkBox3.CheckState == CheckState.Checked)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki Order by Wydawnictwo";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            con.Close();
            if (checkBox4.CheckState == CheckState.Checked)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki Order by Data_Wydania";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            con.Close();
            if (checkBox5.CheckState == CheckState.Checked)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki Order by Gatunek";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            con.Close();
            if (checkBox6.CheckState == CheckState.Checked)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki Order by Słowa_Klucze";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from BazaKsiazki";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
        }
    }
}
