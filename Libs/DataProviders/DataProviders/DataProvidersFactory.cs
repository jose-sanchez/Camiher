#region copyright
///----------------------------------------------------------------------------------------
///<filename>IUserProviderAsync</filename>
///<summary>Factory with Methods to access new instances of the DataProviders Classes</summary>
///<creator>Jose Maria Sanchez Simon</creator>
///<date>01/07/2014</date>
///----------------------------------------------------------------------------------------
#endregion
using DataProviders.Providers;
using DataProviders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProviders
{
    public class DataProvidersFactory
    {
        static public IUserProviderAsync GetUserDataProvider()
        {
            return new UserDataProvider();
        }
    }
}
