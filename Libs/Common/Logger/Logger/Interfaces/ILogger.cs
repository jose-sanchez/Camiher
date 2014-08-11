#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Interface commun for loggers
// </summary>
// <creation issue="" date="13-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    interface ILogger
    {
        void Info(String message);


        void Trace(String message);

        void Error(String message);

        void ErrorException(String message, Exception exception);

    }
}
