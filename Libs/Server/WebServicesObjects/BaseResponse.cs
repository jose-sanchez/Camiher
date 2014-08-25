using System.Runtime.Serialization;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;

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

        public bool IsCorrect 
        {
            get
            {
                return ResponseError.Ok == ErrorResponse;           
            }
        }

    }
}
