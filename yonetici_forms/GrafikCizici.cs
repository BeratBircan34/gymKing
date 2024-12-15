using gymKing.oto_Baglanti;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gymKing.yonetici_forms
{
    public class GrafikCizici
    {

        public void GrafikCiz(Chart chartGelirGider)
        {
            // Bağlantıyı açma
            using (SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize()))
            {
                baglanti.Open();  // Bağlantıyı açıyoruz

                // SQL sorgusu
                string sorgu = @"
            SELECT 
                SUM(CASE WHEN IslemTuru = 'Gelir' THEN Tutar ELSE 0 END) AS ToplamGelir,
                SUM(CASE WHEN IslemTuru = 'Gider' THEN Tutar ELSE 0 END) AS ToplamGider
            FROM tbl_GelirGider";

                // SQL sorgusunu çalıştırma ve veriyi alma
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    SqlDataReader reader = komut.ExecuteReader();

                    if (reader.Read())
                    {
                        // Veriyi al
                        decimal toplamGelir;
                        if (reader.IsDBNull(0))
                        {
                            toplamGelir = 0;  // Eğer veri boşsa, toplamGelir 0 olur
                        }
                        else
                        {
                            toplamGelir = reader.GetDecimal(0);  // Veriyi alıyoruz
                        }

                        decimal toplamGider;
                        if (reader.IsDBNull(1))
                        {
                            toplamGider = 0;  // Eğer veri boşsa, toplamGider 0 olur
                        }
                        else
                        {
                            toplamGider = reader.GetDecimal(1);  // Veriyi alıyoruz
                        }

                        decimal kar = toplamGelir - toplamGider; // Kar hesaplama

                        // Grafik için serileri temizleme
                        chartGelirGider.Series.Clear();

                        // Gelir serisini oluşturma
                        Series gelirSeries = new Series("Gelir")
                        {
                            ChartType = SeriesChartType.Column,  // Sütun grafik tipi
                            Points = { new DataPoint(0, (double)toplamGelir) }  // Gelir verisi
                        };
                        chartGelirGider.Series.Add(gelirSeries);  // Gelir serisini ekle

                        // Gider serisini oluşturma
                        Series giderSeries = new Series("Gider")
                        {
                            ChartType = SeriesChartType.Column,  // Sütun grafik tipi
                            Points = { new DataPoint(1, (double)toplamGider) }  // Gider verisi
                        };
                        chartGelirGider.Series.Add(giderSeries);  // Gider serisini ekle

                        // Kar verisi gösterme
                        Series karSeries = new Series("Kar")
                        {
                            ChartType = SeriesChartType.Column, // Sütun grafik
                            Points = { new DataPoint(2, (double)kar) }
                        };
                        chartGelirGider.Series.Add(karSeries);


                        // Grafik başlıkları ve etiketleri
                        chartGelirGider.ChartAreas[0].AxisX.Title = "İşlem Türü";
                        chartGelirGider.ChartAreas[0].AxisY.Title = "Miktar";
                    }
                    else
                    {
                        MessageBox.Show("Veri bulunamadı.");
                    }
                    baglanti.Close();
                }  
            }  
        }
    }


}
                
            
        
    


       