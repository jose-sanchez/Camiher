using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.BusinesOperations.Interfaces
{
    interface IClientsOperations
    {
        void ClientBuyProduct(string clientId, string productId, string currentSale);
    }
}
