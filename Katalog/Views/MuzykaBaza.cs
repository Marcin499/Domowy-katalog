using Katalog.ModelEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katalog
{
    public partial class MuzykaBaza : Form
    {
        ModelContext modelContext = new ModelContext();
        BazaMuzyka bazaMuzyka = new BazaMuzyka();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MuzykaBaza()
        {
            InitializeComponent();
            Wyswietl();
        }

        private void DodajMuzykaClick(object sender, EventArgs e)
        {
            try
            {
                if (Waliduj())
                {
                    bazaMuzyka.Tytuł = textBox1.Text.Trim();
                    bazaMuzyka.Autor = textBox3.Text.Trim();
                    bazaMuzyka.Wytwórnia = textBox4.Text.Trim();
                    bazaMuzyka.DataPremiery = Convert.ToDateTime(textBox5.Text);
                    bazaMuzyka.Gatunek = textBox6.Text.Trim();                    
                    modelContext.BazaMuzyka.Add(bazaMuzyka);
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

        private void UsunMuzykaClick(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć dane?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bazaMuzyka.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    bazaMuzyka = modelContext.BazaMuzyka.Where(x => x.Id == bazaMuzyka.Id).FirstOrDefault();
                    modelContext.BazaMuzyka.Remove(bazaMuzyka);
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

        private void AktualizujMuzykaClick(object sender, EventArgs e)
        {
            try
            {
                bazaMuzyka.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaMuzyka = modelContext.BazaMuzyka.Where(x => x.Id == bazaMuzyka.Id).FirstOrDefault();
                modelContext.BazaMuzyka.Remove(bazaMuzyka);
                modelContext.SaveChanges();

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bazaMuzyka.Tytuł = textBox1.Text.Trim();
                    modelContext.BazaMuzyka.Add(bazaMuzyka);
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    bazaMuzyka.Autor = textBox3.Text.Trim();
                    modelContext.BazaMuzyka.Add(bazaMuzyka);
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    bazaMuzyka.Wytwórnia = textBox4.Text.Trim();
                    modelContext.BazaMuzyka.Attach(bazaMuzyka);
                }
                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    bazaMuzyka.DataPremiery = Convert.ToDateTime(textBox5.Text);
                    modelContext.BazaMuzyka.Add(bazaMuzyka);
                }
                if (!string.IsNullOrEmpty(textBox6.Text))
                {
                    bazaMuzyka.Gatunek = textBox6.Text.Trim();
                    modelContext.BazaMuzyka.Add(bazaMuzyka);
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
            if (dataGridView1.CurrentRow.Index != -1)
            {
                bazaMuzyka.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaMuzyka = modelContext.BazaMuzyka.Where(x => x.Id == bazaMuzyka.Id).FirstOrDefault();
                textBox1.Text = bazaMuzyka.Tytuł;
                textBox3.Text = bazaMuzyka.Autor;
                textBox4.Text = bazaMuzyka.Wytwórnia;
                textBox5.Text = bazaMuzyka.DataPremiery.ToString();
                textBox6.Text = bazaMuzyka.Gatunek;                
            }
        }

        private void Wyswietl()
        {
            var dane =
                from a in modelContext.BazaMuzyka
                select a;

            dataGridView1.DataSource = dane.ToList();
        }

        private void ZamknijClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Waliduj()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Uzupełnij tytuł!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Uzupełnij autora!");
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
            else
            {
                return true;
            }
        }

        private void SortujTytulyMuzykaCheckedChanged(object sender, EventArgs e)
        {
            if (SortujTytuły.Checked)
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    orderby a.Tytuł
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujRezyserowMuzykaCheckedChanged(object sender, EventArgs e)
        {
            if (SortujRezyserow.Checked)
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    orderby a.Autor
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujWytworniiMuzykaCheckedChanged(object sender, EventArgs e)
        {
            if (SortujWytwornii.Checked)
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    orderby a.Wytwórnia
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujDatyPremieryMuzykaCheckedChanged(object sender, EventArgs e)
        {
            if (SortujDatyPremiery.Checked)
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    orderby a.DataPremiery descending
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujGatunkiMuzykaCheckedChanged(object sender, EventArgs e)
        {
            if (SortujGatunki.Checked)
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    orderby a.Gatunek
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
                    from a in modelContext.BazaMuzyka
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SzukajMuzykaClick(object sender, EventArgs e)
        {
            IQueryable<BazaMuzyka> baza = modelContext.BazaMuzyka;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                baza = baza.Where(y => y.Tytuł == textBox1.Text);
            }
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                baza = baza.Where(y => y.Autor == textBox3.Text);
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
            dataGridView1.DataSource = baza.ToList();
        }
    }
}
