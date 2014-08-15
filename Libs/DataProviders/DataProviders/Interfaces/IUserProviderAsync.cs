#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserProviderAsync.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Model the method to recover information about the users
// </summary>
// <creation issue="" date="01-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion
using System;
using Camiher.Libs.DataProviders.ServiceReference1;


namespace Camiher.Libs.DataProviders.Interfaces
{
    public interface IUserProviderAsync
    {
        bool GetHelloWorldAsync();

        event EventHandler<HelloWorldCompletedEventArgs> GetHelloWorldAsyncComplete;
    }
}
