using System.Collections.Generic;
using System.Runtime.Serialization;
using Camiher.Libs.Server.DAL.CamiherDAL;

namespace Camiher.Libs.Server.WebServicesObjects
{
    public class ProductsImagesResponse : BaseResponse
    {
        public IEnumerable<ProductImageSet> ProductsImages { get; set; }
    }
}
