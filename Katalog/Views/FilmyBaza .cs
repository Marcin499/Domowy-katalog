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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using log4net;

namespace Katalog
{
    public partial class Książki : Form
    {
        ModelContext modelContext = new ModelContext();
        BazaFilmy bazaFilmy = new BazaFilmy();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Książki()
        {
            InitializeComponent();
            Wyswietl();
        }
                
        private void DodajFilmyClick(object sender, EventArgs e)
        {
            try
            {
                if (Walidacja())
                {                    
                    bazaFilmy.Tytuł = textBox1.Text.Trim();
                    bazaFilmy.Reżyseria = textBox3.Text.Trim();
                    bazaFilmy.Wytwórnia = textBox4.Text.Trim();
                    bazaFilmy.DataPremiery = Convert.ToDateTime(textBox5.Text);
                    bazaFilmy.Gatunek = textBox6.Text.Trim();
                    bazaFilmy.CzasTrwania = Convert.ToInt32(textBox7.Text);
                    modelContext.BazaFilmy.Add(bazaFilmy);
                    modelContext.SaveChanges();
                    MessageBox.Show("Dodano nowy rekord.");
                    log.Info("Dane zapisano poprawnie.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd!!!");
                log.Error("Błąd!", ex);
            }
            Wyswietl();
        }

        private void UsunFilmyClick(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć dane?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bazaFilmy.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    bazaFilmy = modelContext.BazaFilmy.Where(x => x.Id == bazaFilmy.Id).FirstOrDefault();
                    modelContext.BazaFilmy.Remove(bazaFilmy);
                    modelContext.SaveChanges();
                    MessageBox.Show("Usunieto Dane!");
                    log.Info("Dane usunięto poprawnie.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd!");
                log.Error("Błąd!", ex);
            }
            Wyswietl();
        }

        private void AktualizujFilmyClick(object sender, EventArgs e)
        {
            try
            {
                bazaFilmy.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaFilmy = modelContext.BazaFilmy.Where(x => x.Id == bazaFilmy.Id).FirstOrDefault();
                modelContext.BazaFilmy.Remove(bazaFilmy);
                modelContext.SaveChanges();

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bazaFilmy.Tytuł = textBox1.Text.Trim();
                    modelContext.BazaFilmy.Add(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    bazaFilmy.Reżyseria = textBox3.Text.Trim();
                    modelContext.BazaFilmy.Add(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    bazaFilmy.Wytwórnia = textBox4.Text.Trim();
                    modelContext.BazaFilmy.Attach(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    bazaFilmy.DataPremiery = Convert.ToDateTime(textBox5.Text);
                    modelContext.BazaFilmy.Add(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(textBox6.Text))
                {
                    bazaFilmy.Gatunek = textBox6.Text.Trim();
                    modelContext.BazaFilmy.Add(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(textBox7.Text))
                {
                    bazaFilmy.CzasTrwania = Convert.ToInt32(textBox7.Text);
                    modelContext.BazaFilmy.Add(bazaFilmy);
                }
                    modelContext.SaveChanges();
                    log.Info("Dane zaktualizowano poprawnie.");
            }
             catch (Exception ex)
            {
                MessageBox.Show("Błąd!");
                log.Error("Błąd!", ex);
            }
            Wyswietl();
        }

        private void PrzegladajClick(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/search?q=" + textBox1.Text);
        }

        private void DataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Index != -1)
            {
                bazaFilmy.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaFilmy = modelContext.BazaFilmy.Where(x => x.Id == bazaFilmy.Id).FirstOrDefault();
                textBox1.Text = bazaFilmy.Tytuł;                
                textBox3.Text = bazaFilmy.Reżyseria;
                textBox4.Text = bazaFilmy.Wytwórnia;
                textBox5.Text = bazaFilmy.DataPremiery.ToString();
                textBox6.Text = bazaFilmy.Gatunek;
                textBox7.Text = bazaFilmy.CzasTrwania.ToString();
            }
        }

        private void Wyswietl()
        {
            var dane =
                from a in modelContext.BazaFilmy
                select a;

            dataGridView1.DataSource = dane.ToList();
        }

        private void ZamknijClick(object sender, EventArgs e)
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

        private void SortujTytułyFilmyCheckedChanged(object sender, EventArgs e)
        {
            if (SortujTytuły.Checked)
            {
                var dane =
                    from a in modelContext.BazaFilmy
                    orderby a.Tytuł
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaFilmy
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujRezyserowFilmyCheckedChanged(object sender, EventArgs e)
        {
            if (SortujRezyserow.Checked)
            {
                var dane =
                    from a in modelContext.BazaFilmy
                    orderby a.Reżyseria 
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaFilmy
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujWytworniiFilmyCheckedChanged(object sender, EventArgs e)
        {
            if (SortujWytwornii.Checked)
            {
                var dane =
                    from a in modelContext.BazaFilmy
                    orderby a.Wytwórnia
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaFilmy
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujDatyPremieryFilmyCheckedChanged(object sender, EventArgs e)
        {
            if (SortujDatyPremiery.Checked)
            {
                var dane =
                    from a in modelContext.BazaFilmy
                    orderby a.DataPremiery descending
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaFilmy
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujGatunkiFilmyCheckedChanged(object sender, EventArgs e)
        {
            if (SortujGatunki.Checked)
            {
                var dane =
                    from a in modelContext.BazaFilmy
                    orderby a.Gatunek
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaFilmy
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujCzasTrwaniaFilmyCheckedChanged(object sender, EventArgs e)
        {
            if (SortujCzasTrwania.Checked)
            {
                var dane =
                    from a in modelContext.BazaFilmy
                    orderby a.CzasTrwania descending
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaFilmy
               select a;
               dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SzukajFilmyClick(object sender, EventArgs e)
        {
            IQueryable<BazaFilmy> baza = modelContext.BazaFilmy;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                baza = baza.Where(y => y.Tytuł == textBox1.Text);
            }
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                baza = baza.Where(y => y.Reżyseria == textBox3.Text);
            }
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                baza = baza.Where(y => y.Wytwórnia == textBox4.Text);
            }
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                baza = baza.Where(y => y.DataPremiery == Convert.ToDateTime(textBox5.Text));
            }
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                baza = baza.Where(y => y.Gatunek == textBox6.Text);
            }
            if (!string.IsNullOrEmpty(textBox7.Text))
            {
                baza = baza.Where(y => y.CzasTrwania == Convert.ToInt32(textBox7.Text));
            }
            dataGridView1.DataSource = baza.ToList();
        }
    }
}
