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
            
            button5.Visible = true;
            button8.Visible = true;
            button11.Visible = true;
            button6.Visible = false;
            button9.Visible = false;
            button12.Visible = false;
            button7.Visible = false;
            button10.Visible = false;
            button13.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;


        }

        private void button3_Click(object sender, EventArgs e)
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
            button15.Visible = false;
            button16.Visible = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
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
            button15.Visible = false;
            button16.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            button8.Visible = false;
            button11.Visible = false;
            button6.Visible = false;
            button9.Visible = false;
            button12.Visible = false;
            button7.Visible = false;
            button10.Visible = false;
            button13.Visible = false;
            button15.Visible = true;
            button16.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
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
            BazaKsiazki bk = new BazaKsiazki();
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
    }
}
