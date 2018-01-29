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
    public partial class OknoDodajFilmy : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BPE4OM3;Initial Catalog=BazaKsiążki;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public OknoDodajFilmy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into BazaFilmów (ID,Tytuł, Reżyseria, Wytwórnia, Data_PREMIERY, Gatunek, Czas_trwania) values (@ID,@Tytuł, @Reżyseria, @Wytwórnia, @Data_premiery, @Gatunek, @Czas_trwania)";
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Tytuł", textBox2.Text);
                cmd.Parameters.AddWithValue("@Reżyseria", textBox3.Text);
                cmd.Parameters.AddWithValue("@Wytwórnia", textBox4.Text);
                cmd.Parameters.AddWithValue("@Data_premiery", textBox5.Text);
                cmd.Parameters.AddWithValue("@Gatunek", textBox6.Text);
                cmd.Parameters.AddWithValue("@Czas_trwania", textBox7.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Dane zostały dodane.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Błąd!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
