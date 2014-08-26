using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;

namespace Camiher.Libs.Server.WebServicesObjects
{
    public class ProductsResponse:BaseResponse
    {
        public ObjectSet<ProductsSet> Products { get; set; }
    }
}
