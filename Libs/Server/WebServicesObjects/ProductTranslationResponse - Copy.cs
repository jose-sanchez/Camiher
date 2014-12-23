using System.Collections.Generic;
using System.Runtime.Serialization;
using Camiher.Libs.Server.DAL.CamiherDAL;

namespace Camiher.Libs.Server.WebServicesObjects
{
    public class ProductsTranslationResponse : BaseResponse
    {
        public ProductTranslations ProductsTranslation { get; set; }
    }
}
