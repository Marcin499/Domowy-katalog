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
    public partial class OknoDodaj : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BPE4OM3;Initial Catalog=BazaKsiążki;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public OknoDodaj()
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
                cmd.CommandText = "Insert into BazaKsiazki (ID,Tytuł, Autor, Wydawnictwo, Data_Wydania, Gatunek, Słowa_Klucze) values (@ID,@Tytuł, @Autor, @Wydawnictwo, @Data_Wydania, @Gatunek, @Słowa_Klucze)";
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Tytuł", textBox2.Text);
                cmd.Parameters.AddWithValue("@Autor", textBox3.Text);
                cmd.Parameters.AddWithValue("@Wydawnictwo", textBox4.Text);
                cmd.Parameters.AddWithValue("@Data_Wydania", textBox5.Text);
                cmd.Parameters.AddWithValue("@Gatunek", textBox6.Text);
                cmd.Parameters.AddWithValue("@Słowa_Klucze", textBox7.Text);
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
