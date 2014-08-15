using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;

namespace Camiher.Libs.DataProviders.Interfaces
{
    public interface IBusinessOperationProvider
    {
        BaseResponse ClientBuyProduct(string clientId, string productId, string sale);

        SaleSet GetCurrentSale(string clientId, string productId);
    }
}
