using gymKing.controls;
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
       
        public Kasiyer(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }
        public string kasiyer_oturumSahibi = "";
        public string id_ = "";

       

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
            timer1.Start();
            lbl_oturumSahibi.Text = kasiyer_oturumSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
            
        }

      

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            K_Uyelik uyelik = new K_Uyelik(id_);
            uyelik.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            urunSatis urun = new urunSatis(id_);
            urun.Show();
            this.Hide();
        }

       
    }   
}
