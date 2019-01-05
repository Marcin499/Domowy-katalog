using Katalog.ModelEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katalog
{
    public partial class Filmy : Form
    {
        ModelContext modelContext = new ModelContext();

        public Filmy()
        {
            InitializeComponent();
            Wyswietl();
        }
                
        private void DodajClick(object sender, EventArgs e)
        {
            if (Walidacja())
            {
                BazaFilmy filmy = new BazaFilmy();
                filmy.Tytuł = textBox1.Text;
                filmy.Reżyseria = textBox3.Text;
                filmy.Wytwórnia = textBox4.Text;
                filmy.DataPremiery = Convert.ToDateTime(textBox5.Text);
                filmy.Gatunek = textBox6.Text;
                filmy.CzasTrwania = Convert.ToInt32(textBox7.Text);
                modelContext.BazaFilmy.Add(filmy);
                modelContext.SaveChanges();
            }            
        }

        private void Usun_Click(object sender, EventArgs e)
        {

        }

        private void Odswiez_Click(object sender, EventArgs e)
        {
            Wyswietl();
        }

        private void Przegladaj_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Wyswietl()
        {
            var dane = from a in modelContext.BazaFilmy
                       select new { a.Id, a.Tytuł, a.Reżyseria, a.DataPremiery, a.Gatunek, a.CzasTrwania };
            dataGridView1.DataSource = dane.ToList();
        }

        private void Zamknij_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Walidacja()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Uzupełnij tytuł!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Uzupełnij reżysera!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Uzupełnij wytwórnie!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Uzupełnij date!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Uzupełnij gatunek!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Uzupełnij czas trwania filmu!");
                return false;
            }
            else
            {                
                return true;
            }
        }
    }
}
