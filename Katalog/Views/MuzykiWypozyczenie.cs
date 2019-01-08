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
    public partial class MuzykiWypozyczenie : Form
    {
        ModelContext modelContext = new ModelContext();
        BazaMuzykiWypożyczenie bazaMuzyki = new BazaMuzykiWypożyczenie();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MuzykiWypozyczenie()
        {
            InitializeComponent();
            Wyswietl();
        }

        private void ZamknijClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajMuzykaWypozyczeniaClick(object sender, EventArgs e)
        {
            try
            {
                if (Waliduj())
                {
                    bazaMuzyki.Imię = textBox2.Text.Trim();
                    bazaMuzyki.Nazwisko = textBox3.Text.Trim();
                    bazaMuzyki.Tytuł = textBox4.Text.Trim();
                    bazaMuzyki.DataWypozyczenia = Convert.ToDateTime(dateTimePicker1.Text);
                    bazaMuzyki.DataZwrotu = Convert.ToDateTime(dateTimePicker2.Text);
                    modelContext.MuzykaWypozyczenie.Add(bazaMuzyki);
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
    
        private void UsunMuzykaWypozyczeniaClick(object sender, EventArgs e)
        {
        try
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć dane?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bazaMuzyki.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaMuzyki = modelContext.MuzykaWypozyczenie.Where(x => x.Id == bazaMuzyki.Id).FirstOrDefault();
                modelContext.MuzykaWypozyczenie.Remove(bazaMuzyki);
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

        private void AktualizujMuzykaWypozyczeniaClick(object sender, EventArgs e)
        {
            try
            {
                bazaMuzyki.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaMuzyki = modelContext.MuzykaWypozyczenie.Where(x => x.Id == bazaMuzyki.Id).FirstOrDefault();
                modelContext.MuzykaWypozyczenie.Remove(bazaMuzyki);
                modelContext.SaveChanges();

                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    bazaMuzyki.Tytuł = textBox2.Text.Trim();
                    modelContext.MuzykaWypozyczenie.Add(bazaMuzyki);
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    bazaMuzyki.Imię = textBox3.Text.Trim();
                    modelContext.MuzykaWypozyczenie.Add(bazaMuzyki);
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    bazaMuzyki.Nazwisko = textBox4.Text.Trim();
                    modelContext.MuzykaWypozyczenie.Attach(bazaMuzyki);
                }
                if (!string.IsNullOrEmpty(dateTimePicker1.Text))
                {
                    bazaMuzyki.DataWypozyczenia = Convert.ToDateTime(dateTimePicker1.Text);
                    modelContext.MuzykaWypozyczenie.Add(bazaMuzyki);
                }
                if (!string.IsNullOrEmpty(dateTimePicker2.Text))
                {
                    bazaMuzyki.DataZwrotu = Convert.ToDateTime(dateTimePicker2.Text);
                    modelContext.MuzykaWypozyczenie.Add(bazaMuzyki);
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

        private void DataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                bazaMuzyki.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaMuzyki = modelContext.MuzykaWypozyczenie.Where(x => x.Id == bazaMuzyki.Id).FirstOrDefault();
                textBox2.Text = bazaMuzyki.Tytuł;
                textBox3.Text = bazaMuzyki.Imię;
                textBox4.Text = bazaMuzyki.Nazwisko;
                dateTimePicker1.Text = bazaMuzyki.DataWypozyczenia.ToString();
                dateTimePicker2.Text = bazaMuzyki.DataZwrotu.ToString();
            }
        }

        private void Wyswietl()
        {
            var dane =
                from a in modelContext.BazaFilmy
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
                MessageBox.Show("Uzupełnij date wypozyczenia!");
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
        private void SzukajMuzykaWypozyczeniaClick(object sender, EventArgs e)
        {
            IQueryable<BazaMuzykiWypożyczenie> baza = modelContext.MuzykaWypozyczenie;

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
