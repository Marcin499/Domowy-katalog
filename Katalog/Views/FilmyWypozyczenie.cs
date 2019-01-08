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
    public partial class FilmyWypozyczenie : Form
    {
        ModelContext modelContext = new ModelContext();
        BazaFilmówWypożyczenie bazaFilmy = new BazaFilmówWypożyczenie();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FilmyWypozyczenie()
        {           
            InitializeComponent();
            Wyswietl();
        }

        private void ZamknijClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajFilmyWypozyczeniaClick(object sender, EventArgs e)
        {
            try
            {
                if (Waliduj())
                {
                    bazaFilmy.Imię = textBox2.Text.Trim();
                    bazaFilmy.Nazwisko = textBox3.Text.Trim();
                    bazaFilmy.Tytuł = textBox4.Text.Trim();
                    bazaFilmy.DataWypozyczenia = Convert.ToDateTime(dateTimePicker1.Text);
                    bazaFilmy.DataZwrotu = Convert.ToDateTime(dateTimePicker2.Text);                    
                    modelContext.FilmyWypożyczenie.Add(bazaFilmy);
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

        private void AktualizujFilmyWypozyczenieClick(object sender, EventArgs e)
        {
            try
            {
                bazaFilmy.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaFilmy = modelContext.FilmyWypożyczenie.Where(x => x.Id == bazaFilmy.Id).FirstOrDefault();
                modelContext.FilmyWypożyczenie.Remove(bazaFilmy);
                modelContext.SaveChanges();

                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    bazaFilmy.Tytuł = textBox2.Text.Trim();
                    modelContext.FilmyWypożyczenie.Add(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    bazaFilmy.Imię = textBox3.Text.Trim();
                    modelContext.FilmyWypożyczenie.Add(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    bazaFilmy.Nazwisko = textBox4.Text.Trim();
                    modelContext.FilmyWypożyczenie.Attach(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(dateTimePicker1.Text))
                {
                    bazaFilmy.DataWypozyczenia = Convert.ToDateTime(dateTimePicker1.Text);
                    modelContext.FilmyWypożyczenie.Add(bazaFilmy);
                }
                if (!string.IsNullOrEmpty(dateTimePicker2.Text))
                {
                    bazaFilmy.DataZwrotu = Convert.ToDateTime(dateTimePicker2.Text);
                    modelContext.FilmyWypożyczenie.Add(bazaFilmy);
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

        private void UsunFilmyWypozyczeniaClick(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć dane?", "Uwaga", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bazaFilmy.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    bazaFilmy = modelContext.FilmyWypożyczenie.Where(x => x.Id == bazaFilmy.Id).FirstOrDefault();
                    modelContext.FilmyWypożyczenie.Remove(bazaFilmy);
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
                bazaFilmy.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                bazaFilmy = modelContext.FilmyWypożyczenie.Where(x => x.Id == bazaFilmy.Id).FirstOrDefault();
                textBox2.Text = bazaFilmy.Tytuł;
                textBox3.Text = bazaFilmy.Imię;
                textBox4.Text = bazaFilmy.Nazwisko;
                dateTimePicker1.Text = bazaFilmy.DataWypozyczenia.ToString();
                dateTimePicker2.Text = bazaFilmy.DataZwrotu.ToString();
                
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

        private void SzukajFilmyWypozyczeniaClick(object sender, EventArgs e)
        {
            IQueryable<BazaFilmówWypożyczenie> baza = modelContext.FilmyWypożyczenie;

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
