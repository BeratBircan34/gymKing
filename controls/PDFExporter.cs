using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public class PDFExporter
{
    public static void ExportFormToPdf(Form form)
    {
        try
        {
            if (form == null)
            {
                MessageBox.Show("Form bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PDF dosyasını kaydetmek için SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyaları|*.pdf";
            saveFileDialog.Title = "PDF Dosyasını Kaydet";
            saveFileDialog.FileName = "Rapor.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    // iTextSharp Document nesnesi oluşturuyoruz
                    Document doc = new Document(PageSize.A4, 72, 72, 72, 72); // 2 cm kenar boşlukları
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    writer.PageEvent = new PdfPageEvents(); // Sayfa numarası için

                    doc.Open();

                    // Font ayarları (Türkçe karakterler için uygun font)
                    string fontPath = @"C:\Windows\Fonts\arial.ttf"; // Arial font dosyasının yolu
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font normalFont = new Font(baseFont, 10);
                    Font titleFont = new Font(baseFont, 16, Font.BOLD);
                    Font headerFont = new Font(baseFont, 22, Font.BOLD); // Daha büyük başlık fontu

                    /*// "G Y M K I N G" başlığını ekliyoruz
                    Paragraph gymkingHeader = new Paragraph("G Y M K I N G", new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\COPRGTL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 25, Font.BOLD))
                    {
                        Alignment = Element.ALIGN_LEFT
                    };
                    doc.Add(gymkingHeader);
                    doc.Add(new Paragraph("\n")); // Gymking yazısının altında boşluk bırakıyoruz*/

                    // "Tablolar" başlığını ekliyoruz
                    Paragraph tablolarHeader = new Paragraph("Tablolar", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(tablolarHeader);
                    doc.Add(new Paragraph("\n \n")); // Tablolar başlığından sonra boşluk bırakıyoruz

                    // DataGridView içeriklerini ekleme
                    foreach (Control control in form.Controls)
                    {
                        if (control is DataGridView dataGridView && dataGridView.Name != "dgv_kisiler")
                        {
                            // DataGridView içeriklerini PDF'e aktarıyoruz
                            PdfPTable table = new PdfPTable(dataGridView.Columns.Count);
                            table.WidthPercentage = 100;

                            // DataGridView başlıkları
                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {
                                PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, normalFont));
                                headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                                table.AddCell(headerCell);
                            }

                            // DataGridView verileri
                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(new Phrase(cell.Value?.ToString() ?? "", normalFont)); // null kontrolü
                                }
                            }

                            doc.Add(table);
                        }
                    }

                    doc.Add(new Paragraph("\n")); // Tablolardan sonra boşluk bırakıyoruz

                    // "Yorumlar" başlığını ekliyoruz
                    Paragraph yorumlarHeader = new Paragraph("Yorumlar", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(yorumlarHeader);

                    // richtxt_yorumlama içeriğini PDF'e ekliyoruz
                    foreach (Control control in form.Controls)
                    {
                        if (control is RichTextBox richTextBox && richTextBox.Name == "richtxt_yorumlama")
                        {
                            Paragraph yorumlarText = new Paragraph(richTextBox.Text ?? "", normalFont); // null kontrolü
                            doc.Add(yorumlarText);
                        }
                    }

                    doc.Add(new Paragraph("\n")); // Yorumlar ve Eğitmen Notları arasına boşluk ekliyoruz

                    // "Eğitmen Notları" başlığını ekliyoruz
                    Paragraph egitmenHeader = new Paragraph("Eğitmen Notları", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(egitmenHeader);

                    // richtxt_eknot içeriğini PDF'e ekliyoruz
                    foreach (Control control in form.Controls)
                    {
                        if (control is RichTextBox richTextBox && richTextBox.Name == "richtxt_eknot")
                        {
                            Paragraph egitmenText = new Paragraph(richTextBox.Text ?? "", normalFont); // null kontrolü
                            doc.Add(egitmenText);
                        }
                    }

                    doc.Close();
                }

                MessageBox.Show("PDF başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Sayfa numarası eklemek için özel sayfa olayları
    public class PdfPageEvents : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            base.OnEndPage(writer, doc);

            // Sayfa numarasını ekliyoruz
            string pageNumber = "Sayfa " + writer.PageNumber;
            
            // Sayfa numarasını ortalamak için pozisyon hesaplama
            Phrase phrase = new Phrase(pageNumber, new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 10));
            float x = (30); // Ortalanmış
            float y = doc.PageSize.GetBottom(30); // Sayfanın alt kısmında
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, phrase, x, y, 0);
        }
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            Paragraph gymkingHeader = new Paragraph("G Y M K I N G", new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\COPRGTL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 25, Font.BOLD))
            {
                Alignment = Element.ALIGN_LEFT
            };
            document.Add(gymkingHeader);
            document.Add(new Paragraph("\n")); // Gymking yazısının altında boşluk bırakıyoruz
        }
    }
}
