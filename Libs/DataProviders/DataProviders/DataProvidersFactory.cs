#region copyright
///----------------------------------------------------------------------------------------
///<filename>IUserProviderAsync</filename>
///<summary>Factory with Methods to access new instances of the DataProviders Classes</summary>
///<creator>Jose Maria Sanchez Simon</creator>
///<date>01/07/2014</date>
///----------------------------------------------------------------------------------------
#endregion

using Camiher.Libs.DataProviders.Interfaces;
using Camiher.Libs.DataProviders.Providers;

namespace Camiher.Libs.DataProviders
{
    public class DataProvidersFactory
    {
        static public IUserProviderAsync GetUserDataProvider()
        {
            return new UserDataProvider();
        }

        static public IBusinessOperationProvider GetBusinessOperationProvider()
        {
            return new BusinessOperationProvider();
        }
    }
}
