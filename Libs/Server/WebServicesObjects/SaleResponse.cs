﻿using System.Runtime.Serialization;
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
