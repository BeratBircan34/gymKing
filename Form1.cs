using gymKing.oto_Baglanti;
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
namespace gymKing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlOtoBaglanti.pcAdiAl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlOtoBaglanti.baglan();
            if(textBox1.Text == "admin" && textBox2.Text == "123")
            {
                MessageBox.Show("Giriş başarılı");

            }
            else
            {
                MessageBox.Show("BAŞARISIZ!!");
            }
            sqlOtoBaglanti.baglan();
        }
    }
}
