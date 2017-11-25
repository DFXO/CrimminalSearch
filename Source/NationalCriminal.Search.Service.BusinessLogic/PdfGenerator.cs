using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using NationalCriminal.Search.Service.Entities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace NationalCriminal.Search.Service.BusinessLogic
{
    public static class PdfGenerator
    {
        /// <summary>
        /// This method is used to generate the pdf file
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static string GeneratePdfFile(CriminalProfile profile)
        {
            string pdfFilePath = null;
            while (true)
            {
                try
                {
                    PdfDocument doc = new PdfDocument();

                    PdfPage pg = new PdfPage();
                    pg = doc.AddPage();
                    XGraphics graph = XGraphics.FromPdfPage(pg);
                    WriteToPdfFile(graph, profile, profile.CrimeDetails);
                    var directory = ConfigurationManager.AppSettings["PdfFileStoragePath"];
                    if (!string.IsNullOrEmpty(directory))
                    {
                        pdfFilePath = directory + @"PdfFiles" + new Random().Next() + ".pdf";
                        doc.Save(pdfFilePath);
                        doc.Close();
                        doc.Dispose();                        
                    }
                    break;
                }
                catch (Exception)
                {
                                        
                }                
            }
            return pdfFilePath;
        }

        /// <summary>
        /// This method is used toConvert the byte array to XImage
        /// </summary>
        /// <param name="byteArray">byte[] byteArray</param>
        /// <returns>XImage</returns>
        private static XImage ByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// This method is used to write the contents to pdf file.
        /// </summary>
        /// <param name="graphics">XGraphics graphics</param>
        /// <param name="profile">CriminalProfile profile</param>
        /// <param name="crimeDetails">List<CriminalCrimeDetails> crimeDetails</param>
        private static void WriteToPdfFile(XGraphics graphics, CriminalProfile profile, List<CriminalCrimeDetails> crimeDetails)
        {
            XFont font = new XFont("calibri", 30, XFontStyle.Bold);
            graphics.DrawString("Criminal Name: " + profile.Name.ToUpper(), font, XBrushes.Black, new PointF(110, 50));

            WriteCriminalPhotoToPdf(graphics, profile);

            WritePersonalDataToPdf(graphics, profile);

            WriteCrimeHistory(graphics, crimeDetails);
        }

        /// <summary>
        /// This method is used to write Criminal photo in PDF file.
        /// </summary>
        /// <param name="graphics">XGraphics graphics</param>
        /// <param name="profile">CriminalProfile profile</param>
        private static void WriteCriminalPhotoToPdf(XGraphics graphics, CriminalProfile profile)
        {
            byte[] criminalPhoto = profile.Photograph.ToArray();
            XImage image = ByteArrayToImage(criminalPhoto);
            graphics.DrawImage(image, 400, 70);
        }

        /// <summary>
        /// This method is used to write Criminal history PDF file.
        /// </summary>
        /// <param name="graphics">XGraphics graphics</param>
        /// <param name="crimeDetails">List<CriminalCrimeDetails> crimeDetails</param>
        private static void WriteCrimeHistory(XGraphics graphics, List<CriminalCrimeDetails> crimeDetails)
        {
            XFont font;
            font = new XFont("calibri", 20, XFontStyle.Bold);
            graphics.DrawString("-----------Crime History----------", font, XBrushes.Black, new PointF(120, 420));
            font = new XFont("calibri", 13, XFontStyle.Bold);
            int yPoint = 450;

            foreach (var crime in crimeDetails)
            {
                graphics.DrawString("Crime : " + crime.CrimeType, font, XBrushes.Black, new PointF(150, yPoint));
                graphics.DrawString("Description : " + crime.CrimeDescription, font, XBrushes.Black, new PointF(150, yPoint + 30));
                graphics.DrawString("Location :" + crime.CrimeLocation, font, XBrushes.Black, new PointF(150, yPoint + 60));
                graphics.DrawString("Charges : " + crime.CrimeCharges, font, XBrushes.Black, new PointF(150, yPoint + 90));
                graphics.DrawString("FIR Number : " + crime.FirNo, font, XBrushes.Black, new PointF(150, yPoint + 120));
                graphics.DrawString("Crime Time: " + crime.CrimeDateTime, font, XBrushes.Black, new PointF(150, yPoint + 150));
                graphics.DrawString("************************************", font, XBrushes.Black, new PointF(150, yPoint + 180));
                yPoint = yPoint + 210;
            }
        }

        /// <summary>
        /// This method is used to write Criminal personal information in PDF file.
        /// </summary>
        /// <param name="graphics">XGraphics graphics</param>
        /// <param name="profile">CriminalProfile profile</param>
        private static void WritePersonalDataToPdf(XGraphics graphics, CriminalProfile profile)
        {
            string personeldata = string.Format("Age:{0}, Weight:{1}, Height:{2}, Sex:{3}", profile.Age, profile.Weight, profile.Height, profile.Sex);
            string addressdetails = string.Format("Country:{0}, State: {1}, City: {2},", profile.Country, profile.State, profile.City);

            var font = new XFont("calibri", 20, XFontStyle.Bold);
            graphics.DrawString("-----------Personal Information-----------", font, XBrushes.Black, new PointF(120, 250));

            font = new XFont("calibri", 13, XFontStyle.Bold);
            graphics.DrawString(personeldata, font, XBrushes.Black, new PointF(170, 280));
            graphics.DrawString("Identiication Mark: " + profile.IdentificationMarks, font, XBrushes.Black, new PointF(170, 310));
            graphics.DrawString(addressdetails, font, XBrushes.Black, new PointF(170, 340));
            graphics.DrawString(profile.Address, font, XBrushes.Black, new PointF(170, 370));
        }
    }
}
