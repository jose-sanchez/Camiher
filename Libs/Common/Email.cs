#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Email.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Intended to send emails
// </summary>
// <creation issue="" date="11-08-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion
using System;
using System.Net;
using System.Net.Mail;
using CommonLogger;
using Common.Logger;

namespace Common
{
    public class Email:IEmail
    {
        private readonly SmtpClient _smtpClient;
        public Email(String userName, String userPassword, String host, int port, SmtpDeliveryMethod deliveryMethod, bool useDefaultCredentials)
        {
            _smtpClient = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = deliveryMethod,
                UseDefaultCredentials = useDefaultCredentials,
                Credentials = new NetworkCredential(userName, userPassword)
            };
        }

        public Email(String userName, String userPassword, SmtpClientType clientType)
        {
            _smtpClient = SmtpClientFactory.GetSmtpClient(clientType);
            _smtpClient.Credentials = new NetworkCredential(userName, userPassword);
        }

        /// <summary>
        /// Send a email
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public Boolean SendEmail(MailAddress fromAddress, MailAddress toAddress, string subject, string body, String[] imagePath)
        {
            Boolean emailSent = true;

            //Create the email
            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };

            foreach (string path in imagePath)
            {
                var attachment = new Attachment(path);
                message.Attachments.Add(attachment);
            }
            try
            {
                _smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                emailSent = false;
                AppLogger.ErrorException(String.Format("Unable to send email from {0} to {1}",
                    fromAddress.Address, toAddress.Address), ex);
            }

            return emailSent;
        }
    }
}
