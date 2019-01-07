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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            // button ksiazek
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

        private void button3_Click(object sender, EventArgs e)
        {
            //button filmów
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

        private void button4_Click(object sender, EventArgs e)
        {
            //button muzyki
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

        

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/?lang=pl");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
            email em = new email();
            em.Show();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KsiążkiBaza bk = new KsiążkiBaza();
            bk.Show();
        }

        private void button11_click(object sender, MouseEventArgs e)
        {
            Process.Start("http://lubimyczytac.pl/ksiazki/nowosci-wydawnicze");
        }

        private void button12_Click(object sender, MouseEventArgs e)
        {
            Process.Start("http://film.interia.pl/premiery-filmowe");
        }

        private void button13_Click(object sender, MouseEventArgs e)
        {
            Process.Start("http://www.empik.com/nowosci/muzyka");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Książki filmy = new Książki();
            filmy.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MuzykaBaza bm = new MuzykaBaza();
            bm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            KsiazkiWypozyczenie kw = new KsiazkiWypozyczenie();
            kw.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FilmyWypozyczenie fw = new FilmyWypozyczenie();
            fw.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MuzykiWypozyczenie mw = new MuzykiWypozyczenie();
            mw.Show();
        }
    }
}
