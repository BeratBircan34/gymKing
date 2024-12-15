using Microsoft.Office.Interop.Word;
using System;
using System.Drawing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

public class WordExport
{
    public void CreateDocument(Form form)
    {
        // Word Uygulaması Başlatılıyor
        var wordApp = new Word.Application();
        wordApp.Visible = true; // Word Uygulamasını görünür yapma

        // Yeni bir belge oluşturuluyor
        Word.Document wordDoc = wordApp.Documents.Add();

        // Sayfa düzeni ayarları
        wordDoc.PageSetup.LeftMargin = wordApp.InchesToPoints(0.79f); // 2 cm sol boşluk
        wordDoc.PageSetup.RightMargin = wordApp.InchesToPoints(0.79f); // 2 cm sağ boşluk

        AddGymKingToWord(wordDoc);

        // DataGridView'leri eklemek (İlk başta)
        AddDataGridViews(form, wordDoc);

        // 2. "Yorumlar" Başlığı
        Word.Paragraph yorumlarHeading = wordDoc.Content.Paragraphs.Add();
        yorumlarHeading.Range.Text = "Yorumlar";
        yorumlarHeading.Range.Font.Name = "Arial";
        yorumlarHeading.Range.Font.Size = 14;
        yorumlarHeading.Range.Font.Bold = 1;
        yorumlarHeading.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        yorumlarHeading.SpaceAfter = 6;

        // RichTextBox'dan yorumları ekle
        AddTextBoxContent(form.Controls["richtxt_yorumlama"] as RichTextBox, wordDoc);

        // 3. "Eğitmen Notları" Başlığı
        Word.Paragraph egitmenHeading = wordDoc.Content.Paragraphs.Add();
        egitmenHeading.Range.Text = "Eğitmen Notları";
        egitmenHeading.Range.Font.Name = "Arial";
        egitmenHeading.Range.Font.Size = 14;
        egitmenHeading.Range.Font.Bold = 1;
        egitmenHeading.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        egitmenHeading.SpaceAfter = 6;

        // RichTextBox'dan Eğitmen Notlarını ekle
        AddTextBoxContent(form.Controls["richtxt_eknot"] as RichTextBox, wordDoc);

        // Sayfa numarası ekle
        AddPageNumbers(wordDoc);

        // Belgeyi kaydet
        //string filePath = "C:\\Users\\CASPER\\Documents\\gymking_output.docx"; // Dosya yolu
        //wordDoc.SaveAs2(filePath);
       // wordDoc.Close();
        //wordApp.Quit();
    }

    private void AddDataGridViews(Form form, Word.Document wordDoc)
    {
        // DataGridView'lerin içeriğini eklemek
        foreach (Control control in form.Controls)
        {
            if (control is DataGridView dgv)
            {
                Word.Paragraph dgvParagraph = wordDoc.Content.Paragraphs.Add();
                dgvParagraph.Range.Text = "DataGridView: " + dgv.Name;
                dgvParagraph.Range.Font.Size = 10;
                dgvParagraph.SpaceAfter = 6;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string rowText = string.Join(" | ", row.Cells);
                    Word.Paragraph rowParagraph = wordDoc.Content.Paragraphs.Add();
                    rowParagraph.Range.Text = rowText;
                    rowParagraph.Range.Font.Size = 10;
                    rowParagraph.SpaceAfter = 2;
                }
            }
        }
    }
    public void AddGymKingToWord(Word.Document wordDoc)
    {
        
            // "G Y M K I N G" yazısını ekle
            Word.Paragraph gymKingParagraph = wordDoc.Content.Paragraphs.Add();
            gymKingParagraph.Range.Text = "G Y M K I N G";
            gymKingParagraph.Range.Font.Name = "Copperplate Gothic Bold";
            gymKingParagraph.Range.Font.Size = 25;
            gymKingParagraph.Range.Font.Bold = 1; // Kalın yap
            gymKingParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft; // Sol hizalı yap
            gymKingParagraph.Range.InsertParagraphAfter();

         
    }

    private void AddTextBoxContent(RichTextBox richTextBox, Word.Document wordDoc)
    {
        if (richTextBox != null)
        {
            Word.Paragraph richTextParagraph = wordDoc.Content.Paragraphs.Add();
            richTextParagraph.Range.Text = richTextBox.Text;
            richTextParagraph.Range.Font.Name = "Arial";
            richTextParagraph.Range.Font.Size = 12;
            richTextParagraph.SpaceAfter = 6;
        }
    }

    private void AddPageNumbers(Word.Document wordDoc)
    {
        // Sayfa numaralarını en alt ortada ekle
        Word.Paragraph pageNumberParagraph = wordDoc.Content.Paragraphs.Add();
        pageNumberParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        pageNumberParagraph.Range.Text = "Page " + wordDoc.Application.Selection.Information[Word.WdInformation.wdActiveEndPageNumber];
        pageNumberParagraph.Range.Font.Size = 10;
        pageNumberParagraph.SpaceBefore = 6;

        // Sayfa numarasını sayfanın alt kısmına ekleyin
        wordDoc.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.RestartNumberingAtSection = false;
        wordDoc.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.Add(Word.WdPageNumberAlignment.wdAlignPageNumberCenter);

    }
}
