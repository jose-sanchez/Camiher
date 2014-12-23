using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.DAL.CamiherDAL
{
    public class ProductTranslations
    {
        [Key]
        public String Id { get; set; }
        public String Product { get; set; }
        public String Language { get; set; }
        public String Description { get; set; }
    }
}
