using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using NationalCriminal.Search.DataContracts;
using NationalCriminal.Search.Service.Entities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace NationalCriminal.Search.Service.BusinessLogic
{
    public class SearchController
    {        
        private readonly DataAccess.DataAccess _dataAccess = null;

        #region Public Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchController()
        {
            _dataAccess = new DataAccess.DataAccess();
        }

        /// <summary>
        /// This method is ued to search the criminals and send their details to user.
        /// </summary>
        /// <param name="searchRequest">CriminalSearchRequest searchRequest</param>
        public void SendMailWithCriminalRecords(CriminalSearchRequest searchRequest)
        {            
            try
            {
                var criminalProfiles = _dataAccess.SearchCriminalProfiles(searchRequest.SearchCriteria);

                if (searchRequest.MaxResults != null && criminalProfiles.Count > searchRequest.MaxResults)
                {
                    int maxResult = (int) searchRequest.MaxResults;
                    if (maxResult == 0)
                        maxResult = Convert.ToInt32(ConfigurationManager.AppSettings["MaxResultCount"]);
                    criminalProfiles.RemoveRange(maxResult, criminalProfiles.Count - maxResult);
                }

                List<CriminalProfile> entitiesCriminalProfiles=Translator.ToEntitiesCriminalProfiles(criminalProfiles);

                if (entitiesCriminalProfiles != null && entitiesCriminalProfiles.Count > 0)
                {
                    foreach (var profile in entitiesCriminalProfiles)
                    {                        
                        var crimeDetails = _dataAccess.GetCriminalCrimeDetails(profile);
                        profile.CrimeDetails=Translator.ToEntitiesCriminalCrimeDetails(crimeDetails);
                    }
                }              

                SendEmailToReceipient(searchRequest.EmailId, entitiesCriminalProfiles);
            }
            catch (Exception exception)
            {                
                throw new SmtpException("Error while processing criminal profiles.", exception);
            }
        }

        #endregion      

        /// <summary>
        /// This method is used to Send Email To Receipient
        /// </summary>
        /// <param name="emailId">string emailId</param>
        /// <param name="criminalProfiles">List<CriminalProfile> criminalProfiles</param>
        private void SendEmailToReceipient(string emailId, List<CriminalProfile> criminalProfiles)
        {
            try
            {
                MailMessage mail = GetMailMessage(emailId);
                int maxAttachmentCount = GetMaxMailAttachmentsCount();
                SmtpClient smtpServer = GetSmtpServer();

                if (criminalProfiles != null && criminalProfiles.Count > 0)
                {                    
                    if (criminalProfiles.Count > GetMaxMailAttachmentsCount())
                    {
                        SendMultipleEmails(criminalProfiles, maxAttachmentCount, mail, smtpServer);                     
                    }

                    if (criminalProfiles.Count > 0 && criminalProfiles.Count <= maxAttachmentCount)
                    {
                        SendMailWithAttachingPdfFiles(criminalProfiles, mail, smtpServer);
                    }                
                }
                else
                {
                    mail.Body = "Sorry we dont find any criminals for your search criteria.";
                    mail.Subject = "Criminals not found.";
                    smtpServer.Send(mail);
                }
            }
            catch (Exception exception)
            {
                throw new SmtpException("Smtp server failed.",exception);
            }
        }

        /// <summary>
        /// This method is used to send multiple emails to recepient.
        /// </summary>
        /// <param name="criminalProfiles">List<CriminalProfile> criminalProfiles</param>
        /// <param name="maxAttachmentCount">int maxAttachmentCount</param>
        /// <param name="mail">MailMessage mail</param>
        /// <param name="smtpServer">SmtpClient smtpServer</param>
        private void SendMultipleEmails(List<CriminalProfile> criminalProfiles, int maxAttachmentCount, MailMessage mail, SmtpClient smtpServer)
        {
            while (criminalProfiles.Count > maxAttachmentCount)
            {
                SendMailWithAttachingPdfFiles(criminalProfiles.GetRange(0, maxAttachmentCount), mail, smtpServer);
                criminalProfiles.RemoveRange(0, maxAttachmentCount);
            }
        }

        /// <summary>
        /// This method is used to attaching the pdf files to mail.
        /// </summary>
        /// <param name="criminalProfiles">List<CriminalProfile> criminalProfiles</param>
        /// <param name="mail">MailMessage mail</param>
        /// <param name="smtpServer">SmtpClient smtpServer</param>
        private void SendMailWithAttachingPdfFiles(List<CriminalProfile> criminalProfiles, MailMessage mail, SmtpClient smtpServer)
        {
            criminalProfiles.ForEach(profile =>
            {
                if (profile != null)
                {
                    Attachment pdfFile = new Attachment(PdfGenerator.GeneratePdfFile(profile));
                    while (true)
                    {
                        try
                        {
                            mail.Attachments.Add(pdfFile);
                            break;
                        }
                        catch (Exception)
                        {
                            
                        }   
                    }                                        
                }
            });
                      
          smtpServer.Send(mail);            
            
        }

        /// <summary>
        /// This method is used to get the mail message.
        /// </summary>
        /// <param name="emailId">string emailId</param>
        /// <returns>MailMessage</returns>
        private static MailMessage GetMailMessage(string emailId)
        {
            return new MailMessage()
            {
                From = new MailAddress(ConfigurationManager.AppSettings["AdminMailId"]),
                To = { emailId },
                Subject = "Criminal Profiles",
                Body = "Please find attahced profile(s) for your search criteria.",
            };
        }

        /// <summary>
        /// This method is used to get the smtp client.
        /// </summary>
        /// <returns>SmtpClient</returns>
        private static SmtpClient GetSmtpServer()
        {
            return new SmtpClient(ConfigurationManager.AppSettings["SmtpServerName"])
            {
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["AdminMailId"], ConfigurationManager.AppSettings["AdminMailPassword"]),
                EnableSsl = true
            };
        }

        /// <summary>
        /// This method is used to get the maximum attachment to be attached with the mail.
        /// </summary>
        /// <returns>int</returns>
        private int GetMaxMailAttachmentsCount()
        {
            int maxCount;
            int.TryParse(ConfigurationManager.AppSettings["MaxMailAttachmentCount"],out maxCount);
            return maxCount;
        }

    }
}
