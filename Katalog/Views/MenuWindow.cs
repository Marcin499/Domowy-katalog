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

namespace Katalog
{
    public partial class MenuWindow : Form
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void ZamknijClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KsiazkiClick(object sender, EventArgs e)
        {
            button5.Visible = true;
            button8.Visible = true;
            button11.Visible = true;
            button6.Visible = false;
            button9.Visible = false;
            button12.Visible = false;
            button7.Visible = false;
            button10.Visible = false;
            button13.Visible = false;            
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
        }

        private void FilmyClick(object sender, EventArgs e)
        {
            button5.Visible = false;
            button8.Visible = false;
            button11.Visible = false;
            button6.Visible = true;
            button9.Visible = true;
            button12.Visible = true;
            button7.Visible = false;
            button10.Visible = false;
            button13.Visible = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
            pictureBox3.Visible = true;
        }

        private void MuzykaClick(object sender, EventArgs e)
        {
            button5.Visible = false;
            button8.Visible = false;
            button11.Visible = false;
            button6.Visible = false;
            button9.Visible = false;
            button12.Visible = false;
            button7.Visible = true;
            button10.Visible = true;
            button13.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void FacebookClick(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/");
        }

        private void TwitterClick(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/?lang=pl");
        }

        private void EmailClick(object sender, EventArgs e)
        {
            email em = new email();
            em.Show();
        }

        private void KsiazkiBazaClick(object sender, EventArgs e)
        {
            KsiążkiBaza bk = new KsiążkiBaza();
            bk.Show();
        }

        private void WiecejKsiazekclick(object sender, MouseEventArgs e)
        {
            Process.Start("http://lubimyczytac.pl/ksiazki/nowosci-wydawnicze");
        }

        private void WiecejFilmowClick(object sender, MouseEventArgs e)
        {
            Process.Start("http://film.interia.pl/premiery-filmowe");
        }

        private void WiecejMuzykiClick(object sender, MouseEventArgs e)
        {
            Process.Start("http://www.empik.com/nowosci/muzyka");
        }

        private void FilmyBazaClick(object sender, EventArgs e)
        {
            FilmyBaza filmy = new FilmyBaza();
            filmy.Show();
        }

        private void MuzykaBazaClick(object sender, EventArgs e)
        {
            MuzykaBaza bm = new MuzykaBaza();
            bm.Show();
        }

        private void KsiazkiWypozyczeniaClick(object sender, EventArgs e)
        {
            KsiazkiWypozyczenie kw = new KsiazkiWypozyczenie();
            kw.Show();
        }

        private void FilmyWypozyczeniaClick(object sender, EventArgs e)
        {
            FilmyWypozyczenie fw = new FilmyWypozyczenie();
            fw.Show();
        }

        private void MuzykaWypozyczeniaClick(object sender, EventArgs e)
        {
            MuzykiWypozyczenie mw = new MuzykiWypozyczenie();
            mw.Show();
        }
    }
}
