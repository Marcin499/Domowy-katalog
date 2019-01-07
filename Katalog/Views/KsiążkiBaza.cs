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
    public partial class KsiążkiBaza : Form
    {
        ModelContext modelContext = new ModelContext();
        BazaKsiążki bazaKsiążki = new BazaKsiążki();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public KsiążkiBaza()
        {
            InitializeComponent();
            Wyswietl();
        }

        private void DodajKsiazkiClick(object sender, EventArgs e)
        {
            try
            {
                if (Walidacja())
                {
                    bazaKsiążki.Tytuł = textBox1.Text.Trim();
                    bazaKsiążki.Autor = textBox3.Text.Trim();
                    bazaKsiążki.Wydawnictwo = textBox4.Text.Trim();
                    bazaKsiążki.DataWydania = Convert.ToDateTime(textBox5.Text);
                    bazaKsiążki.Gatunek = textBox6.Text.Trim();
                    bazaKsiążki.SłowaKlucze = textBox7.Text;
                    modelContext.BazaKsiążki.Add(bazaKsiążki);
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

        private void UsunKsiazkiClick(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć dane?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bazaKsiążki.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    bazaKsiążki = modelContext.BazaKsiążki.Where(x => x.Id == bazaKsiążki.Id).FirstOrDefault();
                    modelContext.BazaKsiążki.Remove(bazaKsiążki);
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

        private void AktualizujKsiazkiClick(object sender, EventArgs e)
        {
            try
            {
                bazaKsiążki.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaKsiążki = modelContext.BazaKsiążki.Where(x => x.Id == bazaKsiążki.Id).FirstOrDefault();
                modelContext.BazaKsiążki.Remove(bazaKsiążki);
                modelContext.SaveChanges();

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bazaKsiążki.Tytuł = textBox1.Text.Trim();
                    modelContext.BazaKsiążki.Add(bazaKsiążki);
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    bazaKsiążki.Autor = textBox3.Text.Trim();
                    modelContext.BazaKsiążki.Add(bazaKsiążki);
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    bazaKsiążki.Wydawnictwo = textBox4.Text.Trim();
                    modelContext.BazaKsiążki.Attach(bazaKsiążki);
                }
                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    bazaKsiążki.DataWydania = Convert.ToDateTime(textBox5.Text);
                    modelContext.BazaKsiążki.Add(bazaKsiążki);
                }
                if (!string.IsNullOrEmpty(textBox6.Text))
                {
                    bazaKsiążki.Gatunek = textBox6.Text.Trim();
                    modelContext.BazaKsiążki.Add(bazaKsiążki);
                }
                if (!string.IsNullOrEmpty(textBox7.Text))
                {
                    bazaKsiążki.SłowaKlucze = textBox7.Text;
                    modelContext.BazaKsiążki.Add(bazaKsiążki);
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
                bazaKsiążki.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaKsiążki = modelContext.BazaKsiążki.Where(x => x.Id == bazaKsiążki.Id).FirstOrDefault();
                textBox1.Text = bazaKsiążki.Tytuł;
                textBox3.Text = bazaKsiążki.Autor;
                textBox4.Text = bazaKsiążki.Wydawnictwo;
                textBox5.Text = bazaKsiążki.DataWydania.ToString();
                textBox6.Text = bazaKsiążki.Gatunek;
                textBox7.Text = bazaKsiążki.SłowaKlucze;
            }
        }

        private void Wyswietl()
        {
            var dane =
                from a in modelContext.BazaKsiążki
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
                MessageBox.Show("Uzupełnij autora!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Uzupełnij wydawnictwo!");
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
                MessageBox.Show("Uzupełnij słowa kluczowe!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SortujTytułyKsiazkiCheckedChanged(object sender, EventArgs e)
        {
            if (SortujTytuły.Checked)
            {
                var dane =
                    from a in modelContext.BazaKsiążki
                    orderby a.Tytuł
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaKsiążki
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujAutorówKsiazkiCheckedChanged(object sender, EventArgs e)
        {
            if (SortujAutorów.Checked)
            {
                var dane =
                    from a in modelContext.BazaKsiążki
                    orderby a.Autor
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaKsiążki
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujWydawnictwaKsiazkiCheckedChanged(object sender, EventArgs e)
        {
            if (SortujWydawnictwa.Checked)
            {
                var dane =
                    from a in modelContext.BazaKsiążki
                    orderby a.Wydawnictwo
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaKsiążki
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujDatyWydaniaKsiazkiCheckedChanged(object sender, EventArgs e)
        {
            if (SortujDatyWydania.Checked)
            {
                var dane =
                    from a in modelContext.BazaKsiążki
                    orderby a.DataWydania descending
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaKsiążki
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujGatunkiKsiazkiCheckedChanged(object sender, EventArgs e)
        {
            if (SortujGatunki.Checked)
            {
                var dane =
                    from a in modelContext.BazaKsiążki
                    orderby a.Gatunek
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaKsiążki
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SortujSłowaKluczeKsiazkiCheckedChanged(object sender, EventArgs e)
        {
            if (SortujSłowaKlucze.Checked)
            {
                var dane =
                    from a in modelContext.BazaKsiążki
                    orderby a.SłowaKlucze descending
                    select a;
                dataGridView1.DataSource = dane.ToList();
            }
            else
            {
                var dane =
               from a in modelContext.BazaKsiążki
               select a;
                dataGridView1.DataSource = dane.ToList();
            }
        }

        private void SzukajKsiazkiClick(object sender, EventArgs e)
        {
            IQueryable<BazaKsiążki> baza = modelContext.BazaKsiążki;
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
                baza = baza.Where(y => y.Wydawnictwo == textBox4.Text);
            }
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                baza = baza.Where(y => y.DataWydania == Convert.ToDateTime(textBox5.Text));
            }
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                baza = baza.Where(y => y.Gatunek == textBox6.Text);
            }
            if (!string.IsNullOrEmpty(textBox7.Text))
            {
                baza = baza.Where(y => y.SłowaKlucze == textBox7.Text);
            }
            dataGridView1.DataSource = baza.ToList();
        }
    }
 }
    