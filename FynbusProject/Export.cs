using System.Collections.Generic;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System;

namespace FynbusProject
{
    public class Export
    {
        private CalculateWinner cw = null;
        private List<Route> listOfWinners = new List<Route>();
        private int numberOfRows;
        public Export(CalculateWinner calculateWinner, int numRows)
        {
            cw = calculateWinner;
            numberOfRows = numRows;
        }

        private string getPlaceToSave()
        {
            string placeToSave = "WinnerList.pdf";
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.DefaultExt = ".pdf";
            if (saveFileDialog.ShowDialog() == true)
                placeToSave = saveFileDialog.FileName;
            else
                throw new Exception("Export canceled!");

            return placeToSave;
        }

        public void ExportToPDF()
        {
            listOfWinners = cw.GetWinners();
            string placeToSave = "";

            
                placeToSave = getPlaceToSave();

                FileStream fs = new FileStream(placeToSave, FileMode.Create);
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                // Create an instance to the PDF file by creating an instance of the PDF 
                // Writer class using the document and the filestrem in the constructor.
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                PdfPTable table = new PdfPTable(numberOfRows);
                PreparePdfTable(table);

                document.Open();
                document.Add(table);
               
            
          
        }

        private void PreparePdfTable(PdfPTable table)
        {
            table.AddCell("Route number");
            table.AddCell("Company name");
            table.AddCell("Contact person");
            table.AddCell("Contract value");

            foreach (Route r in listOfWinners)
            {
                table.AddCell(r.RouteNumber.ToString());
                table.AddCell(r.WinningOffer.OfferContractor.CompanyName);
                table.AddCell(r.WinningOffer.OfferContractor.PersonName);
                table.AddCell(r.WinningOffer.ContractValue.ToString());
            }
        }

        public void ExportToCVS()
        {
            listOfWinners = cw.GetWinners();

        }



    }
}
