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
    public partial class BazaMuzyka : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BPE4OM3;Initial Catalog=BazaKsiążki;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public BazaMuzyka()
        {
            InitializeComponent();
            con.Close(); con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaMuzyka";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OknoDodajMuzyka odm = new OknoDodajMuzyka();
            odm.Show();
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
                textBox5.Clear();
                textBox6.Clear();
                
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from BazaMuzyka Where ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                
                MessageBox.Show("Usunięto dane!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaMuzyka";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //Otwieranie wyszukiwarki Google
            Process.Start("https://www.google.com/search?q=" + textBox2.Text);
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
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaMuzyka Where ID = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaMuzyka Where Tytuł = '" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaMuzyka Where Autor = '" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox3.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaMuzyka Where Wytwórnia = '" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox4.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaMuzyka Where Data_premiery = '" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox5.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from BazaMuzyka Where Gatunek = '" + textBox6.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox6.Clear();
        }

       

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update  BazaMuzyka set ID = @ID Where ID ='" + textBox1.Text + "'";
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
               
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update  BazaMuzyka set Tytuł = @Tytuł Where ID ='" + textBox1.Text + "'";
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
               
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update BazaMuzyka set Autor = @Autor Where ID ='" + textBox1.Text + "'";
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
                
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update  BazaMuzyka set Wytwórnia = @Wytwórnia Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@Wytwórnia", textBox11.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox11.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update  BazaMuzyka set Data_premiery = @Data_premiery Where ID ='" + textBox1.Text + "'";
                cmd.Parameters.AddWithValue("@Data_premiery", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Zaktualizowano dane.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox10.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update  BazaMuzyka set Gatunek = @Gatunek Where ID ='" + textBox1.Text + "'";
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
                
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd! Spróbuj ponownie.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            con.Close();
            if (checkBox1.CheckState == CheckState.Checked)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from  BazaMuzyka Order by Tytuł";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from  BazaMuzyka";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
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
                cmd.CommandText = "Select * from  BazaMuzyka Order by Autor";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from  BazaMuzyka";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
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
                cmd.CommandText = "Select * from  BazaMuzyka Order by Wytwórnia";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from  BazaMuzyka";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
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
                cmd.CommandText = "Select * from BazaMuzyka Order by Data_premiery";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from  BazaMuzyka";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
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
                cmd.CommandText = "Select * from  BazaMuzyka Order by Gatunek";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from  BazaMuzyka";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

       
        
    }
}
