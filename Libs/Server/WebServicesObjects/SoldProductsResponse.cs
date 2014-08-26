using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using ClassLibrary1;

namespace Camiher.Libs.Server.WebServicesObjects
{
    public class SoldProductsResponse:BaseResponse
    {
        public ObjectSet<ItemSoldProductList> Products { get; set; }
    }
}
