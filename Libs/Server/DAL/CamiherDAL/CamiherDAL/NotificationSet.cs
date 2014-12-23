using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.DAL.CamiherDAL
{
    public class NotificationSet
    {
        [Key]
        public string ID { get; set; }
        public string ProductID { get; set; }     
        public string Search_ID { get; set; }
   
    }
}
