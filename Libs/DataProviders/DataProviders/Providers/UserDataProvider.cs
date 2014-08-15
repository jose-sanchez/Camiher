#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDataProvider.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  module intended to contact with the user web services and return the results
// </summary>
// <creation issue="" date="11-08-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion

using Camiher.Libs.DataProviders.Interfaces;

using System;
using Camiher.Libs.DataProviders.ServiceReference1;

namespace Camiher.Libs.DataProviders.Providers
{
   public class UserDataProvider:IUserProviderAsync
    {
        private readonly UsersWebServiceSoapClient _userWebServiceinstance;

       public UserDataProvider()
       {
           _userWebServiceinstance = new UsersWebServiceSoapClient();
       }

       public event EventHandler<HelloWorldCompletedEventArgs> GetHelloWorldAsyncComplete
            {
            add
            {
                _userWebServiceinstance.HelloWorldCompleted += value;
            }

            remove
            {
                _userWebServiceinstance.HelloWorldCompleted -= value;
            }            
        }

        public bool GetHelloWorldAsync()
        {
            _userWebServiceinstance.HelloWorldAsync();
            return true;
        }
    }
}
