#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmail.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  
// </summary>
// <creation issue="" date="11-08-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion

using System;
using System.Net.Mail;

namespace Camiher.Libs.Common
{
    public interface IEmail
    {
        Boolean SendEmail(MailAddress fromAddress, MailAddress toAddress, string subject, string body,
            String[] imagePath);

    }
}
