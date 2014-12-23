using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camiher.Libs.Server.DAL.CamiherDAL;

namespace Camiher.Libs.Server.WebServicesObjects
{
    public class SoldProductsResponse:BaseResponse
    {
        public IEnumerable<ItemSoldProductList> Products { get; set; }
    }
}
