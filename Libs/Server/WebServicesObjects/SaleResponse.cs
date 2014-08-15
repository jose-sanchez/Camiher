using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.Libs.Server.WebServicesObjects;

namespace Camiher.Libs.Server.WebServicesObjects
{
    [DataContract]
     public class SaleResponse:BaseResponse
    {
        public SaleSet Sale { get; set; }
    }
}
