using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.WebServicesObjects
{
    public enum ResponseError
    {
        Ok,
        InvalidParameters,
        Error,     
    }

    [DataContract]
    public class BaseResponse
    {
        public ResponseError ErrorResponse { get; set; }

    }
}
