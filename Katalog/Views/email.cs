using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Katalog
{
    public partial class email : Form
    {
        public email()
        {
            InitializeComponent();
        }

        private void PokazHasloCheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox5.UseSystemPasswordChar = true;
            }
            else
            {
                textBox5.UseSystemPasswordChar = false;
            }
        }

        private void ZamknijClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CzcionkaClick(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Font = fd.Font;
            }
        }

        private void PrzegladajClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string sciezka = dlg.FileName.ToString();
                textBox6.Text = sciezka;
            }
        }

        private void WyslijClick(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Attachments.Add(new Attachment(textBox6.Text));
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(textBox4.Text);
                mail.To.Add(textBox1.Text);
                mail.Subject = textBox2.Text;
                mail.Body = textBox3.Text;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(textBox4.Text, textBox5.Text);
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                MessageBox.Show("Wiadomość została wysłana!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Bląd!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
