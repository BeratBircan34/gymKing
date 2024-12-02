using gymKing.kasiyer_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace gymKing.kasiyer_forms
{
    public partial class Kasiyer : Form
    {
       
        public Kasiyer()
        {
            InitializeComponent();
        }
        public string kasiyer_oturumSahibi = "";

        private void Kasiyer_Load(object sender, EventArgs e)
        {
            timer1.Start();
            SetMdiContainerBackColor(Color.Gainsboro);
            lbl_oturumSahibi.Text = kasiyer_oturumSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString("00");
        }

        private void SetMdiContainerBackColor(Color color)
        {
            foreach (Control control in this.Controls)
            {
                control.BackColor = Color.Gainsboro;
                if (control is MdiClient mdiClient)
                {
                    mdiClient.BackColor = color; // Arka plan rengini ayarla
                }
            }
        }

        private void KASİYER_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            K_Uyelik uyelik = new K_Uyelik();
            uyelik.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            urunSatis urun = new urunSatis();
            urun.Show();
            this.Hide();
        }

       
    }   
}
