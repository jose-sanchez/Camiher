using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.DAL.CamiherDAL
{
    public class SaleSet
    {
        [Key]
        public string Id { get; set; }
        public Int32 PriceforClient { get; set; }
        public Int32 PriceClientOffered { get; set; }
        public DateTime LastEmailDate { get; set; }
        public Int32 FinalPrice { get; set; }
        public string Client_ID { get; set; }
        public string Product_ID { get; set; }
   
    }
}
