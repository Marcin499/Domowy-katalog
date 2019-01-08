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
using Katalog.ModelEntity;

namespace Katalog
{
    public partial class KsiazkiWypozyczenie : Form
    {
        ModelContext modelContext = new ModelContext();
        BazaKsiążekWypożyczenie bazaKsiążek = new BazaKsiążekWypożyczenie();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public KsiazkiWypozyczenie()
        {
            InitializeComponent();
            Wyswietl();
        }

        private void ZamknijClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AktualizujKsiazkiWypozyczeniaClick(object sender, EventArgs e)
        {
            try
            {
                bazaKsiążek.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaKsiążek = modelContext.KsiążkiWypożyczenie.Where(x => x.Id == bazaKsiążek.Id).FirstOrDefault();
                modelContext.KsiążkiWypożyczenie.Remove(bazaKsiążek);
                modelContext.SaveChanges();

                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    bazaKsiążek.Tytuł = textBox2.Text.Trim();
                    modelContext.KsiążkiWypożyczenie.Add(bazaKsiążek);
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    bazaKsiążek.Imię = textBox3.Text.Trim();
                    modelContext.KsiążkiWypożyczenie.Add(bazaKsiążek);
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    bazaKsiążek.Nazwisko = textBox4.Text.Trim();
                    modelContext.KsiążkiWypożyczenie.Attach(bazaKsiążek);
                }
                if (!string.IsNullOrEmpty(dateTimePicker1.Text))
                {
                    bazaKsiążek.DataWypozyczenia = Convert.ToDateTime(dateTimePicker1.Text);
                    modelContext.KsiążkiWypożyczenie.Add(bazaKsiążek);
                }
                if (!string.IsNullOrEmpty(dateTimePicker2.Text))
                {
                    bazaKsiążek.DataZwrotu = Convert.ToDateTime(dateTimePicker2.Text);
                    modelContext.KsiążkiWypożyczenie.Add(bazaKsiążek);
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

        private void UsunKsiazkiWypozyczeniaClick(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć dane?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bazaKsiążek.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    bazaKsiążek = modelContext.KsiążkiWypożyczenie.Where(x => x.Id == bazaKsiążek.Id).FirstOrDefault();
                    modelContext.KsiążkiWypożyczenie.Remove(bazaKsiążek);
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

        private void DataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                bazaKsiążek.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaKsiążek = modelContext.KsiążkiWypożyczenie.Where(x => x.Id == bazaKsiążek.Id).FirstOrDefault();
                textBox2.Text = bazaKsiążek.Tytuł;
                textBox3.Text = bazaKsiążek.Imię;
                textBox4.Text = bazaKsiążek.Nazwisko;
                dateTimePicker1.Text = bazaKsiążek.DataWypozyczenia.ToString();
                dateTimePicker2.Text = bazaKsiążek.DataZwrotu.ToString();

            }
        }

        private void Wyswietl()
        {
            var dane =
                from a in modelContext.KsiążkiWypożyczenie
                select a;

            dataGridView1.DataSource = dane.ToList();
        }

        private bool Waliduj()
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Uzupełnij tytuł!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Uzupełnij imię!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Uzupełnij nazwisko!");
                return false;
            }
            else if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Uzupełnij date wypożyczenia!");
                return false;
            }
            else if (string.IsNullOrEmpty(dateTimePicker2.Text))
            {
                MessageBox.Show("Uzupełnij datę zwrotu!");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void DodajKsiazkiWypozyczeniaClick(object sender, EventArgs e)
        {
            try
            {
                if (Waliduj())
                {
                    bazaKsiążek.Imię = textBox2.Text.Trim();
                    bazaKsiążek.Nazwisko = textBox3.Text.Trim();
                    bazaKsiążek.Tytuł = textBox4.Text.Trim();
                    bazaKsiążek.DataWypozyczenia = Convert.ToDateTime(dateTimePicker1.Text);
                    bazaKsiążek.DataZwrotu = Convert.ToDateTime(dateTimePicker2.Text);
                    modelContext.KsiążkiWypożyczenie.Add(bazaKsiążek);
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

        private void SzukajKsiazkiWypozyczeniaClick(object sender, EventArgs e)
        {
            IQueryable<BazaKsiążekWypożyczenie> baza = modelContext.KsiążkiWypożyczenie;

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                baza = baza.Where(y => y.Tytuł == textBox2.Text);
            }
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                baza = baza.Where(y => y.Imię == textBox3.Text);
            }
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                baza = baza.Where(y => y.Nazwisko == textBox4.Text);
            }
            if (!string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                baza = baza.Where(y => y.DataWypozyczenia == Convert.ToDateTime(dateTimePicker1.Text));
            }
            if (!string.IsNullOrEmpty(dateTimePicker2.Text))
            {
                baza = baza.Where(y => y.DataZwrotu == Convert.ToDateTime(dateTimePicker2.Text));
            }
            dataGridView1.DataSource = baza.ToList();
        }
    }
}
