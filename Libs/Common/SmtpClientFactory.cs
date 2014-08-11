#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtopClientFactory.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Prototype class to initializate the Smtpclient instances according with the company used
// </summary>
// <creation issue="" date="11-08-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion
using System;
using System.Net.Mail;
using Logger;

namespace Common
{
    // represent the possible type of smtpclient, currently only Gmail but can be extended to contain yahoo,hotmail..
    public enum SmtpClientType
    {
        Gmail,
        Unknown
    }

    public class SmtpClientFactory
    {
        // return a new instance of SmtpClient with the Gmail configuration.The property "Credentials" must be set up 
        public static SmtpClient Gmail     
        {
            get
            {
                return new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                };
            }
        }

        /// <summary>
        /// Return a new instance of SmtpClient initializate with the values for the company smtpClient specifies in smtpClientType
        /// </summary>
        /// <param name="smtpClientType">smtpClient company type</param>
        /// <returns></returns>
        public static SmtpClientType GetSmtpClientType(string smtpClientType)
        {
            switch (smtpClientType.ToLower())
            {
                case "gmail":
                    return SmtpClientType.Gmail;
                default:
                    AppLogger.Trace(String.Format("stmpClientType '{0}' not supported", smtpClientType));
                    return SmtpClientType.Unknown;
            }
        }

        /// <summary>
        /// Return a new instance of SmtpClient initializate with the values for the company smtpClient specifies in smtpClientType
        /// </summary>
        /// <param name="smtpClientType">smtpClient company type</param>
        /// <returns></returns>
        public static SmtpClient GetSmtpClient(SmtpClientType smtpClientType)
        {
            switch (smtpClientType)
            {
                case SmtpClientType.Gmail:
                    return Gmail;
                default:
                    AppLogger.Error(String.Format("stmpClientType '{0}' not supported", smtpClientType));
                    throw new ArgumentException(String.Format("stmpClientType '{0}' not supported", smtpClientType));
            }
        }
    }
}
